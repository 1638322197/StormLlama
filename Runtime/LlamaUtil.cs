using System.Diagnostics;
using System.Net.NetworkInformation;
using LibreHardwareMonitor.Hardware;

namespace StormLlama.Runtime;

/// <summary>
/// Llama工具
/// </summary>
public class LlamaUtil
{
    /// <summary>
    /// 硬件信息类
    /// </summary>
    public class HardwareInfo
    {
        public string? CpuName { get; set; }
        public string? GpuName { get; set; }

        public float CpuUsage { get; set; }
        public float GpuUsage { get; set; }

        public double MemoryUsed { get; set; }
        public double MemoryTotal { get; set; }

        public double VramUsed { get; set; }
        public double VramTotal { get; set; }

        public string? MemoryText { get; set; }
        public string? VramText { get; set; }
        public string? CpuText { get; set; }
        public string? GpuText { get; set; }
    }

    private readonly static LlamaUtil _llamaUtil = new();
    private readonly object _lock = new();
    private bool _running = false;
    private Computer? _computer;
    private System.Timers.Timer? _hwTimer;
    private Process? _process;
    private bool _monitorRunning = false;
    private CancellationTokenSource? _cts;
    private Action<string>? _outputCallback;
    private Action<HardwareInfo>? _hardwareCallback;
    private Action? _onLlamaExitCallback;


    /// <summary>
    /// 设置输出回调
    /// </summary>
    public static void SetOutputCallBack(Action<string>? action)
    {
        _llamaUtil._outputCallback = action;
    }

    /// <summary>
    /// 设置硬件信息回调
    /// </summary>
    public static void SetHardwareInfoCallBack(Action<HardwareInfo>? action)
    {
        _llamaUtil._hardwareCallback = action;
    }

    /// <summary>
    /// 设置Llama服务退出回调
    /// </summary>
    public static void SetOnLlamaExitCallBack(Action? action)
    {
        _llamaUtil._onLlamaExitCallback = action;
    }

    /// <summary>
    /// 启动服务
    /// </summary>
    public static bool StartLlama(string llamaExePath, string modelPath,string visualModelPath, int port, int nGpuLayers, int contextLength = 0, string extraParams = "")
    {
        if (!FileUtil.CheckModelExist())
        {
            return false;
        }

        if (!File.Exists(llamaExePath))
        {
            _llamaUtil._outputCallback?.Invoke("找不到 Llama 服务可执行文件");
            return false;
        }

        if (IsPortInUse(port))
        {
            _llamaUtil._outputCallback?.Invoke($"端口{port}被占用");
            return false;
        }

        lock (_llamaUtil._lock)
        {
            if (_llamaUtil._running)
            {
                _llamaUtil._outputCallback?.Invoke("服务已经在运行中");
                return false;
            }
            _llamaUtil._cts = new CancellationTokenSource();
            _llamaUtil._running = true;
        }

        var token = _llamaUtil._cts.Token;

        Task.Run(() =>
        {
            try
            {
                var args = $" -m \"{modelPath}\" --port {port} -ngl {nGpuLayers} --no-mmap";
                if (contextLength > 0) args += $" -c {contextLength}";
                if (!string.IsNullOrWhiteSpace(visualModelPath)) args += $" --mmproj \"{visualModelPath}\"";
                if (!string.IsNullOrWhiteSpace(extraParams)) args += " " + extraParams.Trim();

                var psi = new ProcessStartInfo
                {
                    FileName = llamaExePath,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                };

                var proc = new Process { StartInfo = psi, EnableRaisingEvents = true };
                _llamaUtil._process = proc;


                proc.OutputDataReceived += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        string clean = System.Text.RegularExpressions.Regex.Replace(e.Data.Trim(), @"\s+", " ");
                        _llamaUtil._outputCallback?.Invoke(clean);
                    }
                };

                proc.ErrorDataReceived += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        string clean = System.Text.RegularExpressions.Regex.Replace(e.Data.Trim(), @"\s+", " ");
                        _llamaUtil._outputCallback?.Invoke(clean);
                    }
                };

                proc.Exited += (s, e) =>
                {
                    _llamaUtil._outputCallback?.Invoke($"服务已退出");
                    _llamaUtil._onLlamaExitCallback?.Invoke();
                };

                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();

                _llamaUtil._outputCallback?.Invoke("服务启动成功");

                // 主循环，监控 token，而不是 _cts
                while (!token.IsCancellationRequested && !proc.HasExited)
                {
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                _llamaUtil._outputCallback?.Invoke($"运行异常: {ex.Message}");
            }
            finally
            {
                lock (_llamaUtil._lock)
                {
                    _llamaUtil._running = false;
                    _llamaUtil._cts?.Dispose();
                    _llamaUtil._cts = null;
                    _llamaUtil._process = null;
                }
            }
        });
        return true;
    }

    /// <summary>
    /// 停止服务
    /// </summary>
    public static void StopLlama(bool force = false)
    {
        Process? procToKill = null;
        CancellationTokenSource? ctsToCancel = null;

        lock (_llamaUtil._lock)
        {
            if (!_llamaUtil._running || _llamaUtil._process == null)
            {
                return;
            }

            procToKill = _llamaUtil._process;
            ctsToCancel = _llamaUtil._cts;
            _llamaUtil._cts = null;
        }

        Action stopAction = () =>
        {
            try
            {
                _llamaUtil._outputCallback?.Invoke("正在停止服务...");
                ctsToCancel?.Cancel();

                if (!procToKill.HasExited)
                {
                    try { procToKill.CloseMainWindow(); } catch { }

                    int attempts = force ? 15 : 5;
                    for (int i = 0; i < attempts && !procToKill.HasExited; i++)
                    {
                        try { procToKill.Kill(entireProcessTree: true); } catch { }
                        procToKill.WaitForExit(500);
                    }

                    if (force && !procToKill.HasExited)
                    {
                        _llamaUtil._outputCallback?.Invoke("等待端口释放...");
                        for (int i = 0; i < 10; i++)
                        {
                            if (!IsPortInUse(ConfigUtil.INI_ServicePort)) break;
                            Thread.Sleep(200);
                        }
                    }

                    if (!procToKill.HasExited)
                        _llamaUtil._outputCallback?.Invoke("进程仍未退出或端口未释放");
                }

                _llamaUtil._outputCallback?.Invoke("服务已停止");
            }
            catch (Exception ex)
            {
                _llamaUtil._outputCallback?.Invoke($"停止异常: {ex.Message}");
            }
            finally
            {
                lock (_llamaUtil._lock)
                {
                    _llamaUtil._process = null;
                    _llamaUtil._running = false;
                }
                procToKill.Dispose();
                ctsToCancel?.Dispose();
            }
        };

        if (force)
            stopAction();
        else
            Task.Run(stopAction);
    }

    /// <summary>
    /// 清理所有后台llama进程
    /// </summary>
    public static void KillAllLlamaServer()
    {
        try
        {
            var processes = Process.GetProcessesByName("llama-server");
            if (processes.Length == 0)
            {
                _llamaUtil._outputCallback?.Invoke("后台无llama-server进程");
                return;
            }

            foreach (var proc in processes)
            {
                try
                {
                    proc.Kill(entireProcessTree: true);
                    proc.WaitForExit(2000);
                }
                catch
                {
                }
            }
            _llamaUtil._outputCallback?.Invoke($"已清理 {processes.Length} 个 llama-server.exe 进程");
        }
        catch (Exception ex)
        {
            _llamaUtil._outputCallback?.Invoke("清理进程时出错: " + ex.Message);
        }
    }

    /// <summary>
    /// 端口占用检查
    /// </summary>
    private static bool IsPortInUse(int port)
    {
        try
        {
            var ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            var tcpConnections = ipProperties.GetActiveTcpListeners();
            return tcpConnections.Any(p => p.Port == port);
        }
        catch { return false; }
    }

    /// <summary>
    /// 开启硬件监控
    /// </summary>
    public static void StartHardwareMonitor(int intervalMs = 1000)
    {
        if (_llamaUtil._monitorRunning)
            return;

        _llamaUtil._monitorRunning = true;

        _llamaUtil._computer = new Computer()
        {
            IsCpuEnabled = true,
            IsGpuEnabled = true,
            IsMemoryEnabled = true
        };
        _llamaUtil._computer.Open();

        _llamaUtil._hwTimer = new System.Timers.Timer(intervalMs);
        _llamaUtil._hwTimer.Elapsed += (s, e) =>
        {
            try
            {
                var info = new HardwareInfo();

                if (_llamaUtil._computer == null) return;

                // 刷新所有硬件信息
                foreach (var hw in _llamaUtil._computer.Hardware)
                    hw.Update();

                // ---------------- CPU ----------------
                var cpu = _llamaUtil._computer.Hardware.FirstOrDefault(h => h.HardwareType == HardwareType.Cpu);
                if (cpu != null)
                {
                    var loadSensor = cpu.Sensors?.FirstOrDefault(s =>s.SensorType == SensorType.Load && s.Name.Contains("CPU Total"));
                    info.CpuUsage = loadSensor?.Value ?? -1;
                }

                // ---------------- GPU ----------------
                var gpu = _llamaUtil._computer.Hardware.FirstOrDefault(h =>
                    h.HardwareType == HardwareType.GpuNvidia || h.HardwareType == HardwareType.GpuAmd || h.HardwareType == HardwareType.GpuIntel);
                if (gpu != null)
                {
                    var loadSensor = gpu.Sensors?.FirstOrDefault(s => s.SensorType == SensorType.Load && s.Name.Contains("GPU Core"));
                    info.GpuUsage = loadSensor?.Value ?? -1;
                }

                // ---------------- 内存 ----------------
                var memory = _llamaUtil._computer.Hardware.FirstOrDefault(h => h.HardwareType == HardwareType.Memory && h.Name.Contains("Total Memory"));
                if (memory != null)
                {
                    var used = memory.Sensors?.FirstOrDefault(s => s.SensorType == SensorType.Data && s.Name.Contains("Memory Used"))?.Value ?? 0;
                    var available = memory.Sensors?.FirstOrDefault(s => s.SensorType == SensorType.Data && s.Name.Contains("Memory Available"))?.Value ?? 0;
                    info.MemoryUsed = used; 
                    info.MemoryTotal = (available + used);
                }


                // ---------------- 显存 ----------------
                if (gpu != null)
                {
                    var vramUsed = gpu.Sensors?.FirstOrDefault(s => s.SensorType == SensorType.SmallData && s.Name.Contains("GPU Memory Used"))?.Value ?? 0;
                    var vramTotal = gpu.Sensors?.FirstOrDefault(s => s.SensorType == SensorType.SmallData && s.Name.Contains("GPU Memory Total"))?.Value ?? 0;
                    info.VramUsed = vramUsed / 1024.0;  // 转为 GB
                    info.VramTotal = vramTotal / 1024.0;
                }

                // ---------------- 文本显示 ----------------
                info.CpuName = cpu != null ? cpu.Name: "N/A";
                info.GpuName = gpu != null ? gpu.Name : "N/A";
                info.CpuText = info.CpuUsage >= 0 ? $"{info.CpuUsage:F0}%" : "N/A";
                info.GpuText = info.GpuUsage >= 0 ? $"{info.GpuUsage:F0}%" : "N/A";
                info.MemoryText = info.MemoryTotal > 0 ? $"{info.MemoryUsed:F1} / {info.MemoryTotal:F1} GB" : "N/A";
                info.VramText = info.VramTotal > 0 ? $"{info.VramUsed:F1} / {info.VramTotal:F1} GB" : "N/A";

                _llamaUtil._hardwareCallback?.Invoke(info);
            }
            catch (Exception ex)
            {
                //_llamaUtil._outputCallback?.Invoke("监控异常: " + ex);
                _ = ex;
            }
        };
        _llamaUtil._hwTimer.AutoReset = true;
        _llamaUtil._hwTimer.Start();
    }

    /// <summary>
    /// 停止硬件监控
    /// </summary>
    public static void StopHardwareMonitor()
    {
        _llamaUtil._monitorRunning = false;
        _llamaUtil._hwTimer?.Stop();
        _llamaUtil._hwTimer?.Dispose();
        _llamaUtil._hwTimer = null;
        _llamaUtil._computer?.Close();
        _llamaUtil._computer = null;
        _llamaUtil._hardwareCallback = null;
    }
}
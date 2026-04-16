using System.Diagnostics;
using System.IO.Compression;
using System.Runtime.InteropServices;

namespace StormLlama.Runtime;

/// <summary>
/// 文件管理工具
/// </summary>
public class FileUtil
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct SHFILEOPSTRUCT
    {
        public IntPtr hwnd;
        public int wFunc;
        public string pFrom;
        public string pTo;
        public int fFlags;
        public bool fAnyOperationsAborted;
        public IntPtr hNameMappings;
        public string lpszProgressTitle;
    }

    private readonly static FileUtil _fileUtil = new();
    private readonly List<ModelData> _modelDataList = [];
    private Action<string>? _outputCallback;


    [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
    private static extern int SHFileOperation(ref SHFILEOPSTRUCT lpFileOp);

    /// <summary>
    /// 设置输出回调
    /// </summary>
    public static void SetOutputCallBack(Action<string>? action)
    {
        _fileUtil._outputCallback = action;
    }

    /// <summary>
    /// 导入llama
    /// </summary>
    public static bool ImportLlama()
    {
        using OpenFileDialog ofd = new();
        ofd.Title = "选择要导入的 llama 压缩包";
        ofd.Filter = "ZIP压缩包 (*.zip)|*.zip|所有文件 (*.*)|*.*";
        ofd.RestoreDirectory = true;

        if (ofd.ShowDialog() != DialogResult.OK)
        {
            return false;
        }

        try
        {
            string zipPath = ofd.FileName;
            string targetDir = ConfigUtil.LlamaCppDir;
            string tempDir = Path.Combine(Path.GetTempPath(), "llama_temp_unzip");

            //清空临时目录
            if (Directory.Exists(tempDir))
                Directory.Delete(tempDir, true);
            Directory.CreateDirectory(tempDir);

            _fileUtil._outputCallback?.Invoke("正在解压压缩包...");

            //解压到临时目录
            ZipFile.ExtractToDirectory(zipPath, tempDir, true);

            _fileUtil._outputCallback?.Invoke("正在部署文件，请稍候...");

            //目标文件夹名称
            string folderName = Path.GetFileNameWithoutExtension(zipPath);
            string finalTargetDir = Path.Combine(targetDir, folderName);

            //清空llama文件夹
            if (Directory.Exists(targetDir))
            {
                foreach (var dir in Directory.GetDirectories(targetDir))
                    Directory.Delete(dir, true);
                foreach (var file in Directory.GetFiles(targetDir))
                    File.Delete(file);
            }
            Directory.CreateDirectory(finalTargetDir);

            //取解压出来的文件/文件夹，移动到目标目录
            string sourcePath = Directory.GetDirectories(tempDir).FirstOrDefault() ?? tempDir;
            bool moveOk = SystemCopyFile(sourcePath + "\\*", finalTargetDir, "部署 Llama 中...");

            if (!moveOk)
            {
                _fileUtil._outputCallback?.Invoke("部署失败，用户取消或异常");
                return false;
            }

            //清理临时文件
            try { Directory.Delete(tempDir, true); } catch { }

            _fileUtil._outputCallback?.Invoke("导入llama成功！");
            return true;
        }
        catch (Exception ex)
        {
            _fileUtil._outputCallback?.Invoke($"导入llama失败：{ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 获取模型列表
    /// </summary>
    public static List<ModelData> GetModelList()
    {
        return _fileUtil._modelDataList;
    }

    /// <summary>
    /// 刷新模型列表
    /// </summary>
    public static void RefreshModelList(bool selectCheck = true)
    {
        _fileUtil._modelDataList.Clear();

        var modelFiles = Directory.GetFiles(ConfigUtil.ModelsDir, "*.gguf", SearchOption.TopDirectoryOnly);
        if (modelFiles.Length != 0)
        {
            foreach (var fullPath in modelFiles)
            {
                string fileName = Path.GetFileName(fullPath);
                _fileUtil._modelDataList.Add(new ModelData
                {
                    DisplayText = TruncateFileName(fileName),
                    FileName = fileName,
                });
            }
        }
        if (selectCheck)
        {
            SelectModel(ConfigUtil.INI_SelectedModel);
            SelectVisualModel(ConfigUtil.INI_SelectedVisualModel);
        }
    }

    /// <summary>
    /// 打开模型目录
    /// </summary>
    public static void OpenModelDir()
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = ConfigUtil.ModelsDir,
                UseShellExecute = true,
                Verb = "open"
            });
        }
        catch (Exception ex)
        {
            _fileUtil._outputCallback?.Invoke($"打开目录失败：{ex.Message}");
        }
    }

    /// <summary>
    /// 导入模型
    /// </summary>
    public static bool ImportModel()
    {
        using OpenFileDialog ofd = new();
        ofd.Title = "选择要导入的GGUF模型";
        ofd.Filter = "GGUF模型文件 (*.gguf)|*.gguf|所有文件 (*.*)|*.*";
        ofd.RestoreDirectory = true;

        if (ofd.ShowDialog() != DialogResult.OK)
        {
            return false;
        }

        string sourceFilePath = ofd.FileName;
        string fileName = Path.GetFileName(sourceFilePath);
        string targetFilePath = Path.Combine(ConfigUtil.ModelsDir, fileName);

        try
        {
            if (File.Exists(targetFilePath))
            {
                var result = MessageBox.Show(
                    $"模型目录中已存在同名文件「{fileName}」，是否覆盖？",
                    "文件已存在",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.No)
                {
                    return false;
                }
            }

            bool copySuccess = SystemCopyFile(sourceFilePath, targetFilePath, "导入模型中...");
            if (!copySuccess)
            {
                return false;
            }
            RefreshModelList(false);
            _fileUtil._outputCallback?.Invoke($"模型导入成功！");
            return true;
        }
        catch (Exception ex)
        {
            _fileUtil._outputCallback?.Invoke($"导入失败：{ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// 选择模型
    /// </summary>
    public static bool SelectModel(string? modelName)
    {
        if (!string.IsNullOrEmpty(modelName))
        {
            var selectItem = _fileUtil._modelDataList.FirstOrDefault(m => m.FileName == modelName);
            if (selectItem != null)
            {
                ConfigUtil.INI_SelectedModel = selectItem.FileName;
                if (CheckModelExist())
                {
                    return true;
                }
            }
        }
        ConfigUtil.INI_SelectedModel = "";
        RefreshModelList(false);
        return false;
    }

    /// <summary>
    /// 选择视觉模型
    /// </summary>
    public static bool SelectVisualModel(string? modelName)
    {
        if (!string.IsNullOrEmpty(modelName))
        {
            var selectItem = _fileUtil._modelDataList.FirstOrDefault(m => m.FileName == modelName);
            if (selectItem != null)
            {
                ConfigUtil.INI_SelectedVisualModel = selectItem.FileName;
                if (CheckModelExist())
                {
                    return true;
                }
            }
        }
        ConfigUtil.INI_SelectedVisualModel = "";
        RefreshModelList(false);
        return false;
    }

    /// <summary>
    /// 检查模型是否存在
    /// </summary>
    public static bool CheckModelExist()
    {
        if (string.IsNullOrEmpty(ConfigUtil.INI_SelectedModel))
        {
            _fileUtil._outputCallback?.Invoke("无选中模型文件！");
            return false;
        }

        if (!File.Exists(ConfigUtil.SelectedModelPath))
        {
            _fileUtil._outputCallback?.Invoke("选中模型文件不存在！");
            return false;
        }

        if (!string.IsNullOrEmpty(ConfigUtil.INI_SelectedVisualModel) && !File.Exists(ConfigUtil.SelectedVisualModelPath))
        {
            _fileUtil._outputCallback?.Invoke("选中视觉模型文件不存在！");
            return false;
        }

        return true;
    }

    /// <summary>
    /// 打开模型目录
    /// </summary>
    public static void OpenAppDir()
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = ConfigUtil.AppDir,
                UseShellExecute = true,
                Verb = "open"
            });
        }
        catch (Exception ex)
        {
            _fileUtil._outputCallback?.Invoke($"打开目录失败：{ex.Message}");
        }
    }

    /// <summary>
    /// 截断文件名
    /// </summary>
    private static string TruncateFileName(string fileName, int maxLength = 30)
    {
        if (string.IsNullOrEmpty(fileName) || fileName.Length <= maxLength)
            return fileName;

        string ext = Path.GetExtension(fileName);
        string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);

        int keepLength = maxLength - ext.Length - 3;
        if (keepLength <= 0) keepLength = 5;

        string prefix = nameWithoutExt.Substring(0, keepLength / 2);
        string suffix = nameWithoutExt.Substring(nameWithoutExt.Length - keepLength / 2);

        return $"{prefix}...{suffix}{ext}";
    }

    /// <summary>
    /// 调用系统自带进度框复制文件
    /// </summary>
    private static bool SystemCopyFile(string src, string dst, string title = "复制中...")
    {
        SHFILEOPSTRUCT sh = new SHFILEOPSTRUCT
        {
            wFunc = 2,
            pFrom = src + "\0",
            pTo = dst + "\0",
            fFlags = 0x710,
            lpszProgressTitle = title
        };

        return SHFileOperation(ref sh) == 0 && !sh.fAnyOperationsAborted;
    }
}
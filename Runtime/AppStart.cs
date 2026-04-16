using System.Diagnostics;
using System.Runtime.InteropServices;

namespace StormLlama.Runtime;

/// <summary>
/// 程序启动
/// </summary>
internal static class AppStart
{
    [STAThread]
    static void Main()
    {
        Mutex mutex = new(true, "{EA8BA28B-2851-44D5-960C-2B6D8FAFB53D}", out bool isNewInstance);

        if (!isNewInstance)
        {
            ActivateHiddenWindow();
            return;
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new UIPanel.UIForm_Main());
    }

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    /// <summary>
    /// 激活已运行的程序窗口
    /// </summary>
    private static void ActivateHiddenWindow()
    {
        var current = Process.GetCurrentProcess();
        var target = Process.GetProcessesByName(current.ProcessName).FirstOrDefault(p => p.Id != current.Id);

        if (target == null) return;

        IntPtr handle = FindWindow(null!, ConfigUtil.FormTitle);

        if (handle == IntPtr.Zero) handle = target.MainWindowHandle;

        if (handle != IntPtr.Zero)
        {
            ShowWindow(handle, 9);
            ShowWindow(handle, 5); 
            SetForegroundWindow(handle);
        }
    }
}

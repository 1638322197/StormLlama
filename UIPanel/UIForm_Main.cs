using StormLlama.Properties;
using StormLlama.Runtime;
using Sunny.UI;
using System.Diagnostics;

namespace StormLlama.UIPanel;

public partial class UIForm_Main : UIForm
{
    private bool _buttonRun = true;
    private bool _needClose = false;

    public UIForm_Main()
    {
        InitializeComponent();
    }

    #region 主窗体
    /// <summary>
    /// 主窗体加载事件
    /// </summary>
    private void UIForm_Main_Load(object sender, EventArgs e)
    {
        this.Text = ConfigUtil.FormTitle;
        AppIcon.Text = ConfigUtil.FormTitle;

        FileUtil.RefreshModelList();
        FileUtil.SetOutputCallBack(AppendLog);
        LlamaUtil.SetOutputCallBack(AppendLog);
        LlamaUtil.SetHardwareInfoCallBack(UpdateStatusPanel);
        LlamaUtil.SetOnLlamaExitCallBack(() => UIBtn_ServiceControlUpdate(true));
        LlamaUtil.StartHardwareMonitor();

        UICbo_ModelSelectRefesh();
        UICbo_VisualModelSelectRefesh();
        UIIntUD_ServicePortRefesh();
        UIIntUD_GPULayerRefresh();
        UIIntUD_ContextLengthRefresh();
        UITextBox_ExtraArgsRefresh();
        UISwitch_MiniOnCloseRefresh();
    }

    /// <summary>
    /// 主窗体关闭前事件
    /// </summary>
    private void UIForm_Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.ActiveControl = null;
        if (!ConfigUtil.INI_MiniOnClose || _needClose)
        {
            LlamaUtil.StopLlama(true);
            LlamaUtil.StopHardwareMonitor();
        }
        else
        {
            e.Cancel = true;
            this.Hide();
        }
    }

    /// <summary>
    /// 鼠标点击窗体时事件
    /// </summary>
    private void UIForm_Main_MouseClick(object sender, MouseEventArgs e)
    {
        this.ActiveControl = null;
    }
    #endregion

    #region 模型配置
    /// <summary>
    /// 模型选择框刷新
    /// </summary>
    private void UICbo_ModelSelectRefesh()
    {
        UICbo_ModelSelect.DataSource = null;
        UICbo_ModelSelect.DataSource = FileUtil.GetModelList();
        UICbo_ModelSelect.DisplayMember = "DisplayText";
        UICbo_ModelSelect.ValueMember = "FileName";
        UICbo_ModelSelect.SelectedValue = ConfigUtil.INI_SelectedModel;
        UICbo_ModelSelect.Refresh();
    }

    /// <summary>
    /// 视觉模型选择框刷新
    /// </summary>
    private void UICbo_VisualModelSelectRefesh()
    {
        var list = FileUtil.GetModelList().ToList();

        list.Insert(0, new ModelData { DisplayText = "<无视觉模型>", FileName = "" });

        UICbo_VisualModelSelect.DataSource = null;
        UICbo_VisualModelSelect.DataSource = list;
        UICbo_VisualModelSelect.DisplayMember = "DisplayText";
        UICbo_VisualModelSelect.ValueMember = "FileName";
        UICbo_VisualModelSelect.SelectedValue = ConfigUtil.INI_SelectedVisualModel;
        UICbo_VisualModelSelect.Refresh();
    }

    /// <summary>
    /// 模型选择框事件
    /// </summary>
    private void UICbo_ModelSelect_SelectionChangeCommitted(object sender, EventArgs e)
    {
        if (!FileUtil.SelectModel((UICbo_ModelSelect.SelectedValue)?.ToString()))
        {
            FileUtil.RefreshModelList();
            UICbo_ModelSelectRefesh();
        }
    }

    /// <summary>
    /// 视觉模型选择框事件
    /// </summary>
    private void UICbo_VisualModelSelect_SelectionChangeCommitted(object sender, EventArgs e)
    {
        if (!FileUtil.SelectVisualModel((UICbo_VisualModelSelect.SelectedValue)?.ToString()))
        {
            FileUtil.RefreshModelList();
            UICbo_VisualModelSelectRefesh();
        }
    }

    /// <summary>
    /// 服务端口刷新
    /// </summary>
    private void UIIntUD_ServicePortRefesh()
    {
        UIIntUD_ServicePort.Value = ConfigUtil.INI_ServicePort;
        UIRTextBox_ApiUrlRefresh();
    }

    /// <summary>
    /// 服务端口输入框事件
    /// </summary>
    private void UIIntUD_ServicePort_ValueChanged(object sender, int value)
    {
        ConfigUtil.INI_ServicePort = UIIntUD_ServicePort.Value;
        UIRTextBox_ApiUrlRefresh();
    }

    /// <summary>
    /// GPU调用层数刷新
    /// </summary>
    private void UIIntUD_GPULayerRefresh()
    {
        UIIntUD_GPULayer.Value = ConfigUtil.INI_GPULayer;
    }

    /// <summary>
    /// GPU调用层数输入框事件
    /// </summary>
    private void UIIntUD_GPULayer_ValueChanged(object sender, int value)
    {
        ConfigUtil.INI_GPULayer = UIIntUD_GPULayer.Value;
    }
  
    /// <summary>
    /// 上下文长度输入框刷新
    /// </summary>
    private void UIIntUD_ContextLengthRefresh()
    {
        UIIntUD_ContextLength.Value = ConfigUtil.INI_ContextLength_k;
    }

    /// <summary>
    /// 上下文长度输入框事件
    /// </summary>
    private void UIIntUD_ContextLength_ValueChanged(object sender, int value)
    {
        ConfigUtil.INI_ContextLength_k = UIIntUD_ContextLength.Value;
    }

    /// <summary>
    /// Api地址刷新
    /// </summary>
    private void UIRTextBox_ApiUrlRefresh()
    {
        UIRTextBox_ApiUrl.Text = ConfigUtil.INI_ApiUrl;
    }

    /// <summary>
    /// Api地址点击跳转
    /// </summary>
    private void UIRTextBox_ApiUrl_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = e.LinkText,
                UseShellExecute = true
            };
            Process.Start(psi);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"无法打开链接: {ex.Message}", "跳转失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// 额外命令行参数刷新
    /// </summary>
    private void UITextBox_ExtraArgsRefresh()
    {
        UITextBox_ExtraArgs.Text = ConfigUtil.INI_ExtraArgs;
    }

    /// <summary>
    /// 额外命令行参数输入框事件
    /// </summary>
    private void UITextBox_ExtraArgs_TextChanged(object sender, EventArgs e)
    {
        ConfigUtil.INI_ExtraArgs = UITextBox_ExtraArgs.Text;
    }
    #endregion

    #region 状态面板
    /// <summary>
    /// 更新状态面板
    /// </summary>
    private void UpdateStatusPanel(LlamaUtil.HardwareInfo hw)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => UpdateStatusPanel(hw));
            return;
        }

        UILabel_CPUName.Text = hw.CpuName;
        UILabel_GPUName.Text = hw.GpuName;
        UILabel_CPUUsage.Text = hw.CpuText;
        UILabel_GPUUsage.Text = hw.GpuText;
        UILabel_CPUMemory.Text = hw.MemoryText;
        UILabel_GPUMemory.Text = hw.VramText;
    }
    #endregion

    #region 操作面板
    /// <summary>
    /// GitHub仓库地址按钮事件
    /// </summary>
    private void UIBtn_GitUrl_Click(object sender, EventArgs e)
    {
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = ConfigUtil.GitUrl,
                UseShellExecute = true
            };
            Process.Start(psi);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"无法打开链接: {ex.Message}", "跳转失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// 模型目录按钮事件
    /// </summary>
    private void UIBtn_OpenModelDir_Click(object sender, EventArgs e)
    {
        FileUtil.OpenModelDir();
    }

    /// <summary>
    /// 模型导入按钮事件
    /// </summary>
    private void UIBtn_ModelImport_Click(object sender, EventArgs e)
    {
        var result = FileUtil.ImportModel();
        if (result)
        {
            UICbo_ModelSelectRefesh();
            UICbo_VisualModelSelectRefesh();
        }
    }

    /// <summary>
    /// 刷新模型列表按钮事件
    /// </summary>
    private void UIBtn_Refesh_Click(object sender, EventArgs e)
    {
        FileUtil.RefreshModelList();
        UICbo_ModelSelectRefesh();
        UICbo_VisualModelSelectRefesh();
    }

    /// <summary>
    /// 导入Llama按钮事件
    /// </summary>
    private void UIBtn_ImportLlama_Click(object sender, EventArgs e)
    {
        FileUtil.ImportLlama();
    }

    /// <summary>
    /// 打开程序目录按钮事件
    /// </summary>
    private void UIBtn_OpenAppDir_Click(object sender, EventArgs e)
    {
        FileUtil.OpenAppDir();
    }

    /// <summary>
    /// 关闭时最小化切换刷新
    /// </summary>
    private void UISwitch_MiniOnCloseRefresh()
    {
        UISwitch_MiniOnClose.Active = ConfigUtil.INI_MiniOnClose;
    }

    /// <summary>
    /// 关闭时最小化切换事件
    /// </summary>
    private void UISwitch_MiniOnClose_ValueChanged(object sender, bool value)
    {
        ConfigUtil.INI_MiniOnClose = UISwitch_MiniOnClose.Active;
    }
    #endregion

    #region 服务启停与日志
    /// <summary>
    /// 追加日志到界面
    /// </summary>
    private void AppendLog(string? log)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => AppendLog(log));
            return;
        }

        const int maxLines = 500;
        if (UIRTextBox_Log.Lines.Length >= maxLines)
        {
            UIRTextBox_Log.Lines = [.. UIRTextBox_Log.Lines.Skip(1)];
        }
        UIRTextBox_Log.AppendText($"[{DateTime.Now:HH:mm:ss}] {log}\n");
        UIRTextBox_Log.SelectionStart = UIRTextBox_Log.TextLength;
        UIRTextBox_Log.ScrollToCaret();
    }

    /// <summary>
    /// 启动/停止服务按钮点击事件
    /// </summary>
    private void UIBtn_ServiceControl_Click(object sender, EventArgs e)
    {
        if (_buttonRun)
        {
            UIRTextBox_Log.Text = string.Empty;

            // 构建启动参数启动服务
            string llamaServerPath = ConfigUtil.LlamaServerPath;
            string modelPath = ConfigUtil.SelectedModelPath;
            string visualModelPath = string.IsNullOrWhiteSpace(ConfigUtil.INI_SelectedVisualModel) ? "" : ConfigUtil.SelectedVisualModelPath;
            int port = ConfigUtil.INI_ServicePort;
            int gpuLayer = ConfigUtil.INI_GPULayer;
            int ctxLen = ConfigUtil.INI_ContextLength_k * 1024;
            string extra = ConfigUtil.INI_ExtraArgs_Clean;
            bool success = LlamaUtil.StartLlama(llamaServerPath, modelPath, visualModelPath, port, gpuLayer, ctxLen, extra);
            UIBtn_ServiceControlUpdate(!success);
        }
        else
        {
            UIBtn_ServiceControlUpdate(true);
            LlamaUtil.StopLlama();
        }

    }

    /// <summary>
    /// 启动/停止服务按钮更新
    /// </summary>
    private void UIBtn_ServiceControlUpdate(bool buttonRun)
    {
        if (InvokeRequired)
        {
            BeginInvoke(() => UIBtn_ServiceControlUpdate(buttonRun));
            return;
        }

        if (_buttonRun == buttonRun)
            return;

        _buttonRun = buttonRun;
        if (_buttonRun)
        {
            UIBtn_ServiceControl.Text = "启动";
            UILabel_RunStatus.Text = "已停止";
            UILabel_RunStatus.ForeColor = Color.DarkRed;
            AppIcon.Icon = Resources.ModelOff;
        }
        else
        {
            UIBtn_ServiceControl.Text = "停止";
            UILabel_RunStatus.Text = "运行中";
            UILabel_RunStatus.ForeColor = Color.Green;
            AppIcon.Icon = Resources.ModelOn;
        }
    }

    /// <summary>
    /// 清理所有后台llama进程按钮事件
    /// </summary>
    private void UIBtn_KillAllLlamaServer_Click(object sender, EventArgs e)
    {
        LlamaUtil.KillAllLlamaServer();
        UIBtn_ServiceControlUpdate(true);
    }

    /// <summary>
    /// 清除日志按钮事件
    /// </summary>
    private void UIBtn_ClearLog_Click(object sender, EventArgs e)
    {
        UIRTextBox_Log.Text = string.Empty;
    }
    #endregion

    #region Icon相关
    /// <summary>
    /// Icon菜单退出事件
    /// </summary>
    private void IconMenu_Exit_Click(object sender, EventArgs e)
    {
        _needClose = true;
        this.Close();
    }

    /// <summary>
    /// Icon点击事件
    /// </summary>
    private void AppIcon_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
    }
    #endregion
}


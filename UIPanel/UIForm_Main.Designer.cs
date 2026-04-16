using System;
using StormLlama.Properties;
using StormLlama.Runtime;
using Sunny.UI;

namespace StormLlama.UIPanel;

partial class UIForm_Main
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        UILabel_ModelSelect = new UILabel();
        UICbo_ModelSelect = new UIComboBox();
        UIBtn_ModelImport = new UIButton();
        UIBtn_OpenModelDir = new UIButton();
        UIBtn_Refesh = new UIButton();
        UILabel_ServicePort = new UILabel();
        UIIntUD_ServicePort = new UIIntegerUpDown();
        UILabel_GPULayer = new UILabel();
        UIIntUD_GPULayer = new UIIntegerUpDown();
        UILabel_ContextLength = new UILabel();
        UIIntUD_ContextLength = new UIIntegerUpDown();
        UILabel_ApiUrl = new UILabel();
        UILabel_ExtraArgs = new UILabel();
        UITextBox_ExtraArgs = new UITextBox();
        UIBtn_ServiceControl = new UIButton();
        UIRTextBox_Log = new UIRichTextBox();
        UILabel_Log = new UILabel();
        UIBtn_ClearLog = new UIButton();
        UILabel_RunStatusText = new UILabel();
        UILabel_RunStatus = new UILabel();
        UISwitch_MiniOnClose = new UISwitch();
        UIRTextBox_ApiUrl = new UIRichTextBox();
        IconMenu = new UIContextMenuStrip(components);
        IconMenu_Exit = new ToolStripMenuItem();
        AppIcon = new NotifyIcon(components);
        UIBtn_KillAllLlamaServer = new UIButton();
        UIStyleManager = new UIStyleManager(components);
        UIBtn_ImportLlama = new UIButton();
        UIBtn_OpenAppDir = new UIButton();
        UIPanel_Status = new Sunny.UI.UIPanel();
        UIPanel_GPU = new Sunny.UI.UIPanel();
        UILabel_GPUName = new UILabel();
        UILabel_GPUNameTag = new UILabel();
        UILabel_GPUUsage = new UILabel();
        UILabel_GPUMemory = new UILabel();
        UILabel_GPUMemoryTag = new UILabel();
        UILabel_GPUUsageTag = new UILabel();
        UIPanel_CPU = new Sunny.UI.UIPanel();
        UILabel_CPUName = new UILabel();
        UILabel_CPUNameTag = new UILabel();
        UILabel_CPUUsage = new UILabel();
        UILabel_CPUMemory = new UILabel();
        UILabel_CPUMemoryTag = new UILabel();
        UILabel_CPUUsageTag = new UILabel();
        uiPanel1 = new Sunny.UI.UIPanel();
        UICbo_VisualModelSelect = new UIComboBox();
        UILabel_VisualModelSelect = new UILabel();
        uiPanel2 = new Sunny.UI.UIPanel();
        IconMenu.SuspendLayout();
        UIPanel_Status.SuspendLayout();
        UIPanel_GPU.SuspendLayout();
        UIPanel_CPU.SuspendLayout();
        uiPanel1.SuspendLayout();
        uiPanel2.SuspendLayout();
        SuspendLayout();
        // 
        // UILabel_ModelSelect
        // 
        UILabel_ModelSelect.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_ModelSelect.ForeColor = Color.White;
        UILabel_ModelSelect.Location = new Point(10, 30);
        UILabel_ModelSelect.Name = "UILabel_ModelSelect";
        UILabel_ModelSelect.Size = new Size(380, 20);
        UILabel_ModelSelect.TabIndex = 18;
        UILabel_ModelSelect.Text = "模型文件 (.gguf):";
        UILabel_ModelSelect.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UICbo_ModelSelect
        // 
        UICbo_ModelSelect.DataSource = null;
        UICbo_ModelSelect.DisplayMember = "DisplayText";
        UICbo_ModelSelect.DropDownStyle = UIDropDownStyle.DropDownList;
        UICbo_ModelSelect.FillColor = Color.FromArgb(24, 24, 24);
        UICbo_ModelSelect.FillColor2 = Color.FromArgb(24, 24, 24);
        UICbo_ModelSelect.FillDisableColor = Color.Silver;
        UICbo_ModelSelect.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UICbo_ModelSelect.ForeColor = Color.White;
        UICbo_ModelSelect.ForeDisableColor = Color.Silver;
        UICbo_ModelSelect.ItemFillColor = Color.FromArgb(24, 24, 24);
        UICbo_ModelSelect.ItemForeColor = Color.White;
        UICbo_ModelSelect.ItemHoverColor = Color.FromArgb(155, 200, 255);
        UICbo_ModelSelect.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
        UICbo_ModelSelect.Location = new Point(10, 55);
        UICbo_ModelSelect.Margin = new Padding(4, 5, 4, 5);
        UICbo_ModelSelect.MinimumSize = new Size(63, 0);
        UICbo_ModelSelect.Name = "UICbo_ModelSelect";
        UICbo_ModelSelect.Padding = new Padding(0, 0, 30, 2);
        UICbo_ModelSelect.RectSize = 2;
        UICbo_ModelSelect.ScrollBarHandleWidth = 4;
        UICbo_ModelSelect.Size = new Size(380, 30);
        UICbo_ModelSelect.SymbolSize = 24;
        UICbo_ModelSelect.TabIndex = 19;
        UICbo_ModelSelect.TextAlignment = ContentAlignment.MiddleLeft;
        UICbo_ModelSelect.ValueMember = "FileName";
        UICbo_ModelSelect.Watermark = "";
        UICbo_ModelSelect.WatermarkActiveColor = Color.White;
        UICbo_ModelSelect.WatermarkColor = Color.White;
        UICbo_ModelSelect.SelectionChangeCommitted += UICbo_ModelSelect_SelectionChangeCommitted;
        // 
        // UIBtn_ModelImport
        // 
        UIBtn_ModelImport.FillColor = Color.FromArgb(24, 24, 24);
        UIBtn_ModelImport.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_ModelImport.Location = new Point(200, 62);
        UIBtn_ModelImport.MinimumSize = new Size(1, 1);
        UIBtn_ModelImport.Name = "UIBtn_ModelImport";
        UIBtn_ModelImport.RectSize = 2;
        UIBtn_ModelImport.Size = new Size(120, 40);
        UIBtn_ModelImport.TabIndex = 1;
        UIBtn_ModelImport.Text = "导入模型";
        UIBtn_ModelImport.TipsFont = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_ModelImport.TipsForeColor = Color.Black;
        UIBtn_ModelImport.Click += UIBtn_ModelImport_Click;
        // 
        // UIBtn_OpenModelDir
        // 
        UIBtn_OpenModelDir.FillColor = Color.FromArgb(24, 24, 24);
        UIBtn_OpenModelDir.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_OpenModelDir.Location = new Point(74, 62);
        UIBtn_OpenModelDir.MinimumSize = new Size(1, 1);
        UIBtn_OpenModelDir.Name = "UIBtn_OpenModelDir";
        UIBtn_OpenModelDir.RectSize = 2;
        UIBtn_OpenModelDir.Size = new Size(120, 40);
        UIBtn_OpenModelDir.TabIndex = 20;
        UIBtn_OpenModelDir.Text = "模型目录";
        UIBtn_OpenModelDir.TipsFont = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_OpenModelDir.TipsForeColor = Color.Black;
        UIBtn_OpenModelDir.Click += UIBtn_OpenModelDir_Click;
        // 
        // UIBtn_Refesh
        // 
        UIBtn_Refesh.FillColor = Color.FromArgb(24, 24, 24);
        UIBtn_Refesh.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_Refesh.Location = new Point(326, 62);
        UIBtn_Refesh.MinimumSize = new Size(1, 1);
        UIBtn_Refesh.Name = "UIBtn_Refesh";
        UIBtn_Refesh.RectSize = 2;
        UIBtn_Refesh.Size = new Size(150, 40);
        UIBtn_Refesh.TabIndex = 21;
        UIBtn_Refesh.Text = "刷新模型列表";
        UIBtn_Refesh.TipsFont = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_Refesh.TipsForeColor = Color.Black;
        UIBtn_Refesh.Click += UIBtn_Refesh_Click;
        // 
        // UILabel_ServicePort
        // 
        UILabel_ServicePort.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_ServicePort.ForeColor = Color.White;
        UILabel_ServicePort.Location = new Point(10, 155);
        UILabel_ServicePort.Name = "UILabel_ServicePort";
        UILabel_ServicePort.Size = new Size(142, 30);
        UILabel_ServicePort.TabIndex = 22;
        UILabel_ServicePort.Text = "服务端口:";
        UILabel_ServicePort.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UIIntUD_ServicePort
        // 
        UIIntUD_ServicePort.FillColor = Color.FromArgb(24, 24, 24);
        UIIntUD_ServicePort.FillColor2 = Color.FromArgb(24, 24, 24);
        UIIntUD_ServicePort.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIIntUD_ServicePort.ForeColor = Color.White;
        UIIntUD_ServicePort.Location = new Point(159, 155);
        UIIntUD_ServicePort.Margin = new Padding(4, 5, 4, 5);
        UIIntUD_ServicePort.Maximum = 65535D;
        UIIntUD_ServicePort.Minimum = 1D;
        UIIntUD_ServicePort.MinimumSize = new Size(1, 16);
        UIIntUD_ServicePort.Name = "UIIntUD_ServicePort";
        UIIntUD_ServicePort.Padding = new Padding(5);
        UIIntUD_ServicePort.RectSize = 2;
        UIIntUD_ServicePort.ShowText = false;
        UIIntUD_ServicePort.Size = new Size(231, 30);
        UIIntUD_ServicePort.Style = UIStyle.Custom;
        UIIntUD_ServicePort.TabIndex = 23;
        UIIntUD_ServicePort.Text = "8989";
        UIIntUD_ServicePort.TextAlignment = ContentAlignment.MiddleCenter;
        UIIntUD_ServicePort.Value = 8989;
        UIIntUD_ServicePort.ValueChanged += UIIntUD_ServicePort_ValueChanged;
        // 
        // UILabel_GPULayer
        // 
        UILabel_GPULayer.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_GPULayer.ForeColor = Color.White;
        UILabel_GPULayer.Location = new Point(10, 195);
        UILabel_GPULayer.Name = "UILabel_GPULayer";
        UILabel_GPULayer.Size = new Size(142, 30);
        UILabel_GPULayer.TabIndex = 24;
        UILabel_GPULayer.Text = "GPU调用层数:";
        UILabel_GPULayer.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UIIntUD_GPULayer
        // 
        UIIntUD_GPULayer.FillColor = Color.FromArgb(24, 24, 24);
        UIIntUD_GPULayer.FillColor2 = Color.FromArgb(24, 24, 24);
        UIIntUD_GPULayer.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIIntUD_GPULayer.ForeColor = Color.White;
        UIIntUD_GPULayer.Location = new Point(159, 195);
        UIIntUD_GPULayer.Margin = new Padding(4, 5, 4, 5);
        UIIntUD_GPULayer.Maximum = 100D;
        UIIntUD_GPULayer.Minimum = 0D;
        UIIntUD_GPULayer.MinimumSize = new Size(1, 16);
        UIIntUD_GPULayer.Name = "UIIntUD_GPULayer";
        UIIntUD_GPULayer.Padding = new Padding(5);
        UIIntUD_GPULayer.RectSize = 2;
        UIIntUD_GPULayer.ShowText = false;
        UIIntUD_GPULayer.Size = new Size(231, 30);
        UIIntUD_GPULayer.Style = UIStyle.Custom;
        UIIntUD_GPULayer.TabIndex = 24;
        UIIntUD_GPULayer.Text = "100";
        UIIntUD_GPULayer.TextAlignment = ContentAlignment.MiddleCenter;
        UIIntUD_GPULayer.Value = 100;
        UIIntUD_GPULayer.ValueChanged += UIIntUD_GPULayer_ValueChanged;
        // 
        // UILabel_ContextLength
        // 
        UILabel_ContextLength.BackColor = Color.FromArgb(24, 24, 24);
        UILabel_ContextLength.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_ContextLength.ForeColor = Color.White;
        UILabel_ContextLength.Location = new Point(10, 235);
        UILabel_ContextLength.Name = "UILabel_ContextLength";
        UILabel_ContextLength.Size = new Size(142, 30);
        UILabel_ContextLength.Style = UIStyle.Custom;
        UILabel_ContextLength.TabIndex = 27;
        UILabel_ContextLength.Text = "上下文长度(k):";
        UILabel_ContextLength.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UIIntUD_ContextLength
        // 
        UIIntUD_ContextLength.FillColor = Color.FromArgb(24, 24, 24);
        UIIntUD_ContextLength.FillColor2 = Color.FromArgb(24, 24, 24);
        UIIntUD_ContextLength.FillDisableColor = Color.FromArgb(24, 24, 24);
        UIIntUD_ContextLength.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIIntUD_ContextLength.ForeColor = Color.White;
        UIIntUD_ContextLength.ForeDisableColor = Color.Silver;
        UIIntUD_ContextLength.Location = new Point(159, 235);
        UIIntUD_ContextLength.Margin = new Padding(4, 5, 4, 5);
        UIIntUD_ContextLength.Maximum = 128D;
        UIIntUD_ContextLength.Minimum = 1D;
        UIIntUD_ContextLength.MinimumSize = new Size(1, 16);
        UIIntUD_ContextLength.Name = "UIIntUD_ContextLength";
        UIIntUD_ContextLength.Padding = new Padding(5);
        UIIntUD_ContextLength.RectSize = 2;
        UIIntUD_ContextLength.ShowText = false;
        UIIntUD_ContextLength.Size = new Size(231, 30);
        UIIntUD_ContextLength.Style = UIStyle.Custom;
        UIIntUD_ContextLength.TabIndex = 25;
        UIIntUD_ContextLength.Text = "32";
        UIIntUD_ContextLength.TextAlignment = ContentAlignment.MiddleCenter;
        UIIntUD_ContextLength.Value = 32;
        UIIntUD_ContextLength.ValueChanged += UIIntUD_ContextLength_ValueChanged;
        // 
        // UILabel_ApiUrl
        // 
        UILabel_ApiUrl.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_ApiUrl.ForeColor = Color.White;
        UILabel_ApiUrl.Location = new Point(10, 275);
        UILabel_ApiUrl.Name = "UILabel_ApiUrl";
        UILabel_ApiUrl.Size = new Size(142, 30);
        UILabel_ApiUrl.TabIndex = 28;
        UILabel_ApiUrl.Text = "Api地址:";
        UILabel_ApiUrl.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UILabel_ExtraArgs
        // 
        UILabel_ExtraArgs.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_ExtraArgs.ForeColor = Color.White;
        UILabel_ExtraArgs.Location = new Point(10, 315);
        UILabel_ExtraArgs.Name = "UILabel_ExtraArgs";
        UILabel_ExtraArgs.Size = new Size(130, 20);
        UILabel_ExtraArgs.TabIndex = 30;
        UILabel_ExtraArgs.Text = "额外命令行参数:";
        UILabel_ExtraArgs.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UITextBox_ExtraArgs
        // 
        UITextBox_ExtraArgs.FillColor = Color.FromArgb(24, 24, 24);
        UITextBox_ExtraArgs.FillReadOnlyColor = Color.FromArgb(24, 24, 24);
        UITextBox_ExtraArgs.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UITextBox_ExtraArgs.ForeColor = Color.White;
        UITextBox_ExtraArgs.ForeReadOnlyColor = Color.White;
        UITextBox_ExtraArgs.Location = new Point(10, 340);
        UITextBox_ExtraArgs.Margin = new Padding(4, 5, 4, 5);
        UITextBox_ExtraArgs.MinimumSize = new Size(1, 16);
        UITextBox_ExtraArgs.Multiline = true;
        UITextBox_ExtraArgs.Name = "UITextBox_ExtraArgs";
        UITextBox_ExtraArgs.Padding = new Padding(5);
        UITextBox_ExtraArgs.RectReadOnlyColor = Color.FromArgb(80, 160, 255);
        UITextBox_ExtraArgs.RectSize = 2;
        UITextBox_ExtraArgs.ShowText = false;
        UITextBox_ExtraArgs.Size = new Size(380, 162);
        UITextBox_ExtraArgs.TabIndex = 31;
        UITextBox_ExtraArgs.TextAlignment = ContentAlignment.TopLeft;
        UITextBox_ExtraArgs.Watermark = "例如:-c 4096 --temp 0.7 --top_p 0.9";
        UITextBox_ExtraArgs.WatermarkActiveColor = Color.FromArgb(64, 64, 64);
        UITextBox_ExtraArgs.WatermarkColor = Color.FromArgb(64, 64, 64);
        UITextBox_ExtraArgs.TextChanged += UITextBox_ExtraArgs_TextChanged;
        // 
        // UIBtn_ServiceControl
        // 
        UIBtn_ServiceControl.FillColor = Color.FromArgb(24, 24, 24);
        UIBtn_ServiceControl.FillDisableColor = Color.FromArgb(24, 24, 24);
        UIBtn_ServiceControl.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_ServiceControl.ForeDisableColor = Color.White;
        UIBtn_ServiceControl.Location = new Point(880, 694);
        UIBtn_ServiceControl.MinimumSize = new Size(1, 1);
        UIBtn_ServiceControl.Name = "UIBtn_ServiceControl";
        UIBtn_ServiceControl.RectDisableColor = Color.FromArgb(80, 160, 255);
        UIBtn_ServiceControl.RectSize = 2;
        UIBtn_ServiceControl.Size = new Size(100, 86);
        UIBtn_ServiceControl.TabIndex = 32;
        UIBtn_ServiceControl.Text = "启动";
        UIBtn_ServiceControl.TipsFont = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_ServiceControl.TipsForeColor = Color.Black;
        UIBtn_ServiceControl.Click += UIBtn_ServiceControl_Click;
        // 
        // UIRTextBox_Log
        // 
        UIRTextBox_Log.FillColor = Color.FromArgb(24, 24, 24);
        UIRTextBox_Log.Font = new Font("微软雅黑", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIRTextBox_Log.ForeColor = Color.White;
        UIRTextBox_Log.Location = new Point(20, 602);
        UIRTextBox_Log.Margin = new Padding(4, 5, 4, 5);
        UIRTextBox_Log.MinimumSize = new Size(1, 1);
        UIRTextBox_Log.Name = "UIRTextBox_Log";
        UIRTextBox_Log.Padding = new Padding(2);
        UIRTextBox_Log.ReadOnly = true;
        UIRTextBox_Log.RectSize = 2;
        UIRTextBox_Log.ShowText = false;
        UIRTextBox_Log.Size = new Size(853, 178);
        UIRTextBox_Log.TabIndex = 33;
        UIRTextBox_Log.TextAlignment = ContentAlignment.MiddleCenter;
        // 
        // UILabel_Log
        // 
        UILabel_Log.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_Log.ForeColor = Color.White;
        UILabel_Log.Location = new Point(20, 577);
        UILabel_Log.Name = "UILabel_Log";
        UILabel_Log.Size = new Size(130, 20);
        UILabel_Log.TabIndex = 34;
        UILabel_Log.Text = "输出日志:";
        UILabel_Log.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UIBtn_ClearLog
        // 
        UIBtn_ClearLog.FillColor = Color.FromArgb(24, 24, 24);
        UIBtn_ClearLog.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_ClearLog.Location = new Point(880, 602);
        UIBtn_ClearLog.MinimumSize = new Size(1, 1);
        UIBtn_ClearLog.Name = "UIBtn_ClearLog";
        UIBtn_ClearLog.RectSize = 2;
        UIBtn_ClearLog.Size = new Size(100, 40);
        UIBtn_ClearLog.TabIndex = 35;
        UIBtn_ClearLog.Text = "清除日志";
        UIBtn_ClearLog.TipsFont = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_ClearLog.TipsForeColor = Color.Black;
        UIBtn_ClearLog.Click += UIBtn_ClearLog_Click;
        // 
        // UILabel_RunStatusText
        // 
        UILabel_RunStatusText.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_RunStatusText.ForeColor = Color.White;
        UILabel_RunStatusText.Location = new Point(202, 47);
        UILabel_RunStatusText.Name = "UILabel_RunStatusText";
        UILabel_RunStatusText.Size = new Size(80, 20);
        UILabel_RunStatusText.TabIndex = 36;
        UILabel_RunStatusText.Text = "运行状态:";
        UILabel_RunStatusText.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UILabel_RunStatus
        // 
        UILabel_RunStatus.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_RunStatus.ForeColor = Color.DarkRed;
        UILabel_RunStatus.Location = new Point(288, 47);
        UILabel_RunStatus.Name = "UILabel_RunStatus";
        UILabel_RunStatus.Size = new Size(59, 20);
        UILabel_RunStatus.TabIndex = 37;
        UILabel_RunStatus.Text = "已停止";
        UILabel_RunStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UISwitch_MiniOnClose
        // 
        UISwitch_MiniOnClose.ActiveText = "退出时最小化";
        UISwitch_MiniOnClose.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UISwitch_MiniOnClose.InActiveText = "退出时关闭";
        UISwitch_MiniOnClose.Location = new Point(326, 108);
        UISwitch_MiniOnClose.MinimumSize = new Size(1, 1);
        UISwitch_MiniOnClose.Name = "UISwitch_MiniOnClose";
        UISwitch_MiniOnClose.RectSize = 2;
        UISwitch_MiniOnClose.Size = new Size(150, 40);
        UISwitch_MiniOnClose.SwitchShape = UISwitch.UISwitchShape.Square;
        UISwitch_MiniOnClose.TabIndex = 38;
        UISwitch_MiniOnClose.ValueChanged += UISwitch_MiniOnClose_ValueChanged;
        // 
        // UIRTextBox_ApiUrl
        // 
        UIRTextBox_ApiUrl.FillColor = Color.FromArgb(24, 24, 24);
        UIRTextBox_ApiUrl.Font = new Font("微软雅黑", 9F, FontStyle.Bold);
        UIRTextBox_ApiUrl.ForeColor = Color.White;
        UIRTextBox_ApiUrl.Location = new Point(159, 275);
        UIRTextBox_ApiUrl.Margin = new Padding(4, 5, 4, 5);
        UIRTextBox_ApiUrl.MinimumSize = new Size(1, 1);
        UIRTextBox_ApiUrl.Name = "UIRTextBox_ApiUrl";
        UIRTextBox_ApiUrl.Padding = new Padding(5, 2, 2, 2);
        UIRTextBox_ApiUrl.ReadOnly = true;
        UIRTextBox_ApiUrl.RectSize = 2;
        UIRTextBox_ApiUrl.ShowText = false;
        UIRTextBox_ApiUrl.Size = new Size(231, 30);
        UIRTextBox_ApiUrl.TabIndex = 34;
        UIRTextBox_ApiUrl.Text = "http://127.0.0.1:8989";
        UIRTextBox_ApiUrl.TextAlignment = ContentAlignment.MiddleCenter;
        UIRTextBox_ApiUrl.LinkClicked += UIRTextBox_ApiUrl_LinkClicked;
        // 
        // IconMenu
        // 
        IconMenu.BackColor = Color.FromArgb(24, 24, 24);
        IconMenu.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        IconMenu.ImageScalingSize = new Size(20, 20);
        IconMenu.Items.AddRange(new ToolStripItem[] { IconMenu_Exit });
        IconMenu.Name = "UIContextMenuStrip";
        IconMenu.ShowImageMargin = false;
        IconMenu.Size = new Size(84, 28);
        // 
        // IconMenu_Exit
        // 
        IconMenu_Exit.BackColor = Color.FromArgb(24, 24, 24);
        IconMenu_Exit.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        IconMenu_Exit.ForeColor = Color.White;
        IconMenu_Exit.Name = "IconMenu_Exit";
        IconMenu_Exit.Size = new Size(83, 24);
        IconMenu_Exit.Text = "退出";
        IconMenu_Exit.Click += IconMenu_Exit_Click;
        // 
        // AppIcon
        // 
        AppIcon.ContextMenuStrip = IconMenu;
        AppIcon.Icon = Resources.ModelOff;
        AppIcon.Text = "Llamacpp启动器";
        AppIcon.Visible = true;
        AppIcon.MouseClick += AppIcon_MouseClick;
        // 
        // UIBtn_KillAllLlamaServer
        // 
        UIBtn_KillAllLlamaServer.FillColor = Color.FromArgb(24, 24, 24);
        UIBtn_KillAllLlamaServer.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_KillAllLlamaServer.Location = new Point(880, 648);
        UIBtn_KillAllLlamaServer.MinimumSize = new Size(1, 1);
        UIBtn_KillAllLlamaServer.Name = "UIBtn_KillAllLlamaServer";
        UIBtn_KillAllLlamaServer.RectSize = 2;
        UIBtn_KillAllLlamaServer.Size = new Size(100, 40);
        UIBtn_KillAllLlamaServer.TabIndex = 40;
        UIBtn_KillAllLlamaServer.Text = "结束llama";
        UIBtn_KillAllLlamaServer.TipsFont = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_KillAllLlamaServer.TipsForeColor = Color.Black;
        UIBtn_KillAllLlamaServer.Click += UIBtn_KillAllLlamaServer_Click;
        // 
        // UIStyleManager
        // 
        UIStyleManager.DPIScale = true;
        UIStyleManager.GlobalFont = true;
        UIStyleManager.GlobalFontName = "微软雅黑";
        UIStyleManager.GlobalFontScale = 125;
        // 
        // UIBtn_ImportLlama
        // 
        UIBtn_ImportLlama.FillColor = Color.FromArgb(24, 24, 24);
        UIBtn_ImportLlama.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_ImportLlama.Location = new Point(74, 108);
        UIBtn_ImportLlama.MinimumSize = new Size(1, 1);
        UIBtn_ImportLlama.Name = "UIBtn_ImportLlama";
        UIBtn_ImportLlama.RectSize = 2;
        UIBtn_ImportLlama.Size = new Size(120, 40);
        UIBtn_ImportLlama.TabIndex = 41;
        UIBtn_ImportLlama.Text = "导入llama";
        UIBtn_ImportLlama.TipsFont = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_ImportLlama.TipsForeColor = Color.Black;
        UIBtn_ImportLlama.Click += UIBtn_ImportLlama_Click;
        // 
        // UIBtn_OpenAppDir
        // 
        UIBtn_OpenAppDir.FillColor = Color.FromArgb(24, 24, 24);
        UIBtn_OpenAppDir.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_OpenAppDir.Location = new Point(200, 108);
        UIBtn_OpenAppDir.MinimumSize = new Size(1, 1);
        UIBtn_OpenAppDir.Name = "UIBtn_OpenAppDir";
        UIBtn_OpenAppDir.RectSize = 2;
        UIBtn_OpenAppDir.Size = new Size(120, 40);
        UIBtn_OpenAppDir.TabIndex = 42;
        UIBtn_OpenAppDir.Text = "程序目录";
        UIBtn_OpenAppDir.TipsFont = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIBtn_OpenAppDir.TipsForeColor = Color.Black;
        UIBtn_OpenAppDir.Click += UIBtn_OpenAppDir_Click;
        // 
        // UIPanel_Status
        // 
        UIPanel_Status.Controls.Add(UIPanel_GPU);
        UIPanel_Status.Controls.Add(UIPanel_CPU);
        UIPanel_Status.Controls.Add(UILabel_RunStatusText);
        UIPanel_Status.Controls.Add(UILabel_RunStatus);
        UIPanel_Status.FillColor = Color.FromArgb(24, 24, 24);
        UIPanel_Status.FillColor2 = Color.FromArgb(24, 24, 24);
        UIPanel_Status.Font = new Font("微软雅黑", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIPanel_Status.ForeColor = Color.White;
        UIPanel_Status.Location = new Point(428, 60);
        UIPanel_Status.Margin = new Padding(4, 5, 4, 5);
        UIPanel_Status.MinimumSize = new Size(1, 1);
        UIPanel_Status.Name = "UIPanel_Status";
        UIPanel_Status.RectSize = 2;
        UIPanel_Status.Size = new Size(552, 295);
        UIPanel_Status.TabIndex = 43;
        UIPanel_Status.Text = "状态面板";
        UIPanel_Status.TextAlignment = ContentAlignment.TopCenter;
        // 
        // UIPanel_GPU
        // 
        UIPanel_GPU.Controls.Add(UILabel_GPUName);
        UIPanel_GPU.Controls.Add(UILabel_GPUNameTag);
        UIPanel_GPU.Controls.Add(UILabel_GPUUsage);
        UIPanel_GPU.Controls.Add(UILabel_GPUMemory);
        UIPanel_GPU.Controls.Add(UILabel_GPUMemoryTag);
        UIPanel_GPU.Controls.Add(UILabel_GPUUsageTag);
        UIPanel_GPU.FillColor = Color.FromArgb(24, 24, 24);
        UIPanel_GPU.FillColor2 = Color.FromArgb(24, 24, 24);
        UIPanel_GPU.Font = new Font("微软雅黑", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIPanel_GPU.ForeColor = Color.White;
        UIPanel_GPU.Location = new Point(10, 185);
        UIPanel_GPU.Margin = new Padding(4, 5, 4, 5);
        UIPanel_GPU.MinimumSize = new Size(1, 1);
        UIPanel_GPU.Name = "UIPanel_GPU";
        UIPanel_GPU.RectSize = 2;
        UIPanel_GPU.Size = new Size(532, 100);
        UIPanel_GPU.TabIndex = 51;
        UIPanel_GPU.Text = "GPU";
        UIPanel_GPU.TextAlignment = ContentAlignment.TopLeft;
        // 
        // UILabel_GPUName
        // 
        UILabel_GPUName.AutoEllipsis = true;
        UILabel_GPUName.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_GPUName.ForeColor = Color.White;
        UILabel_GPUName.Location = new Point(90, 33);
        UILabel_GPUName.Margin = new Padding(0);
        UILabel_GPUName.Name = "UILabel_GPUName";
        UILabel_GPUName.Size = new Size(430, 20);
        UILabel_GPUName.TabIndex = 53;
        UILabel_GPUName.Text = "N/A";
        UILabel_GPUName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UILabel_GPUNameTag
        // 
        UILabel_GPUNameTag.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_GPUNameTag.ForeColor = Color.White;
        UILabel_GPUNameTag.Location = new Point(30, 33);
        UILabel_GPUNameTag.Margin = new Padding(0);
        UILabel_GPUNameTag.Name = "UILabel_GPUNameTag";
        UILabel_GPUNameTag.Size = new Size(60, 20);
        UILabel_GPUNameTag.TabIndex = 52;
        UILabel_GPUNameTag.Text = "GPU:";
        UILabel_GPUNameTag.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UILabel_GPUUsage
        // 
        UILabel_GPUUsage.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_GPUUsage.ForeColor = Color.White;
        UILabel_GPUUsage.Location = new Point(90, 53);
        UILabel_GPUUsage.Margin = new Padding(0);
        UILabel_GPUUsage.Name = "UILabel_GPUUsage";
        UILabel_GPUUsage.Size = new Size(430, 20);
        UILabel_GPUUsage.TabIndex = 50;
        UILabel_GPUUsage.Text = "N/A";
        UILabel_GPUUsage.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UILabel_GPUMemory
        // 
        UILabel_GPUMemory.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_GPUMemory.ForeColor = Color.White;
        UILabel_GPUMemory.Location = new Point(90, 73);
        UILabel_GPUMemory.Margin = new Padding(0);
        UILabel_GPUMemory.Name = "UILabel_GPUMemory";
        UILabel_GPUMemory.Size = new Size(430, 20);
        UILabel_GPUMemory.TabIndex = 49;
        UILabel_GPUMemory.Text = "N/A";
        UILabel_GPUMemory.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UILabel_GPUMemoryTag
        // 
        UILabel_GPUMemoryTag.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_GPUMemoryTag.ForeColor = Color.White;
        UILabel_GPUMemoryTag.Location = new Point(30, 73);
        UILabel_GPUMemoryTag.Margin = new Padding(0);
        UILabel_GPUMemoryTag.Name = "UILabel_GPUMemoryTag";
        UILabel_GPUMemoryTag.Size = new Size(60, 20);
        UILabel_GPUMemoryTag.TabIndex = 48;
        UILabel_GPUMemoryTag.Text = "显存:";
        UILabel_GPUMemoryTag.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UILabel_GPUUsageTag
        // 
        UILabel_GPUUsageTag.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_GPUUsageTag.ForeColor = Color.White;
        UILabel_GPUUsageTag.Location = new Point(30, 53);
        UILabel_GPUUsageTag.Margin = new Padding(0);
        UILabel_GPUUsageTag.Name = "UILabel_GPUUsageTag";
        UILabel_GPUUsageTag.Size = new Size(60, 20);
        UILabel_GPUUsageTag.TabIndex = 44;
        UILabel_GPUUsageTag.Text = "利用率:";
        UILabel_GPUUsageTag.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UIPanel_CPU
        // 
        UIPanel_CPU.Controls.Add(UILabel_CPUName);
        UIPanel_CPU.Controls.Add(UILabel_CPUNameTag);
        UIPanel_CPU.Controls.Add(UILabel_CPUUsage);
        UIPanel_CPU.Controls.Add(UILabel_CPUMemory);
        UIPanel_CPU.Controls.Add(UILabel_CPUMemoryTag);
        UIPanel_CPU.Controls.Add(UILabel_CPUUsageTag);
        UIPanel_CPU.FillColor = Color.FromArgb(24, 24, 24);
        UIPanel_CPU.FillColor2 = Color.FromArgb(24, 24, 24);
        UIPanel_CPU.Font = new Font("微软雅黑", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UIPanel_CPU.ForeColor = Color.White;
        UIPanel_CPU.Location = new Point(10, 75);
        UIPanel_CPU.Margin = new Padding(4, 5, 4, 5);
        UIPanel_CPU.MinimumSize = new Size(1, 1);
        UIPanel_CPU.Name = "UIPanel_CPU";
        UIPanel_CPU.RectSize = 2;
        UIPanel_CPU.Size = new Size(532, 100);
        UIPanel_CPU.TabIndex = 44;
        UIPanel_CPU.Text = "CPU";
        UIPanel_CPU.TextAlignment = ContentAlignment.TopLeft;
        // 
        // UILabel_CPUName
        // 
        UILabel_CPUName.AutoEllipsis = true;
        UILabel_CPUName.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_CPUName.ForeColor = Color.White;
        UILabel_CPUName.Location = new Point(90, 33);
        UILabel_CPUName.Margin = new Padding(0);
        UILabel_CPUName.Name = "UILabel_CPUName";
        UILabel_CPUName.Size = new Size(430, 20);
        UILabel_CPUName.TabIndex = 52;
        UILabel_CPUName.Text = "N/A";
        UILabel_CPUName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UILabel_CPUNameTag
        // 
        UILabel_CPUNameTag.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_CPUNameTag.ForeColor = Color.White;
        UILabel_CPUNameTag.Location = new Point(30, 33);
        UILabel_CPUNameTag.Margin = new Padding(0);
        UILabel_CPUNameTag.Name = "UILabel_CPUNameTag";
        UILabel_CPUNameTag.Size = new Size(60, 20);
        UILabel_CPUNameTag.TabIndex = 51;
        UILabel_CPUNameTag.Text = "CPU:";
        UILabel_CPUNameTag.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UILabel_CPUUsage
        // 
        UILabel_CPUUsage.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_CPUUsage.ForeColor = Color.White;
        UILabel_CPUUsage.Location = new Point(90, 53);
        UILabel_CPUUsage.Margin = new Padding(0);
        UILabel_CPUUsage.Name = "UILabel_CPUUsage";
        UILabel_CPUUsage.Size = new Size(430, 20);
        UILabel_CPUUsage.TabIndex = 50;
        UILabel_CPUUsage.Text = "N/A";
        UILabel_CPUUsage.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UILabel_CPUMemory
        // 
        UILabel_CPUMemory.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_CPUMemory.ForeColor = Color.White;
        UILabel_CPUMemory.Location = new Point(90, 73);
        UILabel_CPUMemory.Margin = new Padding(0);
        UILabel_CPUMemory.Name = "UILabel_CPUMemory";
        UILabel_CPUMemory.Size = new Size(430, 20);
        UILabel_CPUMemory.TabIndex = 49;
        UILabel_CPUMemory.Text = "N/A";
        UILabel_CPUMemory.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UILabel_CPUMemoryTag
        // 
        UILabel_CPUMemoryTag.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_CPUMemoryTag.ForeColor = Color.White;
        UILabel_CPUMemoryTag.Location = new Point(30, 73);
        UILabel_CPUMemoryTag.Margin = new Padding(0);
        UILabel_CPUMemoryTag.Name = "UILabel_CPUMemoryTag";
        UILabel_CPUMemoryTag.Size = new Size(60, 20);
        UILabel_CPUMemoryTag.TabIndex = 48;
        UILabel_CPUMemoryTag.Text = "内存:";
        UILabel_CPUMemoryTag.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // UILabel_CPUUsageTag
        // 
        UILabel_CPUUsageTag.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_CPUUsageTag.ForeColor = Color.White;
        UILabel_CPUUsageTag.Location = new Point(30, 53);
        UILabel_CPUUsageTag.Margin = new Padding(0);
        UILabel_CPUUsageTag.Name = "UILabel_CPUUsageTag";
        UILabel_CPUUsageTag.Size = new Size(60, 20);
        UILabel_CPUUsageTag.TabIndex = 44;
        UILabel_CPUUsageTag.Text = "利用率:";
        UILabel_CPUUsageTag.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // uiPanel1
        // 
        uiPanel1.Controls.Add(UICbo_VisualModelSelect);
        uiPanel1.Controls.Add(UILabel_VisualModelSelect);
        uiPanel1.Controls.Add(UIIntUD_ServicePort);
        uiPanel1.Controls.Add(UILabel_ServicePort);
        uiPanel1.Controls.Add(UILabel_GPULayer);
        uiPanel1.Controls.Add(UIIntUD_GPULayer);
        uiPanel1.Controls.Add(UILabel_ContextLength);
        uiPanel1.Controls.Add(UIIntUD_ContextLength);
        uiPanel1.Controls.Add(UILabel_ApiUrl);
        uiPanel1.Controls.Add(UIRTextBox_ApiUrl);
        uiPanel1.Controls.Add(UILabel_ExtraArgs);
        uiPanel1.Controls.Add(UITextBox_ExtraArgs);
        uiPanel1.Controls.Add(UILabel_ModelSelect);
        uiPanel1.Controls.Add(UICbo_ModelSelect);
        uiPanel1.FillColor = Color.FromArgb(24, 24, 24);
        uiPanel1.FillColor2 = Color.FromArgb(24, 24, 24);
        uiPanel1.Font = new Font("微软雅黑", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
        uiPanel1.ForeColor = Color.White;
        uiPanel1.Location = new Point(20, 60);
        uiPanel1.Margin = new Padding(4, 5, 4, 5);
        uiPanel1.MinimumSize = new Size(1, 1);
        uiPanel1.Name = "uiPanel1";
        uiPanel1.RectSize = 2;
        uiPanel1.Size = new Size(400, 512);
        uiPanel1.TabIndex = 52;
        uiPanel1.Text = "模型配置";
        uiPanel1.TextAlignment = ContentAlignment.TopCenter;
        // 
        // UICbo_VisualModelSelect
        // 
        UICbo_VisualModelSelect.DataSource = null;
        UICbo_VisualModelSelect.DisplayMember = "DisplayText";
        UICbo_VisualModelSelect.DropDownStyle = UIDropDownStyle.DropDownList;
        UICbo_VisualModelSelect.FillColor = Color.FromArgb(24, 24, 24);
        UICbo_VisualModelSelect.FillColor2 = Color.FromArgb(24, 24, 24);
        UICbo_VisualModelSelect.FillDisableColor = Color.Silver;
        UICbo_VisualModelSelect.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UICbo_VisualModelSelect.ForeColor = Color.White;
        UICbo_VisualModelSelect.ForeDisableColor = Color.Silver;
        UICbo_VisualModelSelect.ItemFillColor = Color.FromArgb(24, 24, 24);
        UICbo_VisualModelSelect.ItemForeColor = Color.White;
        UICbo_VisualModelSelect.ItemHoverColor = Color.FromArgb(155, 200, 255);
        UICbo_VisualModelSelect.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
        UICbo_VisualModelSelect.Location = new Point(10, 115);
        UICbo_VisualModelSelect.Margin = new Padding(4, 5, 4, 5);
        UICbo_VisualModelSelect.MinimumSize = new Size(63, 0);
        UICbo_VisualModelSelect.Name = "UICbo_VisualModelSelect";
        UICbo_VisualModelSelect.Padding = new Padding(0, 0, 30, 2);
        UICbo_VisualModelSelect.RectSize = 2;
        UICbo_VisualModelSelect.ScrollBarHandleWidth = 4;
        UICbo_VisualModelSelect.Size = new Size(380, 30);
        UICbo_VisualModelSelect.SymbolSize = 24;
        UICbo_VisualModelSelect.TabIndex = 20;
        UICbo_VisualModelSelect.TextAlignment = ContentAlignment.MiddleLeft;
        UICbo_VisualModelSelect.ValueMember = "FileName";
        UICbo_VisualModelSelect.Watermark = "";
        UICbo_VisualModelSelect.WatermarkActiveColor = Color.White;
        UICbo_VisualModelSelect.WatermarkColor = Color.White;
        UICbo_VisualModelSelect.SelectionChangeCommitted += UICbo_VisualModelSelect_SelectionChangeCommitted;
        // 
        // UILabel_VisualModelSelect
        // 
        UILabel_VisualModelSelect.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        UILabel_VisualModelSelect.ForeColor = Color.White;
        UILabel_VisualModelSelect.Location = new Point(10, 90);
        UILabel_VisualModelSelect.Name = "UILabel_VisualModelSelect";
        UILabel_VisualModelSelect.Size = new Size(380, 20);
        UILabel_VisualModelSelect.TabIndex = 35;
        UILabel_VisualModelSelect.Text = "视觉模型文件 (--mmproj  .gguf):";
        UILabel_VisualModelSelect.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // uiPanel2
        // 
        uiPanel2.Controls.Add(UIBtn_Refesh);
        uiPanel2.Controls.Add(UIBtn_ImportLlama);
        uiPanel2.Controls.Add(UISwitch_MiniOnClose);
        uiPanel2.Controls.Add(UIBtn_OpenModelDir);
        uiPanel2.Controls.Add(UIBtn_OpenAppDir);
        uiPanel2.Controls.Add(UIBtn_ModelImport);
        uiPanel2.FillColor = Color.FromArgb(24, 24, 24);
        uiPanel2.FillColor2 = Color.FromArgb(24, 24, 24);
        uiPanel2.Font = new Font("微软雅黑", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
        uiPanel2.ForeColor = Color.White;
        uiPanel2.Location = new Point(428, 365);
        uiPanel2.Margin = new Padding(4, 5, 4, 5);
        uiPanel2.MinimumSize = new Size(1, 1);
        uiPanel2.Name = "uiPanel2";
        uiPanel2.RectSize = 2;
        uiPanel2.Size = new Size(552, 207);
        uiPanel2.TabIndex = 53;
        uiPanel2.Text = " 操作面板";
        uiPanel2.TextAlignment = ContentAlignment.TopCenter;
        // 
        // UIForm_Main
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(24, 24, 24);
        ClientSize = new Size(1000, 800);
        ControlBoxFillHoverColor = Color.FromArgb(70, 70, 70);
        Controls.Add(uiPanel2);
        Controls.Add(uiPanel1);
        Controls.Add(UIPanel_Status);
        Controls.Add(UIBtn_KillAllLlamaServer);
        Controls.Add(UIBtn_ClearLog);
        Controls.Add(UILabel_Log);
        Controls.Add(UIRTextBox_Log);
        Controls.Add(UIBtn_ServiceControl);
        Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point, 134);
        ForeColor = Color.White;
        Icon = Resources.AppIcon;
        MaximizeBox = false;
        Name = "UIForm_Main";
        Padding = new Padding(0, 40, 0, 0);
        RectColor = Color.Black;
        ShowRect = false;
        Style = UIStyle.Custom;
        Text = "Llamacpp启动器";
        TitleColor = Color.FromArgb(21, 21, 21);
        TitleFont = new Font("微软雅黑", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 134);
        TitleHeight = 40;
        ZoomScaleRect = new Rectangle(19, 19, 964, 531);
        FormClosing += UIForm_Main_FormClosing;
        Load += UIForm_Main_Load;
        MouseClick += UIForm_Main_MouseClick;
        IconMenu.ResumeLayout(false);
        UIPanel_Status.ResumeLayout(false);
        UIPanel_GPU.ResumeLayout(false);
        UIPanel_CPU.ResumeLayout(false);
        uiPanel1.ResumeLayout(false);
        uiPanel2.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    private UILabel UILabel_ModelSelect;
    private UIComboBox UICbo_ModelSelect;
    private UIButton UIBtn_ModelImport;
    private UIButton UIBtn_OpenModelDir;
    private UIButton UIBtn_Refesh;
    private UILabel UILabel_ServicePort;
    private UIIntegerUpDown UIIntUD_ServicePort;
    private UILabel UILabel_GPULayer;
    private UIIntegerUpDown UIIntUD_GPULayer;
    private UILabel UILabel_ContextLength;
    private UIIntegerUpDown UIIntUD_ContextLength;
    private UILabel UILabel_ApiUrl;
    private UILabel UILabel_ExtraArgs;
    private UITextBox UITextBox_ExtraArgs;
    private UIButton UIBtn_ServiceControl;
    private UIRichTextBox UIRTextBox_Log;
    private UILabel UILabel_Log;
    private UIButton UIBtn_ClearLog;
    private UILabel UILabel_RunStatusText;
    private UILabel UILabel_RunStatus;
    private UIRichTextBox UIRTextBox_ApiUrl;
    private UISwitch UISwitch_MiniOnClose;
    private NotifyIcon AppIcon;
    private UIContextMenuStrip IconMenu;
    private ToolStripMenuItem IconMenu_Exit;
    private UIButton UIBtn_KillAllLlamaServer;
    private UIStyleManager UIStyleManager;
    private UIButton UIBtn_ImportLlama;
    private UIButton UIBtn_OpenAppDir;
    private Sunny.UI.UIPanel UIPanel_Status;
    private Sunny.UI.UIPanel UIPanel_CPU;
    private UILabel UILabel_CPUUsageTag;
    private UILabel UILabel_CPUMemory;
    private UILabel UILabel_CPUMemoryTag;
    private UILabel UILabel_CPUUsage;
    private Sunny.UI.UIPanel UIPanel_GPU;
    private UILabel UILabel_GPUUsage;
    private UILabel UILabel_GPUMemory;
    private UILabel UILabel_GPUMemoryTag;
    private UILabel UILabel_GPUUsageTag;
    private Sunny.UI.UIPanel uiPanel1;
    private UILabel UILabel_VisualModelSelect;
    private UIComboBox UICbo_VisualModelSelect;
    private UILabel UILabel_CPUName;
    private UILabel UILabel_CPUNameTag;
    private UILabel UILabel_GPUName;
    private UILabel UILabel_GPUNameTag;
    private Sunny.UI.UIPanel uiPanel2;
}


using System.Runtime.InteropServices;
using System.Text;

namespace StormLlama.Runtime;

/// <summary>
/// 程序配置
/// </summary>
public class ConfigUtil
{
    //常量
    public const string FormTitle = "Llamacpp启动器_v260415";
    public const string ApiUrlPrefix = "http://127.0.0.1:";
    //路径
    public static string AppDir => Application.StartupPath;
    public static string ModelsDir
    {
        get
        {
            string temp = Path.Combine(AppDir, "Models");
            Directory.CreateDirectory(temp);
            return temp;
        }
    }
    public static string ConfigDir
    {
        get
        {
            string temp = Path.Combine(AppDir, "Config");
            Directory.CreateDirectory(temp);
            return temp;
        }
    }
    public static string ConfigPath => Path.Combine(ConfigDir, "config.ini");
    public static string SelectedModelPath => Path.Combine(ModelsDir, INI_SelectedModel);
    public static string SelectedVisualModelPath => Path.Combine(ModelsDir, INI_SelectedVisualModel);
    public static string LlamaCppDir
    {
        get
        {
            string temp = Path.Combine(AppDir, "llama");
            Directory.CreateDirectory(temp);
            return temp;
        }
    }
    public static string LlamaServerPath => Directory.GetFiles(LlamaCppDir, "llama-server.exe", SearchOption.AllDirectories)
        .FirstOrDefault() ?? Path.Combine(LlamaCppDir, "llama-server.exe");

    #region INI配置
    /// <summary>
    /// 选中模型
    /// </summary>
    public static string INI_SelectedModel
    {
        get => GetConfig("Model", "INI_SelectedModel");
        set => WriteConfig("Model", "INI_SelectedModel", value);
    }

    /// <summary>
    /// 选中视觉模型
    /// </summary>
    public static string INI_SelectedVisualModel
    {
        get => GetConfig("Model", "INI_SelectedVisualModel");
        set => WriteConfig("Model", "INI_SelectedVisualModel", value);
    }

    /// <summary>
    /// 服务端口
    /// </summary>
    public static int INI_ServicePort
    {
        get => int.Parse(GetConfig("Network", "INI_ServicePort", "8989"));
        set => WriteConfig("Network", "INI_ServicePort", value.ToString());
    }

    /// <summary>
    /// GPU调用层数
    /// </summary>
    public static int INI_GPULayer
    {
        get => int.Parse(GetConfig("Model", "INI_GPULayer", "100"));
        set => WriteConfig("Model", "INI_GPULayer", value.ToString());
    }

    /// <summary>
    /// 上下文长度配置
    /// </summary>
    public static int INI_ContextLength_k
    {
        get => int.Parse(GetConfig("Model", "INI_ContextLength", "32"));
        set => WriteConfig("Model", "INI_ContextLength", value.ToString());
    }

    /// <summary>
    /// API地址
    /// </summary>
    public static string INI_ApiUrl
    {
        get
        {
            string url = $"{ApiUrlPrefix}{INI_ServicePort}";
            WriteConfig("Network", "INI_ApiUrl", url);
            return url;
        }
    }

    /// <summary>
    /// 额外参数
    /// </summary>
    public static string INI_ExtraArgs
    {
        get => GetConfig("Model", "INI_ExtraArgs", "");
        set => WriteConfig("Model", "INI_ExtraArgs", value);
    }

    /// <summary>
    /// 关闭时最小化
    /// </summary>
    public static bool INI_MiniOnClose
    {
        get
        {
            string configStr = GetConfig("App", "INI_MiniOnClose", "false");
            return bool.TryParse(configStr, out bool result) && result;
        }
        set => WriteConfig("App", "INI_MiniOnClose", value.ToString());
    }
    #endregion

    #region INI读写方法
    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    internal static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    internal static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    /// <summary>
    /// 获取配置
    /// </summary>
    private static string GetConfig(string section, string key, string def = "")
    {
        StringBuilder temp = new StringBuilder(255);
        GetPrivateProfileString(section, key, def, temp, 255, ConfigPath);
        return temp.ToString();
    }

    /// <summary>
    /// 写入配置
    /// </summary>
    private static void WriteConfig(string section, string key, string val)
    {
        WritePrivateProfileString(section, key, val, ConfigPath);
    }
    #endregion
}
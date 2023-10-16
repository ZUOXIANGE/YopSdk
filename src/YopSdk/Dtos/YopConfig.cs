namespace YopSdk.Dtos;

public class YopConfig
{
    public string ServerRoot { get; set; } = "https://openapi.yeepay.com/yop-center";

    private const string YosServerRoot = "https://yos.yeepay.com/yop-center";

    private const string SdkVersion = "3.2.19";

    private const string SdkLangs = "C#";

    /// <summary>
    /// 开放应用名
    /// </summary>
    private static string _appKey;

    /// <summary>
    /// AES密钥，注册开放应用时获取的密钥
    /// 对应使用AES算法加解密
    /// </summary>
    private static string _aesSecretKey;

    /// <summary>
    /// Hmac密钥，即易宝商户入网后所得的HmacKey
    /// 非开放应用身份发起调用时（即不提供appKey时）使用此密钥签名及报文加密
    /// 对应使用BlowFish算法加解密
    /// </summary>
    private static string _hmacSecretKey;

    /// <summary>
    /// 连接超时时间
    /// </summary>
    private static int _connectTimeout = 30000;

    /// <summary>
    /// 读取返回结果超时
    /// </summary>
    private static int _readTimeout = 60000;

    public static string GetAppKey()
    {
        return _appKey;
    }

    public static void SetAppKey(string appKey)
    {
        YopConfig._appKey = appKey;
    }

    public static string GetAesSecretKey()
    {
        return _aesSecretKey;
    }

    public static void SetAesSecretKey(string aesSecretKey)
    {
        _aesSecretKey = aesSecretKey;
    }

    public static string GetHmacSecretKey()
    {
        return _hmacSecretKey;
    }

    public static void SetHmacSecretKey(string hmacSecretKey)
    {
        YopConfig._hmacSecretKey = hmacSecretKey;
    }

    public static string GetYosServerRoot()
    {
        return YosServerRoot;
    }

    public static string getSdkVersion()
    {
        return SdkVersion;
    }

    public static string getSdkLangs()
    {
        return SdkLangs;
    }

    public static int getConnectTimeout()
    {
        return _connectTimeout;
    }

    public static void setConnectTimeout(int connectTimeout)
    {
        YopConfig._connectTimeout = connectTimeout;
    }

    public static int getReadTimeout()
    {
        return _readTimeout;
    }

    public static void setReadTimeout(int readTimeout)
    {
        YopConfig._readTimeout = readTimeout;
    }

    /**
     * 已设置appKey，默认使用AES密钥
     */
    public static string getSecret()
    {
        if (_appKey != null && _appKey.Trim().Length > 0)
        {
            return _aesSecretKey;
        }
        else
        {
            return _hmacSecretKey;
        }
    }
}
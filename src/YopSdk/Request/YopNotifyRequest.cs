namespace YopSdk.Request;

public class YopNotifyRequest
{
    /// <summary>
    /// 原装加密参数
    /// </summary>
    public string Response { get; set; }

    /// <summary>
    /// 总之就是APPID
    /// </summary>
    public string CustomerIdentification { get; set; }
}
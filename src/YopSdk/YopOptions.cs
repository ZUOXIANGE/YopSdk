namespace YopSdk;

public class YopOptions
{
    /// <summary>
    /// 请求域名
    /// </summary>
    public string Domain { get; set; }

    /// <summary>
    /// 商户号
    /// </summary>
    public string MerchantNo { get; set; }

    /// <summary>
    /// 公钥
    /// </summary>
    public string PublicKey { get; set; }

    /// <summary>
    /// 私钥
    /// </summary>
    public string PrivateKey { get; set; }

    /// <summary>
    /// AppKey
    /// </summary>
    public string AppKey { get; set; }

    /// <summary>
    /// 易宝公钥
    /// </summary>
    public string YopPublicKey { get; set; }

    /// <summary>
    /// 微信公众号ID
    /// </summary>
    public string WxAppId { get; set; } = "wx343362cb28d890b8";
}
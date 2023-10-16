using System.ComponentModel;

namespace YopSdk.Request;

public class YopRequest
{
    [JsonIgnore]
    public virtual string Url { get; set; }

    /// <summary>
    /// 发起方商户编号
    /// </summary>
    [JsonProperty("parentMerchantNo")]
    [Description("发起方商编")]
    public string ParentMerchantNo { get; set; }

    /// <summary>
    /// 商户编号
    /// </summary>
    [JsonProperty("merchantNo")]
    [Description("商户编号")]
    public string MerchantNo { get; set; }

    /// <summary>
    /// 请求时间
    /// </summary>
    [JsonIgnore]
    public DateTime RequestTime => DateTime.Now;

    /// <summary>
    /// 参数，请求用
    /// </summary>
    [JsonIgnore]
    public Dictionary<string, string> Param { get; set; } = new();
}
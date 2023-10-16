using System.ComponentModel;

namespace YopSdk.Response;

public class GeneratePayQrResponse
{
    /// <summary>
    /// 返回值
    /// </summary>
    [JsonProperty("result")]
    public GeneratePayQrResponseResult Result { get; set; }
}

public class GeneratePayQrResponseResult
{
    /// <summary>
    /// 接口返回码
    /// </summary>
    [JsonProperty("code")]
    [Description("接口返回码")]
    public string Code { get; set; }

    /// <summary>
    /// 返回信息
    /// </summary>
    [JsonProperty("message")]
    [Description("返回信息")]
    public string Message { get; set; }

    /// <summary>
    /// 发起方商编
    /// </summary>
    [JsonProperty("parentMerchantNo")]
    [Description("发起方商编")]
    public string ParentMerchantNo { get; set; }

    /// <summary>
    /// 商户收款商编
    /// </summary>
    [JsonProperty("merchantNo")]
    [Description("商户收款商编")]
    public string MerchantNo { get; set; }

    /// <summary>
    /// 商户订单号
    /// </summary>
    [JsonProperty("orderId")]
    [Description("商户订单号")]
    public string OrderId { get; set; }

    /// <summary>
    /// 订单二维码地址
    /// </summary>
    [JsonProperty("qrCodeUrl")]
    [Description("订单二维码地址")]
    public string QrCodeUrl { get; set; }

    /// <summary>
    /// 易宝收款订单号
    /// </summary>
    [JsonProperty("uniqueOrderNo")]
    [Description("易宝收款订单号")]
    public string UniqueOrderNo { get; set; }
}
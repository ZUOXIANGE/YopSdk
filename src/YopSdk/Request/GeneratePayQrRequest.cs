using System.ComponentModel;

namespace YopSdk.Request;

public class GeneratePayQrRequest : YopRequest
{
    public override string Url => "/rest/v1.0/aggpay/pay-link";

    /// <summary>
    /// 商户收款请求号
    /// </summary>
    [JsonProperty("orderId")]
    [Description("商户收款请求号")]
    public string OrderId { get; set; }

    /// <summary>
    /// 订单金额
    /// </summary>
    [JsonProperty("orderAmount")]
    [Description("订单金额")]
    public decimal OrderAmount { get; set; }

    /// <summary>
    /// 订单截止时间
    /// </summary>
    [JsonProperty("expiredTime")]
    [Description("订单截止时间")]
    public DateTime ExpiredTime { get; set; }

    /// <summary>
    /// 支付结果通知地址
    /// </summary>
    [JsonProperty("notifyUrl")]
    [Description("支付结果通知地址")]
    public string NotifyUrl { get; set; }

    /// <summary>
    /// 商品名称
    /// </summary>
    [JsonProperty("goodsName")]
    [Description("商品名称")]
    public string GoodsName { get; set; }

    /// <summary>
    /// 商品名称
    /// </summary>
    [JsonProperty("scene")]
    [Description("场景")]
    public string Scene => "OFFLINE";

    /// <summary>
    /// 微信公众号ID
    /// </summary>
    [JsonProperty("appId")]
    [Description("微信公众号ID")]
    public string AppId { get; set; } = "wx343362cb28d890b8";

}
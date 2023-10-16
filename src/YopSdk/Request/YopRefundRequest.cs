using System.ComponentModel;

namespace YopSdk.Request;

public class YopRefundRequest : YopRequest
{
    public override string Url => "/rest/v1.0/trade/refund";

    /// <summary>
    /// 收款交易对应的商户收款请求号
    /// </summary>
    [JsonProperty("orderId")]
    [Description("收款交易对应的商户收款请求号")]
    public string OrderId { get; set; }

    /// <summary>
    /// 商户退款请求号
    /// </summary>
    [JsonProperty("refundRequestId")]
    [Description("商户退款请求号")]
    public string RefundRequestId { get; set; }

    /// <summary>
    /// 收款交易对应的易宝收款订单号。
    /// </summary>
    [JsonProperty("uniqueOrderNo")]
    [Description("收款交易对应的易宝收款订单号。")]
    public string UniqueOrderNo { get; set; }

    /// <summary>
    /// 退款申请金额
    /// </summary>
    [JsonProperty("refundAmount")]
    [Description("退款申请金额")]
    public string RefundAmount { get; set; }

    /// <summary>
    /// 退款结果回调url
    /// </summary>
    [JsonProperty("notifyUrl")]
    [Description("退款结果回调url")]
    public string NotifyUrl { get; set; }
}
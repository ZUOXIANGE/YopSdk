using System.ComponentModel;

namespace YopSdk.Response;

public class YopRefundResponse
{
    /// <summary>
    /// 返回信息，对应code的中文信息
    /// </summary>
    [JsonProperty("message")]
    [Description("返回信息")]
    public string Message { get; set; }

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
    /// 商户收款请求号
    /// </summary>
    [JsonProperty("orderId")]
    [Description("商户收款请求号")]
    public string OrderId { get; set; }

    /// <summary>
    /// 商户退款请求号
    /// </summary>
    [JsonProperty("refundRequestId")]
    [Description("商户退款请求号")]
    public string RefundRequestId { get; set; }

    /// <summary>
    /// 易宝退款订单号，商户退款请求对应在易宝的退款单号
    /// </summary>
    [JsonProperty("uniqueRefundNo")]
    [Description("易宝退款订单号")]
    public string UniqueRefundNo { get; set; }

    /// <summary>
    /// 退款订单状态
    /// </summary>
    [JsonProperty("status")]
    [Description("退款订单状态")]
    public string Status { get; set; }

    /// <summary>
    /// 退款申请金额
    /// </summary>
    [JsonProperty("refundAmount")]
    [Description("退款申请金额")]
    public string RefundAmount { get; set; }

    /// <summary>
    /// 退款受理时间
    /// </summary>
    [JsonProperty("refundRequestDate")]
    [Description("退款受理时间")]
    public string RefundRequestDate { get; set; }

    /// <summary>
    /// 退还商户手续费，在退款成功时返回
    /// </summary>
    [JsonProperty("refundMerchantFee")]
    [Description("退还商户手续费")]
    public string RefundMerchantFee { get; set; }

    /// <summary>
    /// 退款资金来源信息
    /// </summary>
    [JsonProperty("refundAccountDetail")]
    [Description("退款资金来源信息")]
    public string RefundAccountDetail { get; set; }

    /// <summary>
    /// 扣账时间，格式：yyyy-MM-dd HH:mm:ss
    /// </summary>
    [JsonProperty("refundCsFinishDate")]
    [Description("扣账时间")]
    public string RefundCsFinishDate { get; set; }
}
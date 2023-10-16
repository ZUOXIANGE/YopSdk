using System.ComponentModel;

namespace YopSdk.Response;

public class RefundNotifyResponse
{
    /// <summary>
    /// 收款商户商编
    /// </summary>
    [JsonProperty("merchantNo")]
    [Description("收款商户商编")]
    public string MerchantNo { get; set; }

    /// <summary>
    /// 收款交易对应的商户收款请求单号
    /// </summary>
    [JsonProperty("orderId")]
    [Description("收款交易对应的商户收款请求单号")]
    public string OrderId { get; set; }

    /// <summary>
    /// 商户退款请求号
    /// </summary>
    [JsonProperty("refundRequestId")]
    [Description("商户退款请求号")]
    public string RefundRequestId { get; set; }

    /// <summary>
    /// 收款交易对应在易宝的收款单号
    /// </summary>
    [JsonProperty("uniqueOrderNo")]
    [Description("收款交易对应在易宝的收款单号")]
    public string UniqueOrderNo { get; set; }

    /// <summary>
    /// 订单金额，下单请求金额
    /// </summary>
    [JsonProperty("orderAmount")]
    [Description("订单金额，下单请求金额")]
    public string OrderAmount { get; set; }

    /// <summary>
    /// 用户付手续费场景下,实际退款金额=退款金额+退费金额
    /// </summary>
    [JsonProperty("realRefundAmount")]
    [Description("用户付手续费场景下,实际退款金额=退款金额+退费金额")]
    public string RealRefundAmount { get; set; }

    /// <summary>
    /// 该笔退款完成后，订单剩余的可以发起退款的金额
    /// </summary>
    [JsonProperty("residualAmount")]
    [Description("该笔退款完成后，订单剩余的可以发起退款的金额")]
    public string ResidualAmount { get; set; }

    /// <summary>
    /// 商户手续费退款金额
    /// </summary>
    [JsonProperty("returnMerchantFee")]
    [Description("商户手续费退款金额")]
    public string ReturnMerchantFee { get; set; }

    /// <summary>
    /// 用户手续费退款金额
    /// </summary>
    [JsonProperty("returnCustomerFee")]
    [Description("用户手续费退款金额")]
    public string ReturnCustomerFee { get; set; }

    /// <summary>
    /// 实扣金额
    /// </summary>
    [JsonProperty("realDeductAmount")]
    [Description("实扣金额")]
    public string RealDeductAmount { get; set; }

    /// <summary>
    /// 退款应结算金额
    /// </summary>
    [JsonProperty("settlementRefundFee")]
    [Description("退款应结算金额")]
    public string SettlementRefundFee { get; set; }

    /// <summary>
    /// 商户退款请求对应在易宝的退款单号
    /// </summary>
    [JsonProperty("uniqueRefundNo")]
    [Description("商户退款请求对应在易宝的退款单号")]
    public string UniqueRefundNo { get; set; }

    /// <summary>
    /// 退款请求时间
    /// </summary>
    [JsonProperty("refundRequestDate")]
    [Description("退款请求时间")]
    public string RefundRequestDate { get; set; }

    /// <summary>
    /// 退款状态
    /// </summary>
    [JsonProperty("status")]
    [Description("退款状态")]
    public string Status { get; set; }

    /// <summary>
    /// 退款成功时间
    /// </summary>
    [JsonProperty("refundSuccessDate")]
    [Description("退款成功时间")]
    public string RefundSuccessDate { get; set; }

    /// <summary>
    /// 当支付方式为微信/支付宝/云闪付且参加渠道侧优惠时，退款可能退优惠，此字段为扣除优惠后实际退回用户金额
    /// </summary>
    [JsonProperty("cashRefundFee")]
    [Description("用户实退金额")]
    public string CashRefundFee { get; set; }

    /// <summary>
    /// 退款请求时商户自定义
    /// </summary>
    [JsonProperty("description")]
    [Description("退款说明")]
    public string Description { get; set; }

    /// <summary>
    /// 当有微信/支付宝/云闪付渠道侧营销退款退回优惠时会展示此字段
    /// </summary>
    [JsonProperty("channelPromotionInfo")]
    [Description("渠道侧优惠退回列表")]
    public string ChannelPromotionInfo { get; set; }

    /// <summary>
    /// 易宝侧优惠退回列表
    /// </summary>
    [JsonProperty("ypPromotionInfoDTOList")]
    [Description("渠道侧优惠退回列表")]
    public string YpPromotionInfoDtoList { get; set; }

}
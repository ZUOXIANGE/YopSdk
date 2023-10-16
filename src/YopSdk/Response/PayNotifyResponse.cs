using System.ComponentModel;

namespace YopSdk.Response;

public class PayNotifyResponse
{
    /// <summary>
    /// 发起方商编
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
    /// 易宝收款订单号
    /// </summary>
    [JsonProperty("uniqueOrderNo")]
    [Description("易宝收款订单号")]
    public string UniqueOrderNo { get; set; }

    /// <summary>
    /// 渠道订单号
    /// </summary>
    [JsonProperty("channelOrderId")]
    [Description("渠道订单号")]
    public string ChannelOrderId { get; set; }

    /// <summary>
    /// 子单信息
    /// </summary>
    [JsonProperty("subOrderInfoList")]
    [Description("子单信息")]
    public string SubOrderInfoList { get; set; }

    /// <summary>
    /// 订单金额
    /// </summary>
    [JsonProperty("orderAmount")]
    [Description("订单金额")]
    public string OrderAmount { get; set; }

    /// <summary>
    /// 支付金额
    /// </summary>
    [JsonProperty("payAmount")]
    [Description("支付金额")]
    public string PayAmount { get; set; }

    /// <summary>
    /// 订单状态
    /// </summary>
    [JsonProperty("status")]
    [Description("订单状态")]
    public string Status { get; set; }

    /// <summary>
    /// 支付成功时间
    /// </summary>
    [JsonProperty("paySuccessDate")]
    [Description("支付成功时间")]
    public string PaySuccessDate { get; set; }

    /// <summary>
    /// 支付方式
    /// </summary>
    [JsonProperty("payWay")]
    [Description("支付方式")]
    public string PayWay { get; set; }

    /// <summary>
    /// 渠道类型
    /// </summary>
    [JsonProperty("channel")]
    [Description("渠道类型")]
    public string Channel { get; set; }

    /// <summary>
    /// 付款信息
    /// </summary>
    [JsonProperty("payerInfo")]
    [Description("付款信息")]
    public string PayerInfo { get; set; }

    /// <summary>
    /// 用户实际支付金额
    /// </summary>
    [JsonProperty("realPayAmount")]
    [Description("用户实际支付金额")]
    public string RealPayAmount { get; set; }

    /// <summary>
    /// 渠道侧优惠列表
    /// </summary>
    [JsonProperty("channelPromotionInfo")]
    [Description("渠道侧优惠列表")]
    public string ChannelPromotionInfo { get; set; }

    /// <summary>
    /// 易宝侧优惠列表
    /// </summary>
    [JsonProperty("ypPromotionInfo")]
    [Description("易宝侧优惠列表")]
    public string YpPromotionInfo { get; set; }

    /// <summary>
    /// 支付失败的code码
    /// </summary>
    [JsonProperty("failCode")]
    [Description("支付失败的code码")]
    public string FailCode { get; set; }

    /// <summary>
    /// 支付失败的失败原因
    /// </summary>
    [JsonProperty("failReason")]
    [Description("支付失败的失败原因")]
    public string FailReason { get; set; }

    /// <summary>
    /// 终端信息
    /// </summary>
    [JsonProperty("terminalInfo")]
    [Description("终端信息")]
    public string TerminalInfo { get; set; }
}

public class PayInfo
{
    /// <summary>
    /// 卡类型
    /// </summary>
    [JsonProperty("cardType")]
    [Description("卡类型")]
    public string CardType { get; set; }

    /// <summary>
    /// 银行编号
    /// </summary>
    [JsonProperty("bankId")]
    [Description("银行编号")]
    public string BankId { get; set; }

    /// <summary>
    /// 银行卡号
    /// </summary>
    [JsonProperty("bankCardNo")]
    [Description("银行卡号")]
    public string BankCardNo { get; set; }

    /// <summary>
    /// 账户名称
    /// </summary>
    [JsonProperty("accountName")]
    [Description("账户名称")]
    public string AccountName { get; set; }

    /// <summary>
    /// 手机号
    /// </summary>
    [JsonProperty("mobilePhoneNo")]
    [Description("手机号")]
    public string MobilePhoneNo { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonProperty("userID")]
    [Description("用户ID")]
    public string UserId { get; set; }

    /// <summary>
    /// unionID
    /// </summary>
    [JsonProperty("unionID")]
    [Description("unionID")]
    public string UnionId { get; set; }

    /// <summary>
    /// buyerLogonId
    /// </summary>
    [JsonProperty("buyerLogonId")]
    [Description("buyerLogonId")]
    public string BuyerLogonId { get; set; }

    /// <summary>
    /// 记账簿编号
    /// </summary>
    [JsonProperty("ypAccountBookNo")]
    [Description("记账簿编号")]
    public string YpAccountBookNo { get; set; }
}

public class SubOrderInfo
{
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
    /// 易宝收款订单号
    /// </summary>
    [JsonProperty("uniqueOrderNo")]
    [Description("易宝收款订单号")]
    public string UniqueOrderNo { get; set; }

    /// <summary>
    /// 订单金额
    /// </summary>
    [JsonProperty("orderAmount")]
    [Description("订单金额")]
    public string OrderAmount { get; set; }
}

public class ChannelPromotionInfo
{
    /// <summary>
    /// 优惠券编码
    /// </summary>
    [JsonProperty("promotionId")]
    [Description("优惠券编码")]
    public string PromotionId { get; set; }

    /// <summary>
    /// 优惠券名称
    /// </summary>
    [JsonProperty("promotionName")]
    [Description("优惠券名称")]
    public string PromotionName { get; set; }

    /// <summary>
    /// 优惠券范围(全场、单品)
    /// </summary>
    [JsonProperty("promotionScope")]
    [Description("优惠券范围(全场、单品)")]
    public string PromotionScope { get; set; }

    /// <summary>
    /// 优惠券金额
    /// </summary>
    [JsonProperty("amount")]
    [Description("优惠券金额")]
    public string Amount { get; set; }

    /// <summary>
    /// 优惠券活动id
    /// </summary>
    [JsonProperty("activityId")]
    [Description("优惠券活动id")]
    public string ActivityId { get; set; }

    /// <summary>
    /// 渠道出资
    /// </summary>
    [JsonProperty("channelContribute")]
    [Description("渠道出资")]
    public string ChannelContribute { get; set; }

    /// <summary>
    /// 商户出资
    /// </summary>
    [JsonProperty("merchantContribute")]
    [Description("商户出资")]
    public string MerchantContribute { get; set; }

    /// <summary>
    /// 其他出资
    /// </summary>
    [JsonProperty("otherContribute")]
    [Description("其他出资")]
    public string OtherContribute { get; set; }

    /// <summary>
    /// 备注信息
    /// </summary>
    [JsonProperty("memo")]
    [Description("备注信息")]
    public string Memo { get; set; }
}

public class YpPromotionInfo
{
    /// <summary>
    /// 活动编号
    /// </summary>
    [JsonProperty("maketNo")]
    [Description("活动编号")]
    public string MaketNo { get; set; }

    /// <summary>
    /// 活动类型
    /// </summary>
    [JsonProperty("type")]
    [Description("活动类型")]
    public string Type { get; set; }

    /// <summary>
    /// 活动金额
    /// </summary>
    [JsonProperty("amount")]
    [Description("活动金额")]
    public string Amount { get; set; }
}
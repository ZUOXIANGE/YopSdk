using YopSdk.Dtos;

namespace YopSdk.Response;

public class YopResponse
{
    /// <summary>
    /// 状态(SUCCESS/FAILURE)
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// 业务结果，非简单类型解析后为LinkedHashMap
    /// </summary>
    public object Result { get; set; }

    /// <summary>
    /// 时间戳
    /// </summary>
    public long Ts { get; set; }

    /// <summary>
    /// 结果签名，签名算法为Request指定算法，示例：SHA(<secret>stringResult</secret>)
    /// </summary>
    public string Sign { get; set; }

    /// <summary>
    /// 错误信息
    /// </summary>
    public YopError Error { get; set; }

    /// <summary>
    /// 字符串形式的业务结果，客户可自定义java类，使用YopMarshallerUtils.unmarshal做参数绑定
    /// </summary>
    public string StringResult { get; set; }

    /// <summary>
    /// 字符串形式的错误信息
    /// </summary>
    public string StringError { get; set; }

    /// <summary>
    /// 响应格式，冗余字段，跟Request的format相同，用于解析结果
    /// </summary>
    public FormatType Format { get; set; }

    /// <summary>
    /// 业务结果签名是否合法，冗余字段
    /// </summary>
    public bool ValidSign { get; set; }

    public bool IsValidSign()
    {
        return ValidSign;
    }
}
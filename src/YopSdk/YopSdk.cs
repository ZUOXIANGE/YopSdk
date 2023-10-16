using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using YopSdk.Request;
using YopSdk.Tools;

namespace YopSdk;

public class YopSdk : IYopSdk
{
    private readonly YopOptions _options;
    private readonly ILogger<YopSdk> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public YopSdk(IOptions<YopOptions> options, ILogger<YopSdk> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _options = options.Value;
    }

    /// <summary>
    /// 执行请求
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="request"></param>
    /// <param name="canLog"></param>
    /// <returns></returns>
    public async Task<TResponse> ExecuteAsync<TRequest, TResponse>(TRequest request, bool canLog = true) where TRequest : YopRequest
    {
        request.MerchantNo = _options.MerchantNo;
        request.ParentMerchantNo = _options.MerchantNo;

        if (canLog)
            _logger.LogInformation("易宝请求{url} {req}", request.Url, JsonConvert.SerializeObject(request));
        var resp = await PostAsync(request);
        if (canLog)
            _logger.LogInformation("易宝返回{resp}", resp);
        if (string.IsNullOrEmpty(resp) && !canLog)
        {
            _logger.LogInformation("易宝请求{url} {req}", request.Url, JsonConvert.SerializeObject(request));
            _logger.LogInformation("易宝返回{resp}", resp);
        }

        if (string.IsNullOrEmpty(resp)) return default;
        var result = JsonConvert.DeserializeObject<TResponse>(resp);
        return result;
    }

    /// <summary>
    /// 发送post请求
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    private async Task<string> PostAsync(YopRequest request)
    {
        var client = _httpClientFactory.CreateClient(nameof(YopSdk));

        //请求地址
        var url = $"{_options.Domain}{request.Url}";
        //请求头
        var headers = SignTools.SignRsaParameter(request, _options);

        var req = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new FormUrlEncodedContent(request.Param)
        };

        foreach (var header in headers)
        {
            req.Headers.Add(header.Key, header.Value);
        }

        var resp = await client.SendAsync(req);
        var data = await resp.Content.ReadAsStringAsync();
        return data;
    }

    /// <summary>
    /// 解密
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request"></param>
    /// <returns></returns>
    public T DecryptResponse<T>(YopNotifyRequest request)
    {
        var data = SignTools.DecryptData(request.Response, _options.PrivateKey);
        if (string.IsNullOrEmpty(data))
            throw new ArgumentException("参数错误，解析失败");

        return JsonConvert.DeserializeObject<T>(data);
    }
}


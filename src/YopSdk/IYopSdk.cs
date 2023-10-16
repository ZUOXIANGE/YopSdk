global using Newtonsoft.Json;

using YopSdk.Request;

namespace YopSdk;

public interface IYopSdk
{
    /// <summary>
    /// 执行请求
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="request"></param>
    /// <param name="canLog"></param>
    /// <returns></returns>
    public Task<TResponse> ExecuteAsync<TRequest, TResponse>(TRequest request, bool canLog = true)
        where TRequest : YopRequest;

    /// <summary>
    /// 解密
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request"></param>
    /// <returns></returns>
    public T DecryptResponse<T>(YopNotifyRequest request);
}
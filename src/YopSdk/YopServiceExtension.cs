using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace YopSdk;

public static class YopServiceExtension
{
    /// <summary>
    /// 添加易宝SDK
    /// </summary>
    /// <param name="serviceBuilder"></param>
    /// <param name="configuration"></param>
    /// <param name="configName"></param>
    /// <returns></returns>
    public static IServiceCollection AddYopSdk(this IServiceCollection serviceBuilder,
        IConfiguration configuration, string configName)
    {
        serviceBuilder.Configure<YopOptions>(configuration.GetSection(configName));
        var timeout = configuration.GetValue<int>("Timeout");
        if (timeout < 3)
        {
            timeout = 3;
        }
        serviceBuilder.TryAddSingleton<IYopSdk, YopSdk>();
        serviceBuilder.AddHttpClient(nameof(YopSdk), client =>
        {
            client.Timeout = TimeSpan.FromSeconds(timeout);
        });
        return serviceBuilder;
    }
}
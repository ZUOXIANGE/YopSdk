using Microsoft.AspNetCore.Mvc;
using YopSdk;
using YopSdk.Request;
using YopSdk.Response;

namespace Sample.Controllers;

/// <summary>
/// 测试
/// </summary>
[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly IYopSdk _yopSdk;

    public TestController(IYopSdk yopSdk)
    {
        _yopSdk = yopSdk;
    }

    [HttpGet("ping")]
    public string Ping()
    {
        return "pong";
    }

    /// <summary>
    /// 二维码生成
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    [HttpGet("genQrCode")]
    public async Task<string> GenQrCode(decimal amount)
    {
        var param = new GeneratePayQrRequest
        {
            GoodsName = "测试商品",
            NotifyUrl = "https://test.com/api/payCallback",
            OrderAmount = amount,
            OrderId = Guid.NewGuid().ToString("N")
        };
        param.ExpiredTime = param.RequestTime.AddMinutes(15);

        var resp = await _yopSdk.ExecuteAsync<GeneratePayQrRequest, GeneratePayQrResponse>(param);

        return resp.Result.QrCodeUrl;
    }
}
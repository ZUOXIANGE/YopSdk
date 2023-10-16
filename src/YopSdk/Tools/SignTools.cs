using System.Security.Cryptography;
using System.Text;
using System.Web;
using YopSdk.Request;

namespace YopSdk.Tools;

public static class SignTools
{
    private static readonly JsonSerializerSettings JsonSetting = new()
    {
        NullValueHandling = NullValueHandling.Ignore,
        DateFormatString = "yyyy-MM-dd HH:mm:ss"
    };

    #region 请求加密

    /// <summary>
    /// 加签
    /// </summary>
    /// <param name="request"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static Dictionary<string, string> SignRsaParameter(YopRequest request, YopOptions options)
    {
        //当前时间指定格式
        var timestamp = request.RequestTime.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssK");//当前时间
        //当前请求标识
        var requestId = Guid.NewGuid().ToString();
        //鉴权版本
        const string protocolVersion = "yop-auth-v2";
        //超时时间
        const string expiredSeconds = "1800";

        //请求头
        var headers = new Dictionary<string, string>
        {
            { "x-yop-request-id", requestId },
            { "x-yop-date", timestamp },
            { "x-yop-sdk-version", "1.0" },
            { "x-yop-sdk-langs", "C#" },
            { "x-yop-appkey", options.AppKey }
        };

        //1.认证字符串
        var authString = protocolVersion + "/" + options.AppKey + "/" + timestamp + "/" + expiredSeconds;
        //添加规范 URI 参数，后跟换行符
        var canonicalQueryString = GetCanonicalQueryString(request, options.AppKey);
        //需要加签的请求头列表
        var headersToSign = GetHeadersToSign(headers);
        //添加规范标头
        var canonicalHeader = GetCanonicalHeaders(headersToSign);
        //加签标头排序
        var signedHeaders = string.Join(";", headersToSign.Keys).ToLower();
        //2.规范请求
        var canonicalRequest = authString + "\n" + "POST" + "\n" + request.Url + "\n" + canonicalQueryString + "\n" + canonicalHeader;
        var signToBase64 = RsaSign(options.PrivateKey, canonicalRequest);
        signToBase64 = Base64UrlEncode(signToBase64);
        signToBase64 += "$SHA256";
        headers.Add("Authorization", "YOP-RSA2048-SHA256 " + protocolVersion + "/" + options.AppKey + "/" + timestamp + "/" + expiredSeconds + "/" + signedHeaders + "/" + signToBase64);
        headers.Add("Accept", "*/*");
        headers.Add("ContentType", "application/x-www-form-urlencoded");
        headers.Add("UserAgent", ".NET/3.2.19");
        return headers;
    }

    /// <summary>
    /// 转义
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    private static string Base64UrlEncode(string s)
    {
        s = s.Split('=')[0]; // Remove any trailing '='s
        s = s.Replace('+', '-'); // 62nd char of encoding
        s = s.Replace('/', '_'); // 63rd char of encoding
        return s;
    }

    /// <summary>
    /// RSA加密
    /// </summary>
    /// <param name="privateKey"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    private static string RsaSign(string privateKey, string content)
    {
        //创建对象，加载私钥
        using var rsa = RSA.Create();
        var bytes = Convert.FromBase64String(privateKey);
        rsa.ImportRSAPrivateKey(bytes, out _);

        var signature = rsa.SignData(Encoding.UTF8.GetBytes(content), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        return Convert.ToBase64String(signature);
    }

    /// <summary>
    /// 获取加密原始参数
    /// </summary>
    /// <param name="request"></param>
    /// <param name="appKey"></param>
    /// <returns></returns>
    private static string GetCanonicalQueryString(YopRequest request, string appKey)
    {
        var time = new DateTimeOffset(request.RequestTime).ToUnixTimeMilliseconds();
        var param = new Dictionary<string, string>
        {
            { "appKey", appKey },
            { "v", "1.0" },
            { "locale", "zh_CN" },
            { "ts", time.ToString() },
            {"method",request.Url}
        };
        var json = JsonConvert.SerializeObject(request, JsonSetting);
        var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        foreach (var pair in data)
        {
            param.Add(pair.Key, pair.Value.ToString());
        }

        var arrayList = new List<string>();
        foreach (var item in param)
        {
            if (string.IsNullOrEmpty(item.Key) || string.IsNullOrEmpty(item.Value) || item.Key == "Authorization")
                continue;

            var v = UrlEncode(item.Value, true);
            //添加到请求参里面
            request.Param.Add(item.Key, v);
            //排序字符串
            arrayList.Add(item.Key + "=" + v);
        }

        arrayList.Sort(string.CompareOrdinal);

        var strQuery = string.Join("&", arrayList);

        return strQuery;
    }

    /// <summary>
    /// 获取加密后的请求头
    /// </summary>
    /// <param name="headers"></param>
    /// <returns></returns>
    private static SortedDictionary<string, string> GetHeadersToSign(Dictionary<string, string> headers)
    {
        //需要加签的请求头字段
        var headersToSignSet = new List<string>
        {
            "x-yop-appkey",
            "x-yop-date",
            "x-yop-request-id",
        };

        var ret = new SortedDictionary<string, string>();

        foreach (var header in headersToSignSet)
        {
            var item = headers[header.ToLower()];
            if (item == null) continue;
            ret.Add(header.ToLower(), item);
        }
        return ret;
    }

    /// <summary>
    /// 添加规范标头，CanonicalHeaders后跟换行符
    /// </summary>
    /// <param name="headers"></param>
    /// <returns></returns>
    private static string GetCanonicalHeaders(SortedDictionary<string, string> headers)
    {
        var headerStrings = new List<string>();

        foreach (var key in headers.Keys)
        {
            var value = headers[key] ?? "";

            var kv = UrlEncode(key.Trim().ToLower(), true);
            value = UrlEncode(value.Trim(), true);
            headerStrings.Add(kv + ':' + value);

        }

        headerStrings.Sort(string.CompareOrdinal);

        var strQuery = string.Join("\n", headerStrings);

        return strQuery;
    }

    /// <summary>
    /// UrlEncode重写：小写转大写，特殊字符特换
    /// </summary>
    /// <param name="strSrc">原字符串</param>
    /// <param name="bToUpper">是否转大写</param>
    /// <returns></returns>
    private static string UrlEncode(string strSrc, bool bToUpper = false)
    {
        var stringBuilder = new StringBuilder();
        foreach (var t1 in strSrc)
        {
            var t = t1.ToString();

            var k = Uri.EscapeDataString(t);
            if (t == k)
            {
                stringBuilder.Append(t);
            }
            else
            {
                stringBuilder.Append(bToUpper ? k.ToUpper() : k);
            }
        }
        if (bToUpper)
            return stringBuilder.ToString().Replace("+", "%2B");

        return stringBuilder.ToString();
    }

    #endregion

    #region 回调解密



    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="data"></param>
    /// <param name="privateKey"></param>
    /// <returns></returns>
    public static string DecryptData(string data, string privateKey)
    {
        var str = HttpUtility.UrlDecode(data);
        var args = str.Split('$');


        var encryptedRandomKeyToBase64 = args[0];
        var encryptedDataToBase64 = args[1];

        //用私钥对随机密钥进行解密
        var randomKey = RsaDecrypt(Base64UrlSafeDecode(encryptedRandomKeyToBase64), privateKey);
        var encryptedData = Encoding.UTF8.GetString(AesDecrypt(Base64UrlSafeDecode(encryptedDataToBase64), randomKey));

        var index = encryptedData.LastIndexOf('$');

        var sourceData = encryptedData.Substring(0, index);

        return sourceData;

    }

    private static byte[] AesDecrypt(byte[] data, byte[] key)
    {
        var mStream = new MemoryStream(data);
        var aes = Aes.Create();
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.PKCS7;
        aes.KeySize = 128;
        aes.Key = key;
        var cryptoStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
        try
        {
            var tmp = new byte[data.Length + 32];
            var len = cryptoStream.Read(tmp, 0, data.Length + 32);
            var ret = new byte[len];
            Array.Copy(tmp, 0, ret, 0, len);
            return ret;
        }
        finally
        {
            cryptoStream.Close();
            mStream.Close();
            aes.Clear();
        }
    }

    private static byte[] RsaDecrypt(byte[] data, string privateKey)
    {
        using var rsa = RSA.Create();
        var bytes = Convert.FromBase64String(privateKey);
        rsa.ImportRSAPrivateKey(bytes, out _);

        var d = rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
        return d;
    }

    private static byte[] Base64UrlSafeDecode(string str)
    {
        str = str.Replace('-', '+').Replace('_', '/');
        var paddings = str.Length % 4;
        if (paddings > 0)
        {
            str += new string('=', 4 - paddings);
        }
        return Convert.FromBase64String(str);
    }

    #endregion
}
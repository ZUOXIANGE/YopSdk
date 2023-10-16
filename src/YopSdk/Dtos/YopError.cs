namespace YopSdk.Dtos;

public class YopError
{
    public string Code { get; set; }

    public string Message { get; set; }

    public string Solution { get; set; }

    public List<YopSubError> SubErrors { get; set; } = new List<YopSubError>();
}
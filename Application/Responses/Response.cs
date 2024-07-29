namespace Application.Responses;

public class Response<TData>
{
    private readonly int _code;

    public Response()
        => _code = Configuration.DefaultStatusCode;
    
    public Response(
        TData? data,
        int code = Configuration.DefaultStatusCode,
        string? message = null)
    {
        Data = data;
        _code = code;
        Message = message;
    }

    public TData? Data { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess => _code is >= 200 and <= 299;
}
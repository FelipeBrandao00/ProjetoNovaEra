namespace Application.Responses;

public class Response<TData>
{
    public TData? Data { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}
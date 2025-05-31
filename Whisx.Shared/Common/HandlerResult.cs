namespace Whisx.Shared.Common;

public class HandlerResult<T> where T : class
{
    public T? Data { get; init; }

    public string? Message { get; init; }

    public bool Success { get; init; }
}
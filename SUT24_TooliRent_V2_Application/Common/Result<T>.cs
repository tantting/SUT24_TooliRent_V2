namespace SUT24_TooliRent_V2_Application.Common;

public class Result
{
    public bool Success { get; }
    public string? ErrorMessage { get; }

    protected Result(bool success, string? errorMessage)
    {
        Success = success;
        ErrorMessage = errorMessage;
    }

    public static Result Ok() => new(true, null);
    public static Result Fail(string error) => new(false, error);
}

public class Result<T> : Result
{
    public T? Data { get; }

    private Result(bool success, T? data, string? errorMessage)
        : base(success, errorMessage)
    {
        Data = data;
    }

    public static Result<T> Ok(T data) => new(true, data, null);
    public static new Result<T> Fail(string error) => new(false, default, error);
}
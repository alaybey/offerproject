

namespace Business.DTO;


public class ApiResult<T>
{
    private ApiResult() {}

    private ApiResult(bool succeeded, T result, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Result = result;
        Errors = errors;
    }

    public bool Succeeded { get; set; }

    public T Result { get; set; }

    public IEnumerable<string> Errors { get; set; }

    public static ApiResult<T> Success(T result)
    {
        return new ApiResult<T>(true, result, []);
    }

    public static ApiResult<T> Failure(IEnumerable<string> errors)
    {
        return new ApiResult<T>(false, default, errors);
    }

    public static object? Failure(string message)
    {
        return ApiResult<T>.Failure([message]);
    }
}

namespace KOS.Core.Wrapper;

public class Response<TEntity> : IResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public TEntity Data { get; set; }

    public Response(TEntity data, bool isSuccess = true, string message = null)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }
}
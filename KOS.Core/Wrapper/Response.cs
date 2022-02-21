namespace KOS.Core.Wrapper
{
    public class Response<TEntity> : IResponse
    {
        public string Message { get; set; }
        public TEntity Data { get; set; }
        public Response(TEntity data, string message = null)
        {
            Message = message;
            Data = data;
        }
    }
}

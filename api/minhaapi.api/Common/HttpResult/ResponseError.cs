namespace minhaapi.Common.HttpResult
{
    public class ResponseError
    {
        public string Message { get; set; }

        public ResponseError(string message)
        {
            Message = message;
        }
    }
}

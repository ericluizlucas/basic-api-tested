namespace minhaapi.Common.HttpResult
{
    public  class ResponseDefault
    {
        public string Message { get; set; }
        public object ResultInfo { get; set; }
        public bool IsError { get; set; }

        public ResponseDefault(string txtMessage, object data, bool isError) {
            Message = txtMessage;
            ResultInfo = !isError ? data : txtMessage;
            IsError = isError;
        }
    }
}

namespace FlavoristWebAPI.Utils
{
    public class ExceptionResponse
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public ExceptionResponse(Exception ex, bool includeStackTrace = false)
        {
            Succeed = false;
            Message = ex.Message;
            StackTrace = includeStackTrace ? ex.StackTrace : null;
        }
    }
}

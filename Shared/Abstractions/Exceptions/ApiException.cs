namespace Shared.Abstractions.Exceptions
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string message = null,string detail=null) : base(statusCode, message)
        {
            Detail = detail;
        }
        public string Detail { get; set; }
    }
}

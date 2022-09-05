namespace Shared.Abstractions.Exceptions
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base()
        {
        }
        public IEnumerable<string> Errors { get; set; }
    }
}

namespace Talabat.APIs.Errors
{
    public class ApiExceptionsResponse : ApiResponse
    {
        public string? Details { get; set; }

        public ApiExceptionsResponse(int statusCode, string? message = null, string? details = null)
            : base(statusCode, message)
        {
            Details = details;
        }
    }
}

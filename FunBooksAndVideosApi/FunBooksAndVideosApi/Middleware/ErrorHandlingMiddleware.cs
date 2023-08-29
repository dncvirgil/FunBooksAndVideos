using Newtonsoft.Json;

namespace FunBooksAndVideos.Api.Middleware
{
    /// <summary>
    /// Error handling middleware
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor that sets the next component delegate
        /// </summary>
        /// <param name="next">Next component from the pipeline to be invoked.</param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Responsible for calling next component and handle errors if any
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <param name="logger">ILogger of ErrorHandlingMiddleware</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, exception.Message);
                await HandleException(context, exception);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            var apiError = new ApiError { Error = exception.Message };
            var result = JsonConvert.SerializeObject(apiError);

            return context.Response.WriteAsync(result);
        }
    }

    internal class ApiError
    {
        public string Error { get; set; }
    }
}

using System.Text.Json;

namespace Api.Middlewares
{
    public class ApiKeyAuthMiddleware : IMiddleware
    {
        private readonly IConfiguration _configuration;
        private const string ApiKeyHeaderName = "X-Api-Key";
        private const string ApiKeySectionName = "Authentication:ApiKey";

        public ApiKeyAuthMiddleware(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
            {
                var response = new
                {
                    IsSuccess = false,
                    Message = "API key missing"
                };
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                return;
            }

            var apiKey = _configuration.GetValue<string>(ApiKeySectionName);
            if (!apiKey!.Equals(extractedApiKey))
            {
                var response = new
                {
                    IsSuccess = false,
                    Message = "Unauthorized"
                };
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                return;
            }

            await next(context);
        }
    }
}

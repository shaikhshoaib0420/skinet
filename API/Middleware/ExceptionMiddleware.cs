using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _requestDelegate;
    private readonly IHostEnvironment _env;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly HttpContext _httpContext;

    public ExceptionMiddleware(RequestDelegate requestDelegate, IHostEnvironment env, 
    ILogger<ExceptionMiddleware> logger
    )
    {
        _requestDelegate = requestDelegate;
        _env = env;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context) {
        try {
           await _requestDelegate(context);
        }
        catch (Exception ex) {
            _logger.LogError(ex, "An error occred!!!");

            context.Response.StatusCode = (int) StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new {
                StatusCode = (int) StatusCodes.Status500InternalServerError,
                Title = ex.Message,
                Details = ex.StackTrace
            };

            JsonSerializerOptions option = new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

            var serialized = JsonSerializer.Serialize(response, option);
            await context.Response.WriteAsync(serialized);

        }
    }
} 
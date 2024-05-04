namespace MinimalASP.Middleware
{
    public class HeaderValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HeaderValidationMiddleware> _logger;

        public HeaderValidationMiddleware(RequestDelegate next, ILogger<HeaderValidationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Проверка наличия заголовка и его значения
            if (context.Request.Headers.TryGetValue("X-Special-Header", out var headerValue))
            {

                _logger.LogInformation(headerValue);
                Console.WriteLine(headerValue);
                await _next(context); // Заголовок присутствует и значение корректно, продолжаем обработку

                //if (headerValue == "ValidValue")
                //{
                //    _logger.LogInformation("Access granted: X-Special-Header is valid.");
                //    await _next(context); // Заголовок присутствует и значение корректно, продолжаем обработку
                //}
                //else
                //{
                //    // Заголовок есть, но его значение некорректно
                //    _logger.LogWarning($"Access denied: X-Special-Header value '{headerValue}' is invalid. Request for {context.Request.Path} was denied.");
                //    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                //    await context.Response.WriteAsync("Invalid header value");
                //}
            }
           



            //else
            //{
            //    // Заголовок отсутствует
            //    _logger.LogWarning($"Access denied: Missing X-Special-Header. Request for {context.Request.Path} was denied.");
            //    context.Response.StatusCode = StatusCodes.Status400BadRequest;
            //    await context.Response.WriteAsync("Missing header");
            //}

            //////////////////////////////////////////////////////////////////////////////////////
            //if (context.Request.Headers.TryGetValue("X1-Special-Header", out var requestValue))
            //{
            //    if (requestValue == "RequestValue")
            //    {
            //        _logger.LogInformation("Access granted: X1-Special-Header is valid. 2+2");
            //        await _next(context); // Заголовок присутствует и значение корректно, продолжаем обработку
            //    }
            //    else
            //    {
            //        // Заголовок есть, но его значение некорректно
            //        _logger.LogWarning($"Access denied: X1-Special-Header value '{requestValue}' is invalid. Request for {context.Request.Path} was denied.");
            //        context.Response.StatusCode = StatusCodes.Status403Forbidden;
            //        await context.Response.WriteAsync("Invalid header value");
            //    }
            //}
            //else
            //{
            //    // Заголовок отсутствует
            //    _logger.LogWarning($"Access denied: Missing X1-Special-Header. Request for {context.Request.Path} was denied.");
            //    context.Response.StatusCode = StatusCodes.Status400BadRequest;
            //    await context.Response.WriteAsync("Missing header");
            //}
















            /*
            if (!context.Request.Headers.ContainsKey("X-Special-Header"))
            {
                _logger.LogWarning($"Access denied: Missing X-Special-Header. Request for {context.Request.Path} was denied.");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }
            if (context.Request.Headers.ContainsKey("X1-Special-Header"))
            {
                _logger.LogWarning($"X1-Special-Header");
                //context.Response.StatusCode = StatusCodes.Status400BadRequest;
                
            }
            if (context.Request.Headers.ContainsKey("X2-Special-Header"))
            {
                _logger.LogWarning($"X2-Special-Header");
                //context.Response.StatusCode = StatusCodes.Status400BadRequest;

            }
            if (context.Request.Headers.ContainsKey("X3-Special-Header"))
            {
                _logger.LogWarning($"X3-Special-Header");

            }

            _logger.LogInformation("Access granted: X-Special-Header found.");
            await _next(context);
            */
        }
    }
    public static class HeaderValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseHeaderValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HeaderValidationMiddleware>();
        }
    }
    /*
     HeaderValidationMiddlewareExtensions является статическим классом, который содержит метод расширения для IApplicationBuilder. 
    Этот метод позволяет легко подключать и использовать HeaderValidationMiddleware в приложении ASP.NET Core.

    Когда вызывается метод UseHeaderValidation, он добавляет HeaderValidationMiddleware в конвейер обработки запросов. 
    Это обеспечивает проверку заголовков запроса, в частности наличие заголовка с именем "X-Special-Header". Если этот заголовок отсутствует, то запрос завершается с кодом состояния 400 (Bad Request) и записывается сообщение об ошибке в журнал. Если заголовок присутствует, то запрос передается дальше по конвейеру для дальнейшей обработки.

    Использование HeaderValidationMiddlewareExtensions позволяет упростить добавление и 
    настройку промежуточного ПО для проверки заголовков запроса в ASP.NET Core приложении.
     */
}

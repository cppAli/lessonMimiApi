namespace MinimalASP.Middleware
{
    public class RequestSecondLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestSecondLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Логируем начало обработки запроса
            //Debug.WriteLine($"Запрос {context.Request.Method} {context.Request.Path} начал обрабатываться");


            Console.WriteLine($"Запрос {context.Request.Method} {context.Request.Path} начал обрабатываться Request Second LoggingMiddleware ");
            // Передаем управление следующему компоненту в цепочке
            await _next(context);

            // Логируем завершение обработки запроса
            //Debug.WriteLine($"Запрос {context.Request.Method} {context.Request.Path} обработан с статус-кодом {context.Response.StatusCode}");

            Console.WriteLine($"Запрос {context.Request.Method} {context.Request.Path} обрабтан Request Second LoggingMiddleware");
        }
    }
}

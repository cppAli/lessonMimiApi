namespace MinimalASP.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Логика перед обработкой запроса
            // Например, логирование информации о запросе

            Console.WriteLine($"Запрос {context.Request.Method} {context.Request.Path} начал обрабатываться CustomMiddleware");

            await _next(context); // Передача управления следующему middleware

            // Логика после обработки запроса
            // Например, изменение HTTP-заголовков в ответе
        }
    }
}

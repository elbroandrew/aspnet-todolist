using Microsoft.AspNetCore.Mvc.Filters;
using ProductApi.Data;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class TransactionalAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        // Получаем DbContext из DI-контейнера
        var dbContext = context.HttpContext.RequestServices
            .GetRequiredService<AppDbContext>(); // Замените YourDbContext на ваш контекст

        // Начинаем транзакцию
        await using var transaction = await dbContext.Database.BeginTransactionAsync();

        try
        {
            // Выполняем метод контроллера/сервиса
            var result = await next();

            // Если не было исключений — коммитим
            if (result.Exception == null)
                await transaction.CommitAsync();
        }
        catch
        {
            // При ошибке — откатываем
            await transaction.RollbackAsync();
            throw; // Пробрасываем исключение дальше
        }
    }
}
namespace DrinkDispenser.Application.Extensions;

public static class TaskExtensions
{
    public static async Task<R> ThenAsync<T, R>(this
        Task<T> task,
        Func<T, CancellationToken, Task<R>> afterTask,
        CancellationToken cancellationToken = default)
    {
        var result = await task.ConfigureAwait(false);

        return await afterTask(result, cancellationToken);
    }

    public static async Task ThenAsync<T>(this
        Task<T> task,
        Func<T, CancellationToken, Task> afterTask,
        CancellationToken cancellationToken = default)
    {
        var result = await task.ConfigureAwait(false);

        await afterTask(result, cancellationToken);
    }

    public static async Task<R> ThenAsync<T, R>(this
        Task<T> task,
        Func<T, R> afterTask)
    {
        var result = await task.ConfigureAwait(false);

        return afterTask(result);
    }

    public static async Task<T> ThenDoAsync<T>(this
        Task<T> task,
        Action<T> afterTask)
    {
        var result = await task.ConfigureAwait(false);

        afterTask(result);

        return result;
    }
}
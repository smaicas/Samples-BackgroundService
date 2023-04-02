namespace Nj.Samples.BackgroundTaskWorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger) => _logger = logger;

    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="ArgumentOutOfRangeException">The <paramref name="millisecondsDelay" /> argument is less than -1.</exception>
    /// <exception cref="ObjectDisposedException">The provided <paramref name="cancellationToken" /> has already been disposed.</exception>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
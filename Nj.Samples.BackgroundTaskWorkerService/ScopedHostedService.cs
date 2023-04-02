namespace Nj.Samples.BackgroundTaskWorkerService;

internal interface IScopedProcessingService
{
    Task DoWork(CancellationToken stoppingToken);
}

internal class ScopedProcessingService : IScopedProcessingService
{
    private readonly ILogger _logger;
    private int _executionCount;

    public ScopedProcessingService(ILogger<ScopedProcessingService> logger) => _logger = logger;

    public async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _executionCount++;

            _logger.LogInformation(
                "Scoped Processing Service is working. Count: {Count}", _executionCount);

            await Task.Delay(10000, stoppingToken);
        }
    }
}
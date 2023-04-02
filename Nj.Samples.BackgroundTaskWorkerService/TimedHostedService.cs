namespace Nj.Samples.BackgroundTaskWorkerService;

public class TimedHostedService : IHostedService, IDisposable
{
    private readonly ILogger<TimedHostedService> _logger;
    private int _executionCount;
    private Timer? _timer;

    public TimedHostedService(ILogger<TimedHostedService> logger) => _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public void Dispose() => _timer?.Dispose();

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        int count = Interlocked.Increment(ref _executionCount);
        _logger.LogInformation(
            "Timed Hosted Service is working. Count: {Count}", count);
    }
}
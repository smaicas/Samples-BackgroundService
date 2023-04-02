using Nj.Samples.BackgroundTaskWorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // Caso 1: Worker
        services.AddHostedService<Worker>();

        //// Caso 2: Timed Hosted Service
        services.AddHostedService<TimedHostedService>();

        // Caso 3: Scoped Process Service
        services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
        services.AddHostedService<ConsumeScopedServiceHostedService>();
    })
    .Build();

host.Run();
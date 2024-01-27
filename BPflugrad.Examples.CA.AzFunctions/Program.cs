using BPflugrad.Examples.CA.Adapters.Controllers;
using BPflugrad.Examples.CA.Adapters.Gateways;
using BPflugrad.Examples.CA.Adapters.Interfaces;
using BPflugrad.Examples.CA.Application;
using BPflugrad.Examples.CA.Application.Interfaces;
using BPflugrad.Examples.CA.Infra.Web;
using BPflugrad.Examples.CA.Infra.Web.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        // Add the Application Use Case "UseCase" as a transient resolved by dependency on IInputPort<Guid>.
        services.AddTransient<IInputPort<Guid>, UseCase>();
        // Add the Gateway "UseCaseGateway" as a transient resolved by dependency IGateway<Guid, UseCaseResponse>.
        services.AddTransient<IGateway<Guid, UseCaseResponse>, UseCaseGateway>();
        // Add the Controller "UseCaseController" as a transient resolved by dependency IController<Guid>.
        services.AddTransient<IController<Guid>, UseCaseController>();

        // Add scoped JsonUseCasePresenter as itself.
        services.AddScoped<JsonUseCasePresenter>();
        // Add JsonUseCasePresenter scoped and resolved by IOutputPort<UseCaseResponse>.
        services.AddScoped<IOutputPort<UseCaseResponse>>(s => s.GetRequiredService<JsonUseCasePresenter>());
        // Add JsonUseCasePresenter scoped and resolved by IHttpResponseDataPresenter.
        services.AddScoped<IHttpResponseDataPresenter>(s => s.GetRequiredService<JsonUseCasePresenter>());
        // By registering JsonUseCasePresenter as both IOutputPort<UseCaseResponse> and IHttpResponseDataPresenter we ensure that
        // UseCase is unaware of PresentAsync(HttpRequestData) and UseCaseFunction is unaware of ExecuteAsync(UseCaseResponse).
    })
    .Build();

host.Run();

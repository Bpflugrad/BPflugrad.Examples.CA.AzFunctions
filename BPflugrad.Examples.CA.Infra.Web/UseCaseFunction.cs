using BPflugrad.Examples.CA.Adapters.Controllers;
using BPflugrad.Examples.CA.Adapters.Interfaces;
using BPflugrad.Examples.CA.Infra.Web;
using BPflugrad.Examples.CA.Infra.Web.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace BPflugrad.Examples.CA.AzFunctions
{
    /// <summary>
    /// Example Azure Function using Clean Architecture.
    /// </summary>
    public class UseCaseFunction
    {
        private readonly ILogger<UseCaseFunction> _logger;
        private readonly IController<Guid> controller;
        private readonly IHttpResponseDataPresenter presenter;

        /// <summary>
        /// Constructor depending only on abstractions resolved from Dependency Injection.
        /// </summary>
        public UseCaseFunction(ILogger<UseCaseFunction> logger, IController<Guid> controller, IHttpResponseDataPresenter presenter)
        {
            _logger = logger;
            this.controller = controller;
            this.presenter = presenter;
        }


        /// <summary>
        /// Executes <see cref="UseCaseController"/> then <see cref="JsonUseCasePresenter"/> and returns the result.
        /// </summary>
        [Function(nameof(ExecuteUseCase))]
        public async Task<HttpResponseData> ExecuteUseCase([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            var guid = Guid.NewGuid();

            _logger.LogInformation($"C# HTTP trigger function processed a request ('{guid}').");
            await controller.ExecuteAsync(guid);
            var response = await presenter.PresentAsync(req);
            return response;
        }
    }
}

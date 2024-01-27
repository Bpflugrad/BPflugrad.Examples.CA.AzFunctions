using BPflugrad.Examples.CA.Application.Interfaces;

namespace BPflugrad.Examples.CA.Application
{
    /// <summary>
    /// The example Use Case Command.
    /// </summary>
    public class UseCase : IInputPort<Guid>
    {
        private readonly IOutputPort<UseCaseResponse> outputPort;
        private readonly IGateway<Guid, UseCaseResponse> gateway;

        /// <summary />
        public UseCase(IOutputPort<UseCaseResponse> outputPort, IGateway<Guid, UseCaseResponse> gateway)
        {
            this.outputPort = outputPort;
            this.gateway = gateway;
        }

        /// <summary>
        /// Fetches data from the Gateway and returns.
        /// </summary>
        /// <param name="request">Guid</param>
        /// <returns><see cref="UseCaseResponse"/></returns>
        public async Task ExecuteAsync(Guid request)
        {
            var response = await gateway.ExecuteAsync(request);

            await outputPort.ExecuteAsync(response);
        }
    }
}

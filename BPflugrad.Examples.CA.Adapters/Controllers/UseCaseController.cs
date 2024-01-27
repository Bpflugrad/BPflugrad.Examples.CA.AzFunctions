using BPflugrad.Examples.CA.Adapters.Interfaces;
using BPflugrad.Examples.CA.Application.Interfaces;

namespace BPflugrad.Examples.CA.Adapters.Controllers
{
    /// <summary>
    /// Controller accepting an argument an executing a Use Case.
    /// </summary>
    public class UseCaseController : IController<Guid>
    {
        private readonly IInputPort<Guid> useCase;

        /// <summary>
        /// Accepts the InputPort, representing a Use Case.
        /// </summary>
         public UseCaseController(IInputPort<Guid> useCase)
        {
            this.useCase = useCase;
        }

        /// <summary />
        public async Task ExecuteAsync(Guid request)
        {
            await useCase.ExecuteAsync(request);
        }
    }
}

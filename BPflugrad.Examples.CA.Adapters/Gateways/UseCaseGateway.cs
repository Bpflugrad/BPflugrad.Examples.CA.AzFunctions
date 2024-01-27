using BPflugrad.Examples.CA.Application;
using BPflugrad.Examples.CA.Application.Interfaces;

namespace BPflugrad.Examples.CA.Adapters.Gateways
{
    /// <summary>
    /// Gateway returning some "useful" work to the Use Case.
    /// </summary>
    /// <remarks>
    /// Real projects would execute methods on interfaces implemented in other Infrastructure layers to retrieve data.
    /// </remarks>
    public class UseCaseGateway : IGateway<Guid, UseCaseResponse>
    {
        /// <summary />
        public Task<UseCaseResponse> ExecuteAsync(Guid request)
        {
            return Task.FromResult(new UseCaseResponse
                {
                    Id = request,
                    Name = "This is the Name"
                }
            );
        }
    }
}

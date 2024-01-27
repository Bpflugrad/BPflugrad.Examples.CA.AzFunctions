using BPflugrad.Examples.CA.Application;
using BPflugrad.Examples.CA.Application.Interfaces;

namespace BPflugrad.Examples.CA.Adapters.Presenters
{
    /// <summary>
    /// Abstract Class implementing <see cref="IOutputPort{T}"/> to accept a response object.
    /// </summary>
    public abstract class UseCasePresenter : IOutputPort<UseCaseResponse>
    {
        /// <summary>
        /// Protected property storing the Use Case response object.
        /// </summary>
        protected UseCaseResponse? Response { get; private set; }

        /// <summary />
        public Task ExecuteAsync(UseCaseResponse response)
        {
            Response = response;
            return Task.CompletedTask;
        }
    }
}

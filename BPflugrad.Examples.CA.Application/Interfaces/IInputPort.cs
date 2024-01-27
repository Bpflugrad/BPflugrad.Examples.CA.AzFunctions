namespace BPflugrad.Examples.CA.Application.Interfaces
{
    /// <summary>
    /// Abstraction of a Command accepting an input request.
    /// </summary>
    /// <remarks>
    /// All Use Cases in the Application Layer should implement this interface.
    /// </remarks>
    public interface IInputPort<T>
    {
        /// <summary />
        Task ExecuteAsync(T request);
    }
}

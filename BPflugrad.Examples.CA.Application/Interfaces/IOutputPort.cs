namespace BPflugrad.Examples.CA.Application.Interfaces
{
    /// <summary>
    /// Abstraction of a Command accepting an output Response.
    /// </summary>
    /// <remarks>
    /// All Use Cases should accept one of these as a Constructor argument.
    /// </remarks>
    public interface IOutputPort<T>
    { 
        /// <summary />
        Task ExecuteAsync(T response);
    }
}

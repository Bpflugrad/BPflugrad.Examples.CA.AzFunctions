namespace BPflugrad.Examples.CA.Adapters.Interfaces
{
    /// <summary>
    /// Abstraction of a Command that will execute a Use Case.
    /// </summary>
    public interface IController<T>
    {
        /// <summary />
        Task ExecuteAsync(T request);
    }
}

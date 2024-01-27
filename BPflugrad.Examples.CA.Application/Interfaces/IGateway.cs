namespace BPflugrad.Examples.CA.Application.Interfaces
{
    /// <summary>
    /// A Gateway Command that does not expect a response.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGateway<T>
    {
        /// <summary />
        Task ExecuteAsync(T request);
    }

    /// <summary>
    /// A Gateway Command that expects a response.
    /// </summary>
    public interface IGateway<TRequest, TResponse>
    {
        /// <summary />
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}

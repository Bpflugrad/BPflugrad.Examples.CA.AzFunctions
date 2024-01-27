using Microsoft.Azure.Functions.Worker.Http;

namespace BPflugrad.Examples.CA.Infra.Web.Interfaces
{
    /// <summary>
    /// Abstraction of a Presenter that accepts an HttpRequestData and returns an HttpResponseData.
    /// </summary>
    public interface IHttpResponseDataPresenter
    {
        /// <summary />
        Task<HttpResponseData> PresentAsync(HttpRequestData request);
    }
}

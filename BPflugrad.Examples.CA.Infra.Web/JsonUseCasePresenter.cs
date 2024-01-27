using BPflugrad.Examples.CA.Adapters.Presenters;
using BPflugrad.Examples.CA.Infra.Web.Interfaces;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;
using System.Text;

namespace BPflugrad.Examples.CA.Infra.Web
{
    /// <summary>
    /// Extends <see cref="UseCasePresenter"/>, granting access to the Response and implements <see cref="IHttpResponseDataPresenter"/> for formatting the response.
    /// </summary>
    public class JsonUseCasePresenter : UseCasePresenter, IHttpResponseDataPresenter
    {
        /// <summary>
        /// Accesses the protected Response property, formatting it appropriately.
        /// </summary>
        public async Task<HttpResponseData> PresentAsync(HttpRequestData request)
        {
            if (Response is null)
                throw new InvalidOperationException();

            var response = request.CreateResponse();

            await response.Body.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Response)));

            return response;
        }
    }
}

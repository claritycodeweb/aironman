using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Threading.Tasks;


namespace AIronMan.Api.Common.Result
{
    public class HttpActionResult : IHttpActionResult
    {
        private readonly string value;
        private readonly HttpRequestMessage request;
        private readonly HttpStatusCode status;

        public HttpActionResult(HttpStatusCode status, string value, HttpRequestMessage request)
        {
            this.value = value;
            this.request = request;
            this.status = status;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(this.status)
            {
                Content = new StringContent(this.value),
                RequestMessage = this.request,
            };
            return Task.FromResult(response);
        }
    }
}
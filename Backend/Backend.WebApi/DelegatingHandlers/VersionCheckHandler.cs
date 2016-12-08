using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;

namespace Backend.WebApi.DelegatingHandlers
{
    public class VersionCheckHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // 1. Stuff you do here happens before request reaches controller - and filters
            HttpResponseMessage response = null;
            Debug.WriteLine("First delegating handler - before filters and controller");
            var keyVersion = request.Headers.FirstOrDefault(v => v.Key == "x-version");
            if (keyVersion.Key != null)
            {
                var s = keyVersion.Value.FirstOrDefault();
                if (s.Equals("42"))
                {
                    // 2. Call the next link in the chain
                    response = await base.SendAsync(request, cancellationToken);
                }
            }
            if (response == null)
            {
                var result = new StatusCodeResult((HttpStatusCode)418, request);
                response = await result.ExecuteAsync(cancellationToken);
            }
            // 3. Stuff you do here happens after request reaches controller - and filters
            Debug.WriteLine("First delegating handler - after filters and controller");
            // 4. Return a response to client
            return response;
        }
    }
}
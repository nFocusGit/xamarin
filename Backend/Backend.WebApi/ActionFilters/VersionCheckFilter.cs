using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace Backend.WebApi.ActionFilters
{
    public class VersionCheckFilter : IActionFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            HttpResponseMessage response = null;

            // 1. Stuff you do here will happen before the controller action method
            Debug.WriteLine("VersionCheckFilter: Before controller method");

            var keyVersion = actionContext.Request.Headers.FirstOrDefault(v => v.Key == "x-version");
            if (keyVersion.Key != null)
            {
                var s = keyVersion.Value.First();
                if (s.Equals("42"))
                {
                    // 2. Now we send the request to the next link in the chain of filters
                    // (or to the controller if we are at the end)
                    response = await continuation();
                }
            }
            if (response == null)
            {
                var result = new StatusCodeResult((HttpStatusCode)418, actionContext.Request);
                response = await result.ExecuteAsync(cancellationToken);
            }
            // 3. Stuff you do here will happen after the controller action method
            Debug.WriteLine("VersionCheckFilter: After controller method");
            // 4. Return response thereby continuing back up the chain of filters
            return response;
        }
    }
}
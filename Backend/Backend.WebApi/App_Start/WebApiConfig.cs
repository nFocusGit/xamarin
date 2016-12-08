using Backend.WebApi.ActionFilters;
using Backend.WebApi.DelegatingHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using static Backend.WebApi.Controllers.ProductsController;

namespace Backend.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Register the global exception handler
            config.Services.Replace(typeof(IExceptionHandler),
                new NotFoundExceptionHandler());

            // Used to do jobs before "AUTH"
            // Register delegating handlers
            //config.MessageHandlers.Add(new FirstDelegatingHandler());
            //config.MessageHandlers.Add(new SecondDelegatingHandler());
            config.MessageHandlers.Add(new VersionCheckHandler());

            //// ActionFilter
            //// http://www.tutorialsteacher.com/webapi/web-api-filters
            // Register action filters
            //config.Filters.Add(new FirstActionFilter());
            //config.Filters.Add(new SecondActionFilter());
            //config.Filters.Add(new VersionCheckFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}

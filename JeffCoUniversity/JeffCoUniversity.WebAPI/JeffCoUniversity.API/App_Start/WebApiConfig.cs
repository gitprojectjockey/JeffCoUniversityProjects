using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace JeffCoUniversity.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // NOTE: GLOBAL ASAX HAS ALL MY OTHER REGISTATIONS


            // Setup media type formatters
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            //I installed Install-Package Microsoft.AspNet.WebApi.Cors and enabled Cors on this service
            //By Installing CORS or Cross - Origin Requests on the web service I am able to call the products api using stright json with ajax
            //from a cross domain client.

            //This enables CORS for all controllers and actions (GLOBAL) you can also do this at the controller of action level
            var cors = new EnableCorsAttribute("*", "*", "get,post,put,delete");
            
            config.EnableCors();

            //This is required if you want your tokens to expire properly with OAuth Bearer Tokens
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //This Service uses attribute routing only so we need to call config.MapHttpAttributeRoutes() to enable it.      
            config.MapHttpAttributeRoutes();

            // Only allow json formatting by removing the xml formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Only allow xml formatting by removing the json formatter
            // config.Formatters.Remove(config.Formatters.JsonFormatter);
        }
    }
}

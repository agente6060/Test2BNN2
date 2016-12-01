using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace PalabrasPalindromos.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        Dictionary<string, bool> palindromoDic { get; set; }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            palindromoDic = new Dictionary<string, bool>();
        }
    }
}
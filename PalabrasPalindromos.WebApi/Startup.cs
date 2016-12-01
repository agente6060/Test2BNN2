using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace PalabrasPalindromos.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Dictionary<string, bool> palindromoDict = new Dictionary<string, bool>();
        }
    }
}
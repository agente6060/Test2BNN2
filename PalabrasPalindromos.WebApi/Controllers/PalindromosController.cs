using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PalabrasPalindromos.WebApi.Controllers
{
    [RoutePrefix("api/palindromo")]
    public class PalindromosController : ApiController
    {
        [Route("Palindromo")]
        public bool EsPalindromo(string palabra)
        {

        }
    }
}

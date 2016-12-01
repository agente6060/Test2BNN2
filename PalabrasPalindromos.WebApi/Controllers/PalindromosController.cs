using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessApi;
using Entities;

namespace PalabrasPalindromos.WebApi.Controllers
{
    [RoutePrefix("api/palindromos")]
    public class PalindromosController : ApiController
    {
        BAPIPalindromo palind = new BAPIPalindromo();

        [Route("Palindromo")]
        [System.Web.Http.HttpGet]
        public bool EsPalindromo(string palabra)
        {
            return palind.EsPalindromo(palabra);
        }

        [Route("Agregar")]
        [System.Web.Http.HttpPost]
        public bool AgregarPalabra(string palabra)
        {
            return palind.AgregraPalabra(palabra);
        }

        [Route("Eliminar")]
        [System.Web.Http.HttpPost]
        public bool EliminarPalabra(string palabra)
        {
            return palind.Eliminarpalabra(palabra);
        }

        [Route("Consultar")]
        [System.Web.Http.HttpGet]
        public IEnumerable<Palindromo> ConsultarPalabras()
        {
            return palind.ConsultaPalabras();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Business;
using System.Collections;
using System.Web.Caching;
using System.Web;

namespace BusinessApi
{
    public class BAPIPalindromo
    {
        Dictionary<string, bool> palindromoDic { get; set; }

        public BAPIPalindromo()
        {
            palindromoDic = new Dictionary<string, bool>();
        }

        public bool EsPalindromo(string palabra)
        {
            bool result = false;
            if (HttpContext.Current.Cache["Palabras"] != null)
            {
                palindromoDic = HttpContext.Current.Cache["Palabras"] as Dictionary<string, bool>;
            }

            if (palindromoDic.ContainsKey(palabra))
            {
                palindromoDic.TryGetValue(palabra, out result);
            }
            else
            {
                BPalindromo buss = new BPalindromo();
                var resPalindromo = buss.ValidarPalindromos(new List<string> { palabra });
                palindromoDic.Add(palabra, resPalindromo.FirstOrDefault().EsPalindromo);
                result = resPalindromo.FirstOrDefault().EsPalindromo;
            }
            if (HttpContext.Current.Cache["Palabras"] == null)
            {
                HttpContext.Current.Cache.Insert("Palabras", palindromoDic, null, DateTime.Now.AddMinutes(15), TimeSpan.Zero);
            }

            return result;
        }

        public bool AgregraPalabra(string palabra)
        {
            if (HttpContext.Current.Cache["Palabras"] != null)
            {
                palindromoDic = HttpContext.Current.Cache["Palabras"] as Dictionary<string, bool>;
            }
            if (palindromoDic.ContainsKey(palabra))
            {
                return true;
            }
            else
            {
                BPalindromo buss = new BPalindromo();
                var resPalindromo = buss.ValidarPalindromos(new List<string> { palabra });
                palindromoDic.Add(palabra, resPalindromo.FirstOrDefault().EsPalindromo);
                HttpContext.Current.Cache.Remove("Palabras");
                HttpContext.Current.Cache.Insert("Palabras", palindromoDic, null, DateTime.Now.AddMinutes(15), TimeSpan.Zero);

                return true;
            }
            
        }

        public bool Eliminarpalabra(string palabra)
        {
            if (HttpContext.Current.Cache["Palabras"] != null)
            {
                palindromoDic = HttpContext.Current.Cache["Palabras"] as Dictionary<string, bool>;
            }

            if (palindromoDic.ContainsKey(palabra))
            {
                palindromoDic.Remove(palabra);
                HttpContext.Current.Cache.Remove("Palabras");
                HttpContext.Current.Cache.Insert("Palabras", palindromoDic, null, DateTime.Now.AddMinutes(15), TimeSpan.Zero);

            }
            return true;
        }

        public List<Palindromo> ConsultaPalabras()
        {
            if (HttpContext.Current.Cache["Palabras"] != null)
            {
                palindromoDic = HttpContext.Current.Cache["Palabras"] as Dictionary<string, bool>;
            }
            ICollection keys = palindromoDic.Keys;
            List<Palindromo> palabras = new List<Palindromo>();
            foreach (var key in keys)
            {
                bool value = false;
                palindromoDic.TryGetValue(key.ToString(), out value);
                palabras.Add(new Palindromo { Palabra = key.ToString(), EsPalindromo = value });
            }
            return palabras;
        }
    }
}

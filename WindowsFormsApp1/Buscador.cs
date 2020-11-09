using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Buscardor
{
    public class Buscador
    {
        public static int Contar(string busqueda, string texto)
        {
            busqueda = formatear(busqueda);
            texto = formatear(texto);
            var conteo = Regex.Matches(texto, busqueda).Count;
            return conteo;
        }

        public static Dictionary<string, int> listaRepetidos(string texto)
        {
            var lista = new Dictionary<string, int>();
            var textoF = formatear(texto).Replace("\n", "");
            char[] simbolos = Regex.Replace(textoF, @"[a-zA-z0-9ñÑäëïöü ]+", "").ToString().ToCharArray();
            if(simbolos.Length > 0)
            {
                var listaConteo = from i in simbolos group i by i into g select new { g.Key, Sum = g.Count() };
                foreach(var item in listaConteo) if(item.Sum > 1) lista.Add(item.Key.ToString(), item.Sum);
            }
            var palabras = Regex.Replace(textoF, @"[\,\.\;\?\¿\¡\!]+", " ").Split(' ');
            if (palabras.Length > 0)
            {
                var listaConteo = from i in palabras where i != "" group i by i into g select new { g.Key, Sum = g.Count() };
                foreach (var item in listaConteo) if (item.Sum > 1) lista.Add(item.Key, item.Sum);
            }
            return lista;
        }


        public static string formatear(string texto)
        {
            return texto.ToLower().Replace('á', 'a').Replace('é', 'e').Replace('í', 'i').Replace('ó', 'o').Replace('ú', 'u');
        }
    }
}

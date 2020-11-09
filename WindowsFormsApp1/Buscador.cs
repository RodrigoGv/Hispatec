using System.Text.RegularExpressions;

namespace Buscardor
{
    public class Buscador
    {
        public static int Contar(string busqueda, string texto)
        {
            busqueda = busqueda.ToLower();
            texto = texto.ToLower();
            var conteo = Regex.Matches(texto, busqueda).Count;
            return conteo;
        }
    }
}

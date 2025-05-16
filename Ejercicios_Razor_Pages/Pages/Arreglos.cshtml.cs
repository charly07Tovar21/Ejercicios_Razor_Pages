using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejercicios_Razor_Pages.Pages
{
    public class ArreglosModel : PageModel
    {
        [BindProperty]
        public int[] Numeros { get; set; } = Array.Empty<int>();
        [BindProperty]
        public int[] NumerosOrdenados { get; set; } = Array.Empty<int>();
        public double Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Moda { get; set; } = new List<int>();
        public double Mediana { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Generar 20 números aleatorios entre 0 y 100
            var random = new Random();
            Numeros = Enumerable.Range(0, 20)
                               .Select(_ => random.Next(0, 101))
                               .ToArray();
            //Ordenar numeros de menor a mayor
            NumerosOrdenados = Numeros.OrderBy(n => n).ToArray();

            // Calcular suma
            Suma = Numeros.Sum();

            // Calcular promedio
            Promedio = Numeros.Average();

            // Calcular moda
            var grupos = Numeros.GroupBy(n => n).OrderByDescending(g => g.Count()).ToList();
            int masFrecuente = grupos.First().Count();
            Moda = grupos.Where(g => g.Count() == masFrecuente).Select(g => g.Key).ToList();

            // Calcular mediana
            var numerosMediana = Numeros.OrderBy(n => n).ToArray();
            if (numerosMediana.Length % 2 == 0)
            {
                int medio1 = numerosMediana[(numerosMediana.Length / 2) - 1];
                int medio2 = numerosMediana[numerosMediana.Length / 2];
                Mediana = (medio1 + medio2) / 2.0;
            }
            else
            {
                Mediana = numerosMediana[numerosMediana.Length / 2];
            }
            return Page();
        }
    }
}


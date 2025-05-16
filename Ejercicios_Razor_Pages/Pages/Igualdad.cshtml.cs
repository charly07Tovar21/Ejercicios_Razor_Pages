using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejercicios_Razor_Pages.Pages
{
    public class IgualdadModel : PageModel
    {
        [BindProperty]
        public int a { get; set; } = 0;
        [BindProperty]
        public int b { get; set; } = 0;
        [BindProperty]
        public int x { get; set; } = 0;
        [BindProperty]
        public int y { get; set; } = 0;
        [BindProperty]
        public int n { get; set; } = 0;
        [BindProperty]
        public int resultado1 { get; set; }
        public string Paso1Direct { get; set; } // (a·x + b·y)^n
        public string Paso2Direct { get; set; } // (suma de las multiplicaciones)^n
        public string Paso3Direct { get; set; } // (total elevado a la n)^n

        public int ResultSumatoria { get; set; } // Resultado de la sumatoria
        public List<string> Terminos { get; set; } = new List<string>();

        public void OnGet()
        {
        }

        public void OnPost()
        {
            //int expresion = (a * x) + (b * y);
            int ax = a * x;
            int by = b * y;
            int suma = ax + by;
            resultado1 = (int)Math.Pow(suma, n);
            //Demostrar operación directa
            Paso1Direct = $"({a}·{x} + {b}·{y})<sup>{n}</sup>";
            Paso2Direct = $"({ax} + {by})<sup>{n}</sup>";
            Paso3Direct = $"({suma})<sup>{n}</sup>";

            // Implementación de la otra resolución 
            ResultSumatoria = 0;
            Terminos.Clear();

            for (int k = 0; k <= n; k++)
            {
                int coeficiente = Binomial(n, k);
                int terminoAx = (int)Math.Pow(a * x, n - k);
                int terminoBy = (int)Math.Pow(b * y, k);
                int terminoTotal = coeficiente * terminoAx * terminoBy;

                ResultSumatoria += terminoTotal;

                // Demostrar operación en base a la formula de la sumatoria
                Terminos.Add(
                    $@"<div class='termino'>
                    $\binom{{@Model.n}}{{{k}}} \cdot 
                    ({a} \cdot {x})^{{{n - k}}} \cdot 
                    ({b} \cdot {y})^{{{k}}} = 
                    {coeficiente} \cdot {terminoAx} \cdot {terminoBy} = {terminoTotal}$
                    </div>"
);
            }
        }

        private static int Binomial(int n, int k)
        {
            if (k > n) return 0;
            if (k == 0 || k == n) return 1;

            int result = 1;
            for (int i = 1; i <= k; i++)
            {
                result *= n - (k - i);
                result /= i;
            }
            return result;
        }
    }
}

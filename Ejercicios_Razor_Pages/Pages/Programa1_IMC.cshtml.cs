using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejercicios_Razor_Pages.Pages
{
    public class Programa1_IMCModel : PageModel
    {
        [BindProperty]
        public string alt { get; set; } = "";
        [BindProperty]
        public string pes { get; set; } = "";

        public double imc = 0;
        public void OnGet()
        {
        }

        public void OnPost()
        {
            double altura = Convert.ToDouble(alt);
            double peso = Convert.ToDouble(pes);

            imc = Math.Round((peso / (altura/100.0 * altura/100.0)),2);

            ModelState.Clear();
        }
    }
}

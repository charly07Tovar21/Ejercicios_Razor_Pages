using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ejercicios_Razor_Pages.Pages
{
    public class Programa2_CodigoJCModel : PageModel
    {
        [BindProperty]
        public string textoCifrar { get; set; } = "";
        [BindProperty]
        public int desplazamiento { get; set; } = 0;

        public string accionRealizada { get; set; } = "";
        public string resultado { get; set; } = "";
        public void OnGet()
        {
        }

        public void OnPost(String accion)
        {
            if (string.IsNullOrEmpty(textoCifrar))
            {
                return;
            }

            desplazamiento = Math.Clamp(desplazamiento, 1, 25);

            switch (accion)
            {
                case "Cifrar":
                    resultado = cifrar(textoCifrar, desplazamiento);
                    accionRealizada = "Cifrado";
                    break;
                case "Descifrar":

                    resultado = cifrar(textoCifrar, 29 - desplazamiento);
                    accionRealizada = "Descifrado";
                    break;

                default:
                    resultado = "Acción no válida";
                    break;
            }
        }

        private string cifrar(string texto, int n)
        {
            char[] resultado = new char[texto.Length];

            for (int i = 0; i < texto.Length; i++)
            {
                char caracter = texto[i];
                switch (caracter)
                {
                    // Aplicamos la fórmula de cifrado César
                    // Aplicamos para letras mayúsculas
                    case >= 'A' and <= 'Z':
                        resultado[i] = (char)((((caracter - 'A') + n) % 26) + 'A');
                        break;

                    // Aplicamos para letras minúsculas
                    case >= 'a' and <= 'z':
                        resultado[i] = (char)((((caracter - 'a') + n) % 26) + 'a');
                        break;
                        // Aplicamos para números u otros caracteres, no se cifran
                        default:
                        resultado[i] = caracter;
                        break;
                }
            }
            return new string(resultado);
        }

    }
}

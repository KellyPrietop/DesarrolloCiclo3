using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.DTs
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioDT _repoDT;
        public DirectorTecnico dts { get; set; }

        public CreateModel(IRepositorioDT repoDT)
        {
            _repoDT = repoDT;
        }


        public void OnGet()
        {
            dts = new DirectorTecnico();
        }

        public IActionResult OnPost(DirectorTecnico dts)
        {
            if (ModelState.IsValid)
            {
                _repoDT.AddDT(dts);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }    
    }
}

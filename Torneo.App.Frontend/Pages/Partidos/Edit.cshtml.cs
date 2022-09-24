using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipo;


        public Partido partido {get; set;}
        public SelectList EquipoOptions { get; set; }
        public int EquipoSelected { get; set; }
        public SelectList EquiOptions { get; set; }
        public int EquiSelected { get; set; }
        

        public EditModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipo )
        {
            _repoPartido = repoPartido;
            _repoEquipo = repoEquipo;
        }

        public IActionResult OnGet(int id){
            partido = _repoPartido.GetPartido(id);
            EquipoOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            EquipoSelected = partido.Local.Id;
            EquiOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            EquiSelected = partido.Visitante.Id;
            
            if (partido == null){
                return NotFound();
            }
            else{
                return Page();
            }
        } 

        public IActionResult OnPost(Partido partido, int idEquipoLocal, int idEquipoVisitante)
        {
            _repoPartido.UpdatePartido(partido, idEquipoLocal, idEquipoVisitante);
            return RedirectToPage("Index");
        }  
    }
}

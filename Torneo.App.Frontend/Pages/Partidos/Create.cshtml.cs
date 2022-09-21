using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipo;

        public Partido partido { get; set; }
        public IEnumerable<Equipo> equipo { get; set; }
        

        public CreateModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipo)
        {
            _repoPartido = repoPartido;
            _repoEquipo =  repoEquipo;
        }


        public void OnGet()
        {
            partido = new Partido();
            equipo = _repoEquipo.GetAllEquipos();
        }

        public IActionResult OnPost(Partido partido, int idEquipoLocal, int idEquipoVisitante)
        {
                _repoPartido.AddPartido(partido, idEquipoLocal, idEquipoVisitante);
                return RedirectToPage("Index");
        }
    }
}

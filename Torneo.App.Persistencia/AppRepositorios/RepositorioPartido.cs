using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {
        private readonly DataContext _dataContext = new DataContext();
        
        public Partido AddPartido(Partido partido,int idEquipoLocal, int idEquipoVisitante)
        {
            var equipolEncontrado = _dataContext.Equipos.Find(idEquipoLocal);
            var equipovEncontrado = _dataContext.Equipos.Find(idEquipoVisitante);
            partido.Local = equipolEncontrado;
            partido.Visitante = equipovEncontrado;
            var partidoInsertado = _dataContext.Partidos.Add(partido);
            _dataContext.SaveChanges();
            return partidoInsertado.Entity;
        }


    }
}
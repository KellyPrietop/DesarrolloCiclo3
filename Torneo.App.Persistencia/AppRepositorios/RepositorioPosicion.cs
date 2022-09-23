using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioPosicion : IRepositorioPosicion
    {
        private readonly DataContext _dataContext = new DataContext();
        
        public Posicion AddPosicion(Posicion posicion)
        {
            var posicionInsertado = _dataContext.Posicion.Add(posicion);
            _dataContext.SaveChanges();
            return posicionInsertado.Entity;
        }

        public IEnumerable<Posicion> GetAllPosicion()
        {
            return _dataContext.Posicion;
        }

        public Posicion GetPosicion(int idPosicion)
        {
            var posicionEncontrado = _dataContext.Posicion.Find(idPosicion);
            return posicionEncontrado;
        }

        public Posicion UpdatePosicion(Posicion posicion)
        {
            var posicionEncontrado = _dataContext.Posicion.Find(posicion.Id);
            if (posicionEncontrado != null)
            {
                posicionEncontrado.Nombre = posicion.Nombre;
                _dataContext.SaveChanges();
            }
            return posicionEncontrado;
        }


    }
}
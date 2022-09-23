using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioMunicipio
    {
        public Municipio AddMunicipio(Municipio municipio);
        public IEnumerable<Municipio> GetAllMunicipios();  // metodo para consulta de datos
        public Municipio GetMunicipio(int idMunicipio);
        public Municipio UpdateMunicipio(Municipio municipio);
    }

}

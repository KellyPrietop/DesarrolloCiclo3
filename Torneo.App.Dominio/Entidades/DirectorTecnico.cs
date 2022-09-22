using System.ComponentModel.DataAnnotations;

namespace Torneo.App.Dominio
{
    public class DirectorTecnico
    {
        public int Id {get;set;}
        [Required(ErrorMessage = "El nombre del director es obligatorio")]
        public string Nombre {get;set;}
        [Required(ErrorMessage = "El documento es obligatorio")]
        public string Documento {get;set;}
        [Required(ErrorMessage = "El numero de telefono es obligatorio")]
        public string Telefono {get;set;}
    }
}
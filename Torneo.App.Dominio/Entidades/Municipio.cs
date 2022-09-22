using System.ComponentModel.DataAnnotations;
namespace Torneo.App.Dominio
{
    public class Municipio
    {
        public int Id {get;set;}
        [Required(ErrorMessage = "El nombre del municipio es obligatorio")]
        public string Nombre {get;set;}
        
    }
}
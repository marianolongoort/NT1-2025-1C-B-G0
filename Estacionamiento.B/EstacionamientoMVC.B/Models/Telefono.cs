using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.B.Models
{
    public class Telefono
    {
        public int Id { get; set; }

        public string Numero { get; set; }
        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }

        //public TipoTelefono Tipo { get; set; }
    }
}

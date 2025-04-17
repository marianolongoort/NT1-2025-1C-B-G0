using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.B.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }

        //Propiedad Navagacional
        public Persona Persona { get; set; }

        //Propiedad relacional
        public int PersonaId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstacionamientoMVC.B.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }

        //Propiedad Navagacional
        public Persona Duenio { get; set; }

        //Propiedad relacional
        [ForeignKey("Duenio")]
        public int DuenioId{ get; set; }


        public Persona Inquilino { get; set; }
        
        [ForeignKey("Inquilino")]
        public int? InquilinoId { get; set; }
    }
}

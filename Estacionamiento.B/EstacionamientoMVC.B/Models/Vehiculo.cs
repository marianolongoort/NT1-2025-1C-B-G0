using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.B.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{3}[A-Z]{2}$", ErrorMessage = "El formato de la {0} es inválido.")]
        public string Patente { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{3}\d{3}$", ErrorMessage = "El formato de la {0} es inválido.")]
        public string PatenteVieja { get; set; }

        public List<ClienteVehiculo> ClientesVehiculos { get; set; }

    }
}

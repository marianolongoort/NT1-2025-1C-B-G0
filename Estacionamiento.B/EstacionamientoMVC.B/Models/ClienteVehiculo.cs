
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstacionamientoMVC.B.Models
{
    public class ClienteVehiculo
    {
        //Prop Relacionales        
        public int ClienteId { get; set; }
        
        public int VehiculoId { get; set; }


        //Prop Navegacionales
        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }

        public int CantUso { get; set; }
    }
}

using System.Collections.Generic;

namespace EstacionamientoMVC.B.Models
{
    public class Cliente : Persona
    {

        public List<Telefono> Telefonos { get; set; }
        
        public List<ClienteVehiculo> ClienteVehiculos { get; set; }

       
    }
}

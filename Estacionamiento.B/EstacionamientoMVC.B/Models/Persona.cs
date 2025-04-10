namespace EstacionamientoMVC.B.Models
{
    public class Persona
    {
        private string apellido;

        public string Nombre { get; set; }


        public string Apellido {
            get { return this.apellido.ToUpper(); }
            set { apellido = value; }
        }

        public int Dni { get; set; }
        public bool Activo { get; set; }

        public DateTime FechaNacimiento { get; set; }
        public Direccion Direccion { get; set; }

        public List<Telefono> Telefonos { get; set; }

        public List<string> Palabras { get; set; }


    }
}

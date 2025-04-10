namespace EstacionamientoMVC.B.Models
{
    public class Telefono
    {
        private int codArea;
        public int Id{ get; set; }
        public int CodArea { get; set; }
        public int Numero { get; set; }
        public TiposTelefono Tipo { get; set; } = TiposTelefono.Trabajo;

    }
}

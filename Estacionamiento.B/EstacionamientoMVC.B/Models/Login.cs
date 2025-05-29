using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.B.Models
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool Recordarme { get; set; } = false;

    }
}

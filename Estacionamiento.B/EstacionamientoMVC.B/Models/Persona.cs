using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstacionamientoMVC.B.Models
{
    public class Persona
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Debe estar entre {2} y {1}")]
        public string Nombre { get; set; } 


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(60, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        [MinLength(2,ErrorMessage = "El campo {0} debe superar los {1} caracteres")]
        public string Apellido { get; set; }


        [Range(1, 99999999, ErrorMessage = "{0} Debe estar entre {1} y {2}")]
        [Display(Name = "Documento")]
        public int DNI { get; set; }


        [RegularExpression(@"^(20|23|24|27|30|33|34)-\d{7,8}-\d{1}$", ErrorMessage = "El formato del CUIT/CUIL es inválido.")]
        public string CodigoIdentificacion { get; set; } 

        public bool Activo { get; set; } = true;


        [Display(Name = "Correo electronico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public string NombreCompleto { 
            get {
                return $"{Apellido}, {Nombre}";
            }
        }

    }
}

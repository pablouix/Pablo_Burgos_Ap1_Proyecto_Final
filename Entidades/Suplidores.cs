using System.ComponentModel.DataAnnotations;

namespace Pablo_Burgos_Proyecto_Final.Entidades
{
    public class Suplidores
    {
        [Key]
        public int SuplidoresId { get; set; }   

        [Required(ErrorMessage ="Campo obligatorio.")]
        [MinLength(3, ErrorMessage ="Este campo debe tener al menos {1} caracteres.")]
        [MaxLength(40, ErrorMessage = "Este campo debe tener maximo {1} caracteres.")]
        public string Representante { get; set; }

        [Required(ErrorMessage ="Campo obligatorio.")]
        [MinLength(3, ErrorMessage ="Este campo debe tener al menos {1} caracteres.")]
        [MaxLength(40, ErrorMessage = "Este campo debe tener maximo {1} caracteres.")]
        public string Compania { get; set; }
        [Required]
        public DateTime FechaDeCreacion { get; set; } = DateTime.Now;

        [MinLength(3, ErrorMessage ="Este campo debe tener al menos {1} caracteres.")]
        [MaxLength(40, ErrorMessage = "Este campo debe tener maximo {1} caracteres.")]
        public string? Direccion { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Ingresa un numero de telefono valido.")]
        public string? Telefono { get; set; }
    }
}
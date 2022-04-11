using System.ComponentModel.DataAnnotations;

namespace Pablo_Burgos_Proyecto_Final.Entidades
{
    public class Suplidores
    {
        [Key]
        public int SuplidoresId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [MinLength(3, ErrorMessage = "Este campo debe tener al menos {1} caracteres.")]
        [MaxLength(60, ErrorMessage = "Este campo debe tener maximo {1} caracteres.")]
        [RegularExpression(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$", ErrorMessage = "Ingresa un nombre de representante valido.")]
        public string Representante { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        [MinLength(3, ErrorMessage = "Este campo debe tener al menos {1} caracteres.")]
        [MaxLength(60, ErrorMessage = "Este campo debe tener maximo {1} caracteres.")]
        [RegularExpression(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$", ErrorMessage = "Ingresa un nombre de compañia valido.")]
        public string Compania { get; set; }
        public DateTime FechaDeCreacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo obligatorio.")]
        [MinLength(3, ErrorMessage = "Este campo debe tener al menos {1} caracteres.")]
        [MaxLength(60, ErrorMessage = "Este campo debe tener maximo {1} caracteres.")]
        [RegularExpression(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$", ErrorMessage = "Ingresa una direccion valida.")]
        public string Direccion { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Ingresa un numero de telefono valido. ejemplo: 809-555-5555")] 
        public string? Telefono { get; set; }
    }
}
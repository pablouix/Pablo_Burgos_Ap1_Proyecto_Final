
using System.ComponentModel.DataAnnotations;

namespace Pablo_Burgos_Proyecto_Final.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; } 
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage ="Campo obligatorio.")]
        [MinLength(3, ErrorMessage ="Este campo debe tener al menos {1} caracteres.")]
        [MaxLength(60, ErrorMessage = "Este campo debe tener maximo {1} caracteres.")]
        [RegularExpression(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$", ErrorMessage = "Ingresa una descripcion valida.")]
        public string Descripcion { get; set; }
        
        [Required(ErrorMessage ="Campo obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage ="La cantidadad debe de estar entre {1} y {2}")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage ="Campo obligatorio.")]
        [Range(1, float.MaxValue, ErrorMessage ="El precio debe de estar entre {1} y {2}")]
        public float Costo { get; set; }
        public float Itbis {get; set; } = 18f;
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(1, 100, ErrorMessage = "La ganancia debe de estar entre 1 y 100")]
        public int Ganancia {get; set;}
        public float PrecioConItbis { get; set; }

        public float PrecioConIbisGanancia {get; set;}

        public float TotalInventario { get; set; }
        
        [Required(ErrorMessage ="Campo obligatorio.")]
        public int DispositivoId { get; set; }
        public string descripcionDispositivo {get; set; }
    }
}
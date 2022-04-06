
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
        [MaxLength(40, ErrorMessage = "Este campo debe tener maximo {1} caracteres.")]
        public string Descripcion { get; set; }
        
        [Required(ErrorMessage ="Campo obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage ="La cantidadad debe de estar entre {1} y {2}")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage ="Campo obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage ="El precio debe de estar entre {1} y {2}")]
        public float Precio { get; set; }
        public float Itbis {get; set; } = 18f;
        public float PrecioConItbis { get; set; }
        public float PrecioTotal { get; set; }

        
        [Required(ErrorMessage ="Campo obligatorio.")]
        public int DispositivoId { get; set; }

        public string descripcionDispositivo {get; set; }
    }
}
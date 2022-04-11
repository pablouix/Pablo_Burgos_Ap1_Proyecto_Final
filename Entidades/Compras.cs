using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pablo_Burgos_Proyecto_Final.Entidades
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }

        [Required(ErrorMessage ="Campo obligatorio.")]
        [MinLength(3, ErrorMessage ="Este campo debe tener al menos {1} caracteres.")]
        [MaxLength(60, ErrorMessage = "Este campo debe tener maximo {1} caracteres.")]
        [RegularExpression(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$", ErrorMessage = "Ingresa un concepto valido.")]
        public string Concepto { get; set; }  
          
        public DateTime FechaDeCompra { get; set; } = DateTime.Now;
        public int CantidadProductos { get; set; }
        
        [Required(ErrorMessage ="Campo obligatorio.")]
        public int SuplidoresId { get; set; }

        public float precioTotal {get; set; }
        
        public string DescripcionSuplidor {get; set;}
        
        [ForeignKey("CompraId")]
        public virtual List<ComprasDetalles> ComprasDetalles {get; set;} = new List<ComprasDetalles>();
    }
}
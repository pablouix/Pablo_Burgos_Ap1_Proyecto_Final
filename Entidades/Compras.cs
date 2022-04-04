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
        [MaxLength(40, ErrorMessage = "Este campo debe tener maximo {1} caracteres.")]
        public string Concepto { get; set; }    
        public DateTime FechaDeCompra { get; set; } = DateTime.Now;
        
        [Required(ErrorMessage ="Campo obligatorio.")]
        public int SuplidoresId { get; set; }
        
        [ForeignKey("CompraId")]
        public virtual List<ComprasDetalles> ComprasDetalles {get; set;} = new List<ComprasDetalles>();
    }
}
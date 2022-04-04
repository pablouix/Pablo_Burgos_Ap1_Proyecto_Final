using System.ComponentModel.DataAnnotations;

namespace Pablo_Burgos_Proyecto_Final.Entidades
{
    public class ComprasDetalles
    {
        [Key]
        public int ComprasDetallesId { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }

        public ComprasDetalles(int id, string descripcion, int cantidad)
        {
            ProductoId = id;
            Descripcion = descripcion;
            Cantidad = cantidad;
        }

        public ComprasDetalles()
        {}
    }
}
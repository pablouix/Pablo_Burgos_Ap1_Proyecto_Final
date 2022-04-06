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
        public float PrecioUnidad {get; set; }

        public ComprasDetalles(int id, string descripcion, int cantidad, float preciounidad)
        {
            ProductoId = id;
            Descripcion = descripcion;
            Cantidad = cantidad;
            PrecioUnidad = preciounidad;
        }

        public ComprasDetalles()
        {}
    }
}
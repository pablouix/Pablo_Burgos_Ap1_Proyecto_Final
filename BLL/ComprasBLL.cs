
using Pablo_Burgos_Proyecto_Final.DAL;
using Pablo_Burgos_Proyecto_Final.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Pablo_Burgos_Proyecto_Final.BLL
{
    public class ComprasBLL
    {
        private static Contexto _contexto;

        public ComprasBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        private static bool Existe(int id)
        {
            bool paso = false;
            try
            {
                paso = _contexto.Compras.Any(c => c.CompraId == id);
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool Guardar(Compras compras)
        {
            if(Existe(compras.CompraId))
                return Modificar(compras);
            else    
                return Insertar(compras);
        }

        private static bool Modificar(Compras compras)
        {
            bool paso = false;

            try
            {
                var compraAnterior = _contexto.Compras
                .Where(x => x.CompraId == compras
                .CompraId).Include(x => x.ComprasDetalles)
                .AsNoTracking()
                .SingleOrDefault();

                foreach(var item in compraAnterior.ComprasDetalles)
                {
                    Productos productos = ProductosBLL.Buscar(item.ProductoId);
                    productos.Cantidad -= item.Cantidad;

                    compras.CantidadProductos -= item.Cantidad;

                    compras.precioTotal -= item.Cantidad*productos.Precio;

                    float calculoItbis = productos.Precio * productos.Itbis/100;
                    productos.PrecioConItbis = productos.Precio + calculoItbis;
                    productos.PrecioTotal = productos.Cantidad * productos.PrecioConItbis;
                }

                List<ComprasDetalles> comprasDetalles = compras.ComprasDetalles;

                foreach(var item in comprasDetalles)
                {
                    Productos productos = ProductosBLL.Buscar(item.ProductoId);
                    productos.Cantidad += item.Cantidad;

                    compras.CantidadProductos += item.Cantidad;

                    compras.precioTotal += item.Cantidad*productos.Precio;

                    float calculoItbis = productos.Precio * productos.Itbis/100;
                    productos.PrecioConItbis = productos.Precio + calculoItbis;
                    productos.PrecioTotal = productos.Cantidad * productos.PrecioConItbis;
                }

                _contexto.Entry(compras).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;

            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        private static bool Insertar(Compras compras)
        {
            bool paso = false;

            try
            {
                _contexto.Compras.Add(compras);

                List<ComprasDetalles> comprasDetalles = compras.ComprasDetalles;
                foreach(var item in comprasDetalles)
                {
                    Productos productos = ProductosBLL.Buscar(item.ProductoId);
                    productos.Cantidad += item.Cantidad;
                    
                    compras.CantidadProductos += item.Cantidad;

                    compras.precioTotal += item.Cantidad*productos.Precio;

                    float calculoItbis = productos.Precio * productos.Itbis/100;
                    productos.PrecioConItbis = productos.Precio + calculoItbis;
                    productos.PrecioTotal = productos.Cantidad * productos.PrecioConItbis;
                }

                paso = _contexto.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }

            return paso;
        }

        public static Compras Buscar(int id)
        {
            Compras compras;
            try
            {
                compras = _contexto.Compras.Include(c => c.ComprasDetalles).Where(c => c.CompraId == id).SingleOrDefault();
            }
            catch(Exception)
            {
                throw;
            }
            return compras;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                var compras = _contexto.Compras.Find(id);

                if(compras != null)
                {
                    List<ComprasDetalles> comprasDetalles = compras.ComprasDetalles;

                    foreach(var item in comprasDetalles)
                    {
                        Productos productos = ProductosBLL.Buscar(item.ProductoId);
                        productos.Cantidad -= item.Cantidad;

                        float calculoItbis = productos.Precio * productos.Itbis/100;
                        productos.PrecioConItbis = productos.Precio + calculoItbis;
                        productos.PrecioTotal = productos.Cantidad * productos.PrecioConItbis;
                    }

                    _contexto.Compras.Remove(compras);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public static List<Compras> ListaComprasCriterio(Expression<Func<Compras, bool>> criterio)
        {
            List<Compras> lista = new List<Compras>();

            try
            {
                lista = _contexto.Compras.Where(criterio).AsNoTracking().ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return lista;
        }

        public static List<Compras> ListaComprasSimple()
        {
            List<Compras> lista = new List<Compras>();

            try
            {
                lista = _contexto.Compras.AsNoTracking().ToList();
            }
            catch(Exception)
            {
                throw;

            }
            return lista;
        }
    }
}
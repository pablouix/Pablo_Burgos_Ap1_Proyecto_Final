

using Pablo_Burgos_Proyecto_Final.DAL;
using Pablo_Burgos_Proyecto_Final.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Pablo_Burgos_Proyecto_Final.BLL
{
    public class ProductosBLL
    {
        private static Contexto _contexto;
        public ProductosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        private static bool Existe(int id)
        {
            bool paso = false;
            try
            {
                paso = _contexto.Productos.Any(p => p.ProductoId == id);
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Guardar(Productos productos)
        {
            if(Existe(productos.ProductoId))
                return Modificar(productos);
            else    
                return Insertar(productos);
        }

        private static bool Modificar(Productos productos)
        {
            bool paso = false;

            try
            {
                _contexto.Entry(productos).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;

            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        private static bool Insertar(Productos productos)
        {
            bool paso = false;

            try
            {
                _contexto.Productos.Add(productos);
                paso = _contexto.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }

            return paso;
        }

        public static Productos Buscar(int id)
        {
            Productos productos;
            try
            {
                productos = _contexto.Productos.Where(p => p.ProductoId == id).SingleOrDefault();
            }
            catch(Exception)
            {
                throw;
            }
            return productos;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                var productos = _contexto.Productos.Find(id);

                if(productos != null)
                {
                    _contexto.Productos.Remove(productos);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public static List<Productos> ListaProductosCriterio(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();

            try
            {
                lista = _contexto.Productos.Where(criterio).AsNoTracking().ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return lista;
        }

        public static List<Productos> ListaProductosSimple()
        {
            List<Productos> lista = new List<Productos>();

            try
            {
                lista = _contexto.Productos.ToList();

            }
            catch(Exception)
            {
                throw;

            }
            return lista;
        }
    }
}
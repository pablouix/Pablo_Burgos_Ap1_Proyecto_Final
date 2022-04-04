

using Pablo_Burgos_Proyecto_Final.DAL;
using Pablo_Burgos_Proyecto_Final.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Pablo_Burgos_Proyecto_Final.BLL
{
    public class SuplidoresBLL
    {
        private static Contexto _contexto;

        public SuplidoresBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        private static bool Existe(int id)
        {
            bool paso = false;
            try
            {
                paso = _contexto.Suplidores.Any(s => s.SuplidoresId == id);
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Guardar(Suplidores suplidores)
        {
            if(Existe(suplidores.SuplidoresId))
                return Modificar(suplidores);
            else    
                return Insertar(suplidores);
        }

        private static bool Modificar(Suplidores suplidores)
        {
            bool paso = false;

            try
            {
                _contexto.Entry(suplidores).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;

            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        private static bool Insertar(Suplidores suplidores)
        {
            bool paso = false;

            try
            {
                _contexto.Suplidores.Add(suplidores);
                paso = _contexto.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }

            return paso;
        }

        public static Suplidores Buscar(int id)
        {
            Suplidores suplidores;
            try
            {
                suplidores = _contexto.Suplidores.Where(s => s.SuplidoresId == id).SingleOrDefault();
            }
            catch(Exception)
            {
                throw;
            }
            return suplidores;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                var suplidores = _contexto.Suplidores.Find(id);

                if(suplidores != null)
                {
                    _contexto.Suplidores.Remove(suplidores);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public static List<Suplidores> ListaSuplidoresCriterio(Expression<Func<Suplidores, bool>> criterio)
        {
            List<Suplidores> lista = new List<Suplidores>();

            try
            {
                lista = _contexto.Suplidores.Where(criterio).AsNoTracking().ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return lista;
        }

        public static List<Suplidores> ListaSuplidoresSimple()
        {
            List<Suplidores> lista = new List<Suplidores>();

            try
            {
                lista = _contexto.Suplidores.ToList();

            }
            catch(Exception)
            {
                throw;

            }
            return lista;
        }
    }
}
using Pablo_Burgos_Proyecto_Final.DAL;
using Pablo_Burgos_Proyecto_Final.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Pablo_Burgos_Proyecto_Final.BLL
{
    public class DispositivosBLL
    {
        private static Contexto _contexto;

        public DispositivosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public static List<Dispositivos> ListaDispositivosCriterio(Expression<Func<Dispositivos, bool>> criterio)
        {
            List<Dispositivos> lista = new List<Dispositivos>();

            try
            {
                lista = _contexto.Dispositivos.Where(criterio).AsNoTracking().ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return lista;
        }

        public static List<Dispositivos> ListaDispositivosSimple()
        {
            List<Dispositivos> lista = new List<Dispositivos>();

            try
            {
                lista = _contexto.Dispositivos.AsNoTracking().ToList();

            }
            catch(Exception)
            {
                throw;

            }
            return lista;
        }

    }

}
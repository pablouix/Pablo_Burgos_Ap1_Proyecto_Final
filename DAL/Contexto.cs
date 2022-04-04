using Microsoft.EntityFrameworkCore;
using Pablo_Burgos_Proyecto_Final.Entidades;

namespace Pablo_Burgos_Proyecto_Final.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Compras> Compras {get; set;}
        public DbSet<Productos> Productos {get; set;}
        public DbSet<Suplidores> Suplidores {get; set;}
        public DbSet<Dispositivos> Dispositivos {get; set;}
        public Contexto(DbContextOptions<Contexto> options) : base(options) {  }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dispositivos>().HasData(
                new Dispositivos {DispositivoId = 1, Marca = "ZTE", Modelo = "546Z", SistemaOperativo = "Android"}
            );
            modelBuilder.Entity<Dispositivos>().HasData(
                new Dispositivos {DispositivoId = 2, Marca = "Iphone", Modelo = "X", SistemaOperativo = "IOS"}
            );
            modelBuilder.Entity<Dispositivos>().HasData(
                new Dispositivos {DispositivoId = 3, Marca = "Alcatel", Modelo = "Lite", SistemaOperativo = "Android"}
            );
        }

    }
}

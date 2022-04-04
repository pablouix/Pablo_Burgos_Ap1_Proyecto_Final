using System.ComponentModel.DataAnnotations;

namespace Pablo_Burgos_Proyecto_Final.Entidades
{
    public class Dispositivos
    {
        [Key]
        public int DispositivoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string SistemaOperativo { get; set; }
    }
}
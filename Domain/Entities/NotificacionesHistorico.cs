namespace Domain.Entities
{
    public class NotificacionesHistorico
    {
        public int Id { get; set; }
        public Guid UsuarioID { get; set; }
        public string Mensaje { get; set; }
        public string TiempoTranscurrido { get; set; }
        public bool Leido { get; set; }
        public DateTime FechaHora { get; set; }
    }
}

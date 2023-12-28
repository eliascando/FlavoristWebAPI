namespace Domain.Entities
{
    public class Notificacion
    {
        public Guid Id { get; set; }
        public Guid EventoID { get; set; }
        public DateTime FechaHora { get; set; }
    }
}

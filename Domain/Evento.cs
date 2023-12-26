namespace Domain
{
    public class Evento
    {
        public Guid Id { get; set; }
        public int EventoTipoID { get; set; }
        public DateTime FechaHora { get; set; }
    }
}

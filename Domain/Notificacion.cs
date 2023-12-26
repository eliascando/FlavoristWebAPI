namespace Domain
{
    public class Notificacion
    {
        public Guid Id { get; set; }
        public Guid UsuarioID { get; set; }
        public Guid EventoId { get; set; }
        public Boolean Visto { get; set; }
        public DateTime Fecha { get; set; }
    }
}

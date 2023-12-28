namespace Domain.Entities
{
    public class Like
    {
        public Guid Id { get; set; }
        public Guid ReferenciaID { get; set; }
        public int EventoTipoID { get; set; }
        public Guid EventoID { get; set; }
    }
}

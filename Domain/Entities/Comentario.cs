using Domain.Entities.Catalog;

namespace Domain.Entities
{
    public class Comentario
    {
        public Guid Id { get; set; }
        public Guid ? ComentarioPadreID { get; set; }
        public Guid ReferenciaID { get; set; }
        public string Texto { get; set; }
        public int EventoTipoID { get; set; }
        public EventoTipo EventoTipo { get; set; }
        public Guid EventoID { get; set; }
        public Evento Evento { get; set; }
    }
}

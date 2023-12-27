using Domain.Entities.Catalog;

namespace Domain.Entities
{
    public class Notificacion
    {
        public Guid Id { get; set; }
        public int EventoTipoID { get; set; }
        public Guid ReferenciaID { get; set; }
        public DateTime FechaHora { get; set; }
    }
}

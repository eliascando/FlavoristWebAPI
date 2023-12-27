using Domain.Entities.Catalog;

namespace Domain.Entities
{
    public class Evento
    {
        public Guid Id { get; set; }
        public int EventoTipoID { get; set; }
        public Guid UsuarioID { get; set; }
        public DateTime FechaHora { get; set; }
    }
}

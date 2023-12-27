using Domain.Entities.Catalog;

namespace Domain.Entities
{
    public class Follow
    {
        public Guid Id { get; set; }
        public Guid SeguidorID { get; set; }
        public Guid SeguidoID { get; set; }
        public int EventoTipoID { get; set; }
        public Guid EventoID { get; set; }
    }
}

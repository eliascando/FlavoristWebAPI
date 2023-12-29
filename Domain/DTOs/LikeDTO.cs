namespace Domain.DTOs
{
    public class LikeDTO
    {
        public Guid ? Id { get; set; }
        public Guid ReferenciaID { get; set; }
        public Guid UsuarioID { get; set; }
        public int EntidadTipoID { get; set; }
    }
}

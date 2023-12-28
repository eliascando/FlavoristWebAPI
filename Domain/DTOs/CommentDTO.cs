namespace Domain.DTOs
{
    public class CommentDTO
    {
        public Guid ? ComentarioPadreID { get; set; }
        public Guid UsuarioID { get; set; }
        public Guid ReferenciaID { get; set; }
        public string Texto { get; set; }
    }
}

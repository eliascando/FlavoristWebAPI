using Domain.Entities;

namespace Domain.DTOs
{
    public class CommentThreadsDTO
    {
        public Guid ReferenciaID { get; set; }
        public Comentario ComentarioPadre { get; set; }
        public List<CommentThreadsDTO> ? ComentariosHijos { get; set; }
    }
}

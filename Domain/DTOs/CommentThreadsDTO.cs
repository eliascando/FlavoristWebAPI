using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CommentThreadsDTO
    {
        public Guid ReferenciaID { get; set; }
        public Comentario ComentarioPadre { get; set; }
        public List<CommentThreadsDTO> ? ComentariosHijos { get; set; }
    }
}

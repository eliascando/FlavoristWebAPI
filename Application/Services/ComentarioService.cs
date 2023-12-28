using Domain.Interfaces.Repository;
using Domain.Entities;
using Application.Interfaces;
using Domain.DTOs;

namespace Application.Services
{
    public class ComentarioService
        : IServiceComentario<Comentario,CommentDTO, Guid>
    {
        private IRepositoryComentario<Comentario, Guid> _repository;
        private IRepositoryBase<Notificacion, Guid> _notificacion;
        private IRepositoryBase<Evento, Guid> _evento;

        public ComentarioService(
            IRepositoryComentario<Comentario, Guid> repository,
            IRepositoryBase<Notificacion, Guid> notificacion, 
            IRepositoryBase<Evento, Guid> evento
        )
        {
            _repository = repository;
            _notificacion = notificacion;
            _evento = evento;
        }

        public Comentario AgregarComentario(CommentDTO comentario)
        {
            try
            {
                //Nuevo Comentario, EventoTipoID = 2
                var newComment = new Comentario()
                {
                    Id = Guid.NewGuid(),
                    ComentarioPadreID = comentario.ComentarioPadreID,
                    ReferenciaID = comentario.ReferenciaID,
                    Texto = comentario.Texto,
                    EventoTipoID = 2
                };

                var evento = new Evento()
                {
                    Id = Guid.NewGuid(),
                    EventoTipoID = 2,
                    UsuarioID = comentario.UsuarioID,
                    FechaHora = DateTime.Now
                };

                newComment.EventoID = evento.Id;

                var notificacion = new Notificacion()
                {
                    Id = Guid.NewGuid(),
                    EventoTipoID = 2,
                    ReferenciaID = newComment.Id,
                    FechaHora = DateTime.Now
                };


                var guardado = _repository.Agregar(newComment);
                _evento.Agregar(evento);
                _notificacion.Agregar(notificacion);

                _repository.Guardar();
                _evento.Guardar();
                _notificacion.Guardar();

                return guardado;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void EliminarComentario(Guid id)
        {
            _repository.EliminarComentario(id);
            _repository.Guardar();
        }

        public List<Comentario> ObtenerComentariosPadres(Guid idPost)
        {
            return _repository.ObtenerComentariosPadres(idPost);
        }

        public List<Comentario> ObtenerComentariosHijos(Guid idComentarioPadre)
        {
            return _repository.ObtenerComentariosHijos(idComentarioPadre);
        }

        public CommentThreadsDTO ObtenerComentariosHilosPost(Guid idPost)
        {
            // Obtener comentarios padres del post.
            var comentariosPadres = _repository.ObtenerComentariosPadres(idPost);

            // Convertir cada comentario padre en un DTO que incluya sus comentarios hijos.
            var comentariosHilos = comentariosPadres.Select(comentarioPadre => new CommentThreadsDTO
            {
                ReferenciaID = comentarioPadre.ReferenciaID,
                ComentarioPadre = comentarioPadre,
                // Llama a una función que debe ser implementada en el repositorio para obtener los comentarios hijos.
                ComentariosHijos = ObtenerComentariosHijosDTO(comentarioPadre.Id)
            }).ToList();

            // Devuelve el resultado con la referencia al post y los hilos de comentarios.
            return new CommentThreadsDTO
            {
                ReferenciaID = idPost,
                ComentariosHijos = comentariosHilos
            };
        }

        private List<CommentThreadsDTO> ObtenerComentariosHijosDTO(Guid idComentarioPadre)
        {
            // Obtener los comentarios hijos directamente del repositorio.
            var comentariosHijos = _repository.ObtenerComentariosHijos(idComentarioPadre);

            // Para cada comentario hijo, obtener sus propios comentarios hijos recursivamente.
            return comentariosHijos.Select(comentarioHijo => new CommentThreadsDTO
            {
                ReferenciaID = comentarioHijo.ReferenciaID,
                ComentarioPadre = comentarioHijo,
                ComentariosHijos = ObtenerComentariosHijosDTO(comentarioHijo.Id) // Llamada recursiva
            }).ToList();
        }
    }
}

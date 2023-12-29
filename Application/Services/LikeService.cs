using Domain.Entities;
using Domain.Interfaces.Repository;
using Application.Interfaces;
using Domain.DTOs;
using Domain.Interfaces;

namespace Application.Services
{
    public class LikeService
        : IServiceLike<Like, LikeDTO, UserDTO, Guid, Guid>
    {
        private readonly IRepositoryLike<Like, LikeDTO, UserDTO ,Guid, Guid> _repository;
        private readonly IRepositoryBase<Notificacion, Guid> _notificacion;
        private readonly IRepositoryBase<Evento, Guid> _evento;

        public LikeService(
            IRepositoryLike<Like, LikeDTO, UserDTO, Guid, Guid> repository,
            IRepositoryBase<Notificacion, Guid> notificacion,
            IRepositoryBase<Evento, Guid> evento
        )
        {
            _repository = repository;
            _notificacion = notificacion;
            _evento = evento;
        }

        public Like DarLike(Like entidad)
        {
            throw new NotImplementedException();
        }

        public bool EliminarLikePorUsuarioYPost(Guid usuario, Guid post)
        {
            return _repository.EliminarLikePorUsuarioYPost(usuario, post);
        }

        public int ObtenerCantidadLikeDePost(Guid id)
        {
           return _repository.ObtenerCantidadLikeDePost(id);
        }

        public Like DarLikeDesdeDTO(LikeDTO entidad)
        {
            int EventoTipoID = 1; //Nuevo Like

            var like = new Like()
            {
                Id = Guid.NewGuid(),
                ReferenciaID = entidad.ReferenciaID,
                EventoTipoID = EventoTipoID
            };

            var evento = new Evento()
            {
                Id = Guid.NewGuid(),
                ReferenciaID = like.Id,
                EventoTipoID = EventoTipoID,
                EntidadTipoID = entidad.EntidadTipoID,
                UsuarioID = entidad.UsuarioID,
                FechaHora = DateTime.Now
            };

            like.EventoID = evento.Id;

            var notificacion = new Notificacion()
            {
                Id = Guid.NewGuid(),
                EventoID = evento.Id,
                FechaHora = DateTime.Now
            };

            _repository.DarLike(like);
            _evento.Agregar(evento);
            _notificacion.Agregar(notificacion);

            _evento.Guardar();
            _notificacion.Guardar();

            entidad.Id = like.Id;

            return like;
        }

        public List<UserDTO> ObtenerLikesOwners(Guid id)
        {
            return _repository.ObtenerLikesOwners(id);

        }
    }
}

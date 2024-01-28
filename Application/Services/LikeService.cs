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
        private readonly IRepositoryBase<Notificacion, int, Guid> _notificacion;
        private readonly IRepositoryBase<Evento, int, Guid> _evento;

        public LikeService(
            IRepositoryLike<Like, LikeDTO, UserDTO, Guid, Guid> repository,
            IRepositoryBase<Notificacion, int, Guid> notificacion,
            IRepositoryBase<Evento, int, Guid> evento
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

            //primero validar que no exista un like de ese usuario en ese post
            bool valido = _repository.ExisteLikeDeUsuarioEnPost(entidad.UsuarioID, entidad.ReferenciaID);

            if (valido)
            {
                throw new Exception("Ya existe un like de este usuario en este post");
            }

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

        public bool ExisteLikeDeUsuarioEnPost(Guid usuario, Guid referenciaId)
        {
            return _repository.ExisteLikeDeUsuarioEnPost(usuario, referenciaId);
        }
    }
}

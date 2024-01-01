using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Application.Services
{
    public class FollowService
        : IServiceBase<Follow, int, Guid>, 
        IServiceFollow<UserDTO, Guid, Guid, Guid>
    {
        private readonly IRepositoryBase<Follow, int, Guid> _repository;
        private readonly IRepositoryBase<Notificacion, int, Guid> _notificacion;
        private readonly IRepositoryBase<Evento, int, Guid> _evento;
        private readonly IRepositoryFollow<UserDTO, Guid, Guid, Guid> _repositoryFollow;

        public FollowService(
            IRepositoryBase<Follow, int, Guid> repository,
            IRepositoryBase<Notificacion, int, Guid> repoNotificacion,
            IRepositoryBase<Evento, int, Guid> repoEvento,
            IRepositoryFollow<UserDTO, Guid, Guid, Guid> repositoryFollow
        )
        {
            _repository = repository;
            _notificacion = repoNotificacion;
            _evento = repoEvento;
            _repositoryFollow = repositoryFollow;
        }

        public Follow Agregar(Follow entidad)
        {
            int EventoTipoID = 4; //Nuevo Seguidor
            int EntidadTipoID = 1; //Usuario

            entidad.Id = Guid.NewGuid();

            var evento = new Evento()
            {
                Id = Guid.NewGuid(),
                EventoTipoID = EventoTipoID,
                EntidadTipoID = EntidadTipoID,
                UsuarioID = entidad.SeguidorID,
                ReferenciaID = entidad.Id,
                FechaHora = DateTime.Now
            };

            var notificacion = new Notificacion()
            {
                Id = Guid.NewGuid(),
                EventoID = evento.Id,
                FechaHora = DateTime.Now
            };

            entidad.EventoTipoID = EventoTipoID;
            entidad.EventoID = evento.Id;

            var guardado = _repository.Agregar(entidad);
            _evento.Agregar(evento);
            _notificacion.Agregar(notificacion);

            _evento.Guardar();
            _notificacion.Guardar();
            _repository.Guardar();
            return guardado;
        }

        public Follow Editar(Follow entidad)
        {
            throw new Exception("No se puede editar un follow");
        }

        public void Eliminar(Guid Id)
        {
            var follow = _repository.ObtenerPorId(Id) ?? throw new Exception("Follow no encontrado");
            _repository.Eliminar(follow);
            _repository.Guardar();
        }

        public void Eliminar(Follow entidad)
        {
            throw new NotImplementedException();
        }

        public List<Follow> Listar()
        {
            throw new NotImplementedException();
        }

        public Follow ObtenerPorId(Guid id)
        {
            var resultado = _repository.ObtenerPorId(id);

            return resultado;
        }

        public bool EliminarPorSeguidorYSeguido(Guid seguidor, Guid seguido)
        {
           return _repositoryFollow.EliminarPorSeguidorYSeguido(seguidor, seguido);
        }

        public List<UserDTO> ObtenerSeguidores(Guid id)
        {
            var resultado = _repositoryFollow.ObtenerSeguidores(id);

            return resultado;
        }

        public List<UserDTO> ObtenerSeguidos(Guid id)
        {
            var resultado = _repositoryFollow.ObtenerSeguidos(id);

            return resultado;
        }

        public Follow ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

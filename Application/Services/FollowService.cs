using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repository;

namespace Application.Services
{
    public class FollowService
        : IServiceBase<Follow, Guid>, IServiceFollow<FollowsDTO, Guid>
    {
        private IRepositoryBase<Follow, Guid> _repository;
        private IRepositoryFollow<FollowsDTO, Guid> _repositoryFollow;
        private IRepositoryBase<Evento, Guid> _evento;
        private IRepositoryBase<Notificacion, Guid> _notificacion;

        public FollowService(
            IRepositoryBase<Follow, Guid> repository,
            IRepositoryFollow<FollowsDTO, Guid> repositoryFollow,
            IRepositoryBase<Evento, Guid> repoEvento,
            IRepositoryBase<Notificacion, Guid> repoNotificacion
        )
        {
            _repository = repository;
            _repositoryFollow = repositoryFollow;
            _evento = repoEvento;
            _notificacion = repoNotificacion;
        }

        public Follow Agregar(Follow entidad)
        {
            //Nuevo Seguidor, EventoTipoID = 4
            entidad.Id = Guid.NewGuid();

            var evento = new Evento()
            {
                Id = Guid.NewGuid(),
                EventoTipoID = 4,
                UsuarioID = entidad.SeguidorID,
                FechaHora = System.DateTime.Now
            };

            var notificacion = new Notificacion()
            {
                Id = Guid.NewGuid(),
                EventoTipoID = 4,
                ReferenciaID = entidad.Id,
                FechaHora = System.DateTime.Now
            };

            entidad.EventoTipoID = 4; //Seguidor
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
            throw new NotImplementedException();
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

        public List<FollowsDTO> ObtenerSeguidores(Guid id)
        {
            var resultado = _repositoryFollow.ObtenerSeguidores(id);

            return resultado;
        }

        public List<FollowsDTO> ObtenerSeguidos(Guid id)
        {
            var resultado = _repositoryFollow.ObtenerSeguidos(id);

            return resultado;
        }
    }
}

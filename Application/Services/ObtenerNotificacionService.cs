using Application.Interfaces;
using Domain.DTOs;
using Domain.Interfaces.Repository;

namespace Application.Services
{
    public class ObtenerNotificacionService
        : IServiceObtenerNotificacion<NotificacionDTO, Guid>
    {
        private readonly IRepositoryObtenerNotificacion<NotificacionDTO, Guid> _repository;

        public ObtenerNotificacionService(IRepositoryObtenerNotificacion<NotificacionDTO, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<List<NotificacionDTO>> ObtenerNotificaciones(Guid id)
        {
            return await _repository.ObtenerNotificaciones(id);
        }
    }
}

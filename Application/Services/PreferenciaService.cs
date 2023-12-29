using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Application.Services
{
    public class PreferenciaCategoriaService
        : IServicePreferencia<UsuarioRecetaCategoriaFav, Guid>
    {
        IRepositoryPreferencia<UsuarioRecetaCategoriaFav, Guid> _repository;

        public PreferenciaCategoriaService(
            IRepositoryPreferencia<UsuarioRecetaCategoriaFav, Guid> repository
        )
        {
            _repository = repository;
        }

        public UsuarioRecetaCategoriaFav Agregar(UsuarioRecetaCategoriaFav entidad)
        {
            entidad.Id = Guid.NewGuid();
            return _repository.Agregar(entidad);
        }

        public void Eliminar(UsuarioRecetaCategoriaFav entidad)
        {
            _repository.Eliminar(entidad);
        }

        public List<UsuarioRecetaCategoriaFav> ObtenerPreferenciasPorUsuario(Guid uid)
        {
            return _repository.ObtenerPreferenciasPorUsuario(uid);
        }
    }

    public class PreferenciaRecetaService
        : IServicePreferencia<UsuarioRecetaFav, Guid>
    {
        IRepositoryPreferencia<UsuarioRecetaFav, Guid> _repository;

        public PreferenciaRecetaService(
            IRepositoryPreferencia<UsuarioRecetaFav, Guid> repository
        )
        {
            _repository = repository;
        }

        public UsuarioRecetaFav Agregar(UsuarioRecetaFav entidad)
        {
            entidad.Id = Guid.NewGuid();
            return _repository.Agregar(entidad);
        }

        public void Eliminar(UsuarioRecetaFav entidad)
        {
            _repository.Eliminar(entidad);
        }

        public List<UsuarioRecetaFav> ObtenerPreferenciasPorUsuario(Guid uid)
        {
            return _repository.ObtenerPreferenciasPorUsuario(uid);
        }
    }
}

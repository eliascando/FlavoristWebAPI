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
            var existe = _repository.ExistePreferencia(entidad.UsuarioID, entidad.RecetaCategoriaID);

            if (existe)
            {
                throw new System.Exception("Ya existe una preferencia de este usuario para esta categoria");
            }
            else
            {
                _repository.Agregar(entidad);
            }

            return entidad;
        }

        public void Eliminar(UsuarioRecetaCategoriaFav entidad)
        {
            _repository.Eliminar(entidad);
        }

        public void EliminarPorUsuarioYRecetaCategoria(Guid idUsuario, Guid idRecetaCategoria)
        {
            var entidad = new UsuarioRecetaCategoriaFav()
            {
                UsuarioID = idUsuario,
                RecetaCategoriaID = idRecetaCategoria
            };

            _repository.Eliminar(entidad);
        }

        public bool ExistePreferencia(Guid uid, Guid id)
        {
            throw new NotImplementedException();
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
            
            var existe = _repository.ExistePreferencia(entidad.UsuarioID, entidad.RecetaID);

            if (existe)
            {
                throw new Exception("Ya existe una preferencia de este usuario para esta receta");
            }
            else
            {
                _repository.Agregar(entidad);
            }
            return entidad;
        }

        public void Eliminar(UsuarioRecetaFav entidad)
        {
            _repository.Eliminar(entidad);
        }

        public void EliminarPorUsuarioYReceta(Guid idUsuario, Guid idReceta)
        {
            var entidad = new UsuarioRecetaFav()
            {
                UsuarioID = idUsuario,
                RecetaID = idReceta
            };

            _repository.Eliminar(entidad);
        }

        public bool ExistePreferencia(Guid uid, Guid id)
        {
            return _repository.ExistePreferencia(uid, id);
        }

        public List<UsuarioRecetaFav> ObtenerPreferenciasPorUsuario(Guid uid)
        {
            return _repository.ObtenerPreferenciasPorUsuario(uid);
        }
    }
}

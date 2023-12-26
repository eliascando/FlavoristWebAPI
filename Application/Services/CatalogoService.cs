using Application.Interfaces;
using Domain;
using Domain.Interfaces.Repository;

namespace Application.Services
{
    public class CatalogoServicePais
        : IServiceBase<Pais, Guid>
    {
        private readonly IRepositoryBase<Pais, Guid> _reposPais;

        public CatalogoServicePais(IRepositoryBase<Pais, Guid> reposPais)
        {
            _reposPais = reposPais;
        }

        public Pais Agregar(Pais entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("Pais", "No se puede agregar un pais nulo");

            entidad.Id = Guid.NewGuid();
            var usuario = _reposPais.Agregar(entidad);
            _reposPais.Guardar();
            return usuario;
        }

        public Pais Editar(Pais entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Pais entidad)
        {
            throw new NotImplementedException();
        }

        public List<Pais> Listar()
        {
            return _reposPais.Listar();
        }

        public Pais ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogoServiceUsuarioTipo
        :IServiceBase<UsuarioTipo, Guid>
    {
           private readonly IRepositoryBase<UsuarioTipo, Guid> _reposUsuarioTipo;

        public CatalogoServiceUsuarioTipo(IRepositoryBase<UsuarioTipo, Guid> reposUsuarioTipo)
        {
            _reposUsuarioTipo = reposUsuarioTipo;
        }

        public UsuarioTipo Agregar(UsuarioTipo entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("UsuarioTipo", "No se puede agregar un usuario tipo nulo");

            entidad.Id = Guid.NewGuid();
            var usuarioTipo = _reposUsuarioTipo.Agregar(entidad);
            _reposUsuarioTipo.Guardar();
            return usuarioTipo;
        }

        public UsuarioTipo Editar(UsuarioTipo entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(UsuarioTipo entidad)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioTipo> Listar()
        {
            return _reposUsuarioTipo.Listar();
        }

        public UsuarioTipo ObtenerPorId(Guid id)
        {
            var resultado = _reposUsuarioTipo.ObtenerPorId(id) ?? throw new Exception("UsuarioTipo no encontrado");
            return resultado;
        }
    }
}

using Application.Interfaces;
using Domain;
using Domain.Interfaces.Repository;

namespace Application.Services
{
    public class UsuarioService : IServiceBase<Usuario, Guid>
    {
        private readonly IRepositoryBase<Usuario, Guid> _reposUsuario;

        public UsuarioService(IRepositoryBase<Usuario, Guid> reposUsuario)
        {
            _reposUsuario = reposUsuario;
        }

        public Usuario Agregar(Usuario entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("Usuario", "No se puede agregar un usuario nulo");

            entidad.Id = Guid.NewGuid();
            entidad.Password = BCrypt.Net.BCrypt.HashPassword(entidad.Password);

            var usuario = _reposUsuario.Agregar(entidad);
            _reposUsuario.Guardar();
            return usuario;
        }

        public Usuario Editar(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar()
        {
            return _reposUsuario.Listar();
        }

        public Usuario ObtenerPorId(Guid id)
        {
            var resultado = _reposUsuario.ObtenerPorId(id);
            return resultado;
        }
    }
}

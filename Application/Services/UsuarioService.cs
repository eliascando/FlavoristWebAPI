using Application.Interfaces;
using Domain;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public Usuario ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

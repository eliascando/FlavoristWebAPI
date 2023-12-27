﻿using Application.Interfaces;
using Domain.Entities;
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
            entidad.FechaNotificaciones = System.DateTime.Now;

            var usuario = _reposUsuario.Agregar(entidad);
            _reposUsuario.Guardar();
            return usuario;
        }

        public Usuario Editar(Usuario entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("Usuario", "No se puede editar un usuario nulo");

            var usuario = _reposUsuario.ObtenerPorId(entidad.Id);

            usuario.Password = BCrypt.Net.BCrypt.HashPassword(entidad.Password);
            usuario.Correo = entidad.Correo;

            var actualizado = _reposUsuario.Editar(usuario);
            _reposUsuario.Guardar();
            return actualizado;
        }

        public void Eliminar(Usuario entidad)
        {
           if (entidad == null)
                throw new ArgumentNullException("Usuario", "No se puede eliminar un usuario nulo");

            _reposUsuario.Eliminar(entidad);
            _reposUsuario.Guardar();
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

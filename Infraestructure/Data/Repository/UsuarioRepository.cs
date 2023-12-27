﻿using Domain.Entities;
using Domain.Interfaces.Repository;
using Infraestructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repository
{
    public class UsuarioRepository : IRepositoryBase<Usuario, Guid>
    {
        private DBContext db;

        public UsuarioRepository(DBContext _db)
        {
            db = _db;
        }

        public Usuario Agregar(Usuario entidad)
        {
            db.Usuarios.Add(entidad);
            return entidad;
        }
        public List<Usuario> Listar()
        {
            return db.Usuarios.ToList();
        }

        public Usuario ObtenerPorId(Guid id)
        {
            var usuario = db.Usuarios.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Usuario no encontrado");
            return usuario;
        }

        public List<Usuario> ObtenerUsuariosPorListaDeID(List<Guid> id)
        {
            var lista = db.Usuarios.Where(x => id.Contains(x.Id)).ToList();
            
            return lista;
        }

        public Usuario Editar(Usuario entidad)
        {
            var usuario = db.Usuarios.Where(x => x.Id == entidad.Id).FirstOrDefault() ?? throw new Exception("Usuario no encontrado");

            usuario.Password = entidad.Password;
            usuario.Correo = entidad.Correo;

            db.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return usuario;
        }

        public void Eliminar(Usuario entidad)
        {
            var usuario = db.Usuarios.Where(x => x.Id == entidad.Id).FirstOrDefault() ?? throw new Exception("Usuario no encontrado");

            usuario.Estado = false;

            db.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Guardar()
        {
            db.SaveChanges();
        }
    }
}

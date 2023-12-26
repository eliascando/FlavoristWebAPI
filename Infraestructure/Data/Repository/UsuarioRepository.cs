using Domain;
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
            entidad.Id = Guid.NewGuid();
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

        public Usuario Editar(Usuario entidad)
        {
            var usuario = db.Usuarios.Where(x => x.Id == entidad.Id).FirstOrDefault() ?? throw new Exception("Usuario no encontrado");

            usuario.Nombres = entidad.Nombres;
            usuario.Apellidos = entidad.Apellidos;
            usuario.Correo = entidad.Correo;
            usuario.Password = entidad.Password;
            usuario.FechaNacimiento = entidad.FechaNacimiento;

            db.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return usuario;
        }

        public void Eliminar(Usuario entidad)
        {
            var usuario = db.Usuarios.Where(x => x.Id == entidad.Id).FirstOrDefault() ?? throw new Exception("Usuario no encontrado");

            db.Usuarios.Remove(usuario);
        }

        public void Begin()
        {
            db.Database.BeginTransaction();
        }
        public void Commit()
        {
            db.Database.CommitTransaction();
        }
        public void Rollback()
        {
            db.Database.RollbackTransaction();
        }
        public void Guardar()
        {
            db.SaveChanges();
        }
    }
}

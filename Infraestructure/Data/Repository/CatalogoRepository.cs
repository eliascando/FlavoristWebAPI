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
    public class CatalogoRepositoryPais
        :IRepositoryBase<Pais,Guid >
    {
        private DBContext db;

        public CatalogoRepositoryPais(DBContext _db)
        {
            db = _db;
        }

        public Pais Agregar(Pais entidad)
        {
            entidad.Id = Guid.NewGuid();
            db.Paises.Add(entidad);
            return entidad;
        }

        public Pais Editar(Pais entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Pais entidad)
        {
            db.Paises.Remove(entidad);
        }
        public List<Pais> Listar()
        {
            return db.Paises.ToList();
        }

        public Pais ObtenerPorId(Guid id)
        {
            var pais = db.Paises.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Usuario no encontrado");
            return pais;
        }

        public void Begin()
        {
            db.Database.BeginTransaction();
        }
        public void Commit()
        {
            db.Database.CommitTransaction();
        }
        public void Guardar()
        {
            db.SaveChanges();
        }
        public void Rollback()
        {
            db.Database.RollbackTransaction();
        }
    }

    public class CatalogoRepositoryUsuarioTipo
        : IRepositoryBase<UsuarioTipo, Guid>
    {
        private DBContext db;

        public CatalogoRepositoryUsuarioTipo(DBContext _db)
        {
            db = _db;
        }

        public UsuarioTipo Agregar(UsuarioTipo entidad)
        {
            entidad.Id = Guid.NewGuid();
            db.UsuarioTipos.Add(entidad);
            return entidad;
        }

        public UsuarioTipo Editar(UsuarioTipo entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(UsuarioTipo entidad)
        {
            db.UsuarioTipos.Remove(entidad);
        }
        public List<UsuarioTipo> Listar()
        {
            return db.UsuarioTipos.ToList();
        }

        public UsuarioTipo ObtenerPorId(Guid id)
        {
            var usuarioTipo = db.UsuarioTipos.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Usuario no encontrado");
            return usuarioTipo;
        }

        public void Begin()
        {
            db.Database.BeginTransaction();
        }
        public void Commit()
        {
            db.Database.CommitTransaction();
        }
        public void Guardar()
        {
            db.SaveChanges();
        }
        public void Rollback()
        {
            db.Database.RollbackTransaction();
        }
    }   
}

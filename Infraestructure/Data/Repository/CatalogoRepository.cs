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
    public class CatalogoRepository 
        :IRepositoryBase<Pais,Guid >
    {
        private DBContext db;

        public CatalogoRepository(DBContext _db)
        {
            db = _db;
        }

        #region PaisCatalogo
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
            throw new NotImplementedException();
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
        #endregion
    }
}

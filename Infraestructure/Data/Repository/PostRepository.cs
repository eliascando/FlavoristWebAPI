using Domain;
using Domain.Interfaces.Repository;
using Infraestructure.Data.Context;

namespace Infraestructure.Data.Repository
{
    public class PostRepository
        : IRepositoryPost<Receta, Guid>
    {
        private DBContext db;

        public PostRepository(DBContext _db)
        {
            db = _db;
        }

        public Receta Agregar(Receta entidad)
        {
            db.Recetas.Add(entidad);
            return entidad;
        }

        public List<Receta> Listar()
        {
            throw new NotImplementedException();
        }

        public Receta Editar(Receta entidad)
        {
            throw new NotImplementedException();
        }

        public Receta ObtenerPorId(Guid id)
        {
            throw new NotImplementedException();
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

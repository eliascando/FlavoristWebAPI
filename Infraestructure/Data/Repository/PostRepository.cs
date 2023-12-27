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
        public Receta ObtenerPorId(Guid id)
        {
            var receta = db.Recetas.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Receta no encontrada");
            return receta;
        }

        public List<Receta> ListarPorUsuario(Guid id)
        {
            var receta = db.Recetas.Where(x => x.UsuarioID == id).ToList();
            return receta;
        }

        public List<Receta> ListarPorCategoria(Guid id)
        {
            var receta = db.Recetas.Where(x => x.CategoriaID == id).ToList();
            return receta;
        }

        public List<Receta> ListarPorIngrediente(Guid id)
        {
            var receta = db.Recetas.Where(x => x.RecetaIngredientes.Any(y => y.Id == id)).ToList();
            return receta;
        }

        public Receta Editar(Receta entidad)
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

    public class RecetaIngredienteRepository
        : IRepositoryBase<RecetaIngrediente, Guid>
    {
        private DBContext db;

        public RecetaIngredienteRepository(DBContext _db)
        {
            db = _db;
        }

        public RecetaIngrediente Agregar(RecetaIngrediente entidad)
        {
            db.RecetaIngredientes.Add(entidad);
            return entidad;
        }

        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public RecetaIngrediente Editar(RecetaIngrediente entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(RecetaIngrediente entidad)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<RecetaIngrediente> Listar()
        {
            return db.RecetaIngredientes.ToList();
        }

        public RecetaIngrediente ObtenerPorId(Guid id)
        {
            var recetaIngrediente = db.RecetaIngredientes.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("RecetaIngrediente no encontrado");
            return recetaIngrediente;
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }

    public class RecetaPasoRepository
        : IRepositoryBase<RecetaPaso, Guid>
    {
        private DBContext db;

        public RecetaPasoRepository(DBContext _db)
        {
            db = _db;
        }

        public RecetaPaso Agregar(RecetaPaso entidad)
        {
            db.RecetaPasos.Add(entidad);
            return entidad;
        }

        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public RecetaPaso Editar(RecetaPaso entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(RecetaPaso entidad)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<RecetaPaso> Listar()
        {
            return db.RecetaPasos.ToList();
        }

        public RecetaPaso ObtenerPorId(Guid id)
        {
            var recetaPaso = db.RecetaPasos.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("RecetaPaso no encontrado");
            return recetaPaso;
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}

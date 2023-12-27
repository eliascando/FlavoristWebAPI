using Domain.Entities;
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

        public void Guardar()
        {
            db.SaveChanges();
        }
    }
}

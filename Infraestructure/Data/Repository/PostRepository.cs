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

            receta.RecetaPasos = db.RecetaPasos.Where(x => x.RecetaID == id).ToList();
            receta.RecetaIngredientes = db.RecetaIngredientes.Where(x => x.RecetaID == id).ToList();

            return receta;
        }

        public List<Receta> ListarPorUsuario(Guid id)
        {
            var recetas = db.Recetas.Where(x => x.UsuarioID == id).ToList();

            recetas.ForEach(receta =>
            {
                receta.RecetaPasos = db.RecetaPasos.Where(y => y.RecetaID == receta.Id).ToList();
                receta.RecetaIngredientes = db.RecetaIngredientes.Where(y => y.RecetaID == receta.Id).ToList();
            });

            return recetas;
        }

        public List<Receta> ListarPorCategoria(Guid id)
        {
            var recetas = db.Recetas.Where(x => x.CategoriaID == id).ToList();

            recetas.ForEach(receta =>
            {
                receta.RecetaPasos = db.RecetaPasos.Where(y => y.RecetaID == receta.Id).ToList();
                receta.RecetaIngredientes = db.RecetaIngredientes.Where(y => y.RecetaID == receta.Id).ToList();
            });

            return recetas;
        }

        public List<Receta> ListarPorIngrediente(Guid id)
        {
            var recetas = db.Recetas.Where(x => x.RecetaIngredientes.Any(y => y.Id == id)).ToList();

            recetas.ForEach(receta =>
            {
                receta.RecetaPasos = db.RecetaPasos.Where(y => y.RecetaID == receta.Id).ToList();
                receta.RecetaIngredientes = db.RecetaIngredientes.Where(y => y.RecetaID == receta.Id).ToList();
            });

            return recetas;
        }

        public Receta Editar(Receta entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Guid id)
        {
            var receta = db.Recetas.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Receta no encontrada");
            var recetaPasos = db.RecetaPasos.Where(x => x.RecetaID == id).ToList();
            var recetaIngredientes = db.RecetaIngredientes.Where(x => x.RecetaID == id).ToList();
            var likes = db.Likes.Where(x => x.ReferenciaID == id).ToList();
            var comments = db.Comentarios.Where(x => x.ReferenciaID == id).ToList();

            // eliminar los pasos
            recetaPasos.ForEach(
                paso =>
                {
                    db.RecetaPasos.Remove(paso);
                }
            );

            // eliminar los ingredientes
            recetaIngredientes.ForEach(
                ingrediente =>
                {
                    db.RecetaIngredientes.Remove(ingrediente);
                }
            );

            // eliminar los likes
            likes.ForEach(
                like =>
                {
                    db.Likes.Remove(like);
                }
            );

            // eliminar los comentarios
            comments.ForEach(
                comment =>
                {
                    db.Comentarios.Remove(comment);
                }
             );
        }

        public void Guardar()
        {
            db.SaveChanges();
        }
    }
}

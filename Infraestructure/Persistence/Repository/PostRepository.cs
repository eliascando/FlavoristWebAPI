using Domain.Entities;
using Domain.Interfaces.Repository;
using Infraestructure.Persistence.Context;

namespace Infraestructure.Persistence.Repository
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
            var recetaEditada = entidad;

            db.Recetas.Update(entidad);
            db.SaveChanges();
            return recetaEditada;
        }

        public void Eliminar(Guid id)
        {
            var receta = db.Recetas.Find(id);
            if (receta == null) throw new Exception("Receta no encontrada");

            // Eliminar pasos de la receta
            var recetaPasos = db.RecetaPasos.Where(x => x.RecetaID == id);
            foreach (var paso in recetaPasos)
            {
                db.RecetaPasos.Remove(paso);
            }

            // Eliminar ingredientes de la receta
            var recetaIngredientes = db.RecetaIngredientes.Where(x => x.RecetaID == id);
            foreach (var ingrediente in recetaIngredientes)
            {
                db.RecetaIngredientes.Remove(ingrediente);
            }

            // Eliminar likes asociados a la receta
            var likes = db.Likes.Where(x => x.ReferenciaID == id);
            foreach (var like in likes)
            {
                db.Likes.Remove(like);
            }

            // Eliminar comentarios asociados a la receta
            var comments = db.Comentarios.Where(x => x.ReferenciaID == id);
            foreach (var comment in comments)
            {
                db.Comentarios.Remove(comment);
            }

            // Eliminar publicación asociada, si existe
            var publicacion = db.Publicaciones.FirstOrDefault(x => x.ReferenciaID == id);
            if (publicacion != null)
            {
                db.Publicaciones.Remove(publicacion);
            }

            // Eliminar evento asociado, si existe
            var evento = db.Eventos.FirstOrDefault(x => x.Id == id);
            if (evento != null)
            {
                // Eliminar notificación asociada al evento, si existe
                var notificacion = db.Notificaciones.FirstOrDefault(x => x.EventoID == evento.Id);
                if (notificacion != null)
                {
                    db.Notificaciones.Remove(notificacion);
                }

                db.Eventos.Remove(evento);
            }

            // Finalmente, eliminar la receta
            db.Recetas.Remove(receta);

            db.SaveChanges();
        }


        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<Receta> ListorPorSeguidos(Guid idUsuario)
        {
            var follows = db.Follows.Where(x => x.SeguidorID == idUsuario).ToList();
            var recetas = new List<Receta>();

            follows.ForEach(follow =>
            {
                var recetasUsuario = db.Recetas.Where(x => x.UsuarioID == follow.SeguidoID).ToList();

                recetasUsuario.ForEach(receta =>
                {
                    receta.RecetaPasos = db.RecetaPasos.Where(y => y.RecetaID == receta.Id).ToList();
                    receta.RecetaIngredientes = db.RecetaIngredientes.Where(y => y.RecetaID == receta.Id).ToList();
                });

                recetas.AddRange(recetasUsuario);
            });
            
            return recetas;
        }

        public List<Receta> ListarExplorer(Guid idUsuario)
        {
            // Primero, intenta encontrar recetas en categorías favoritas
            var preferenciasCategorias = db.UsuarioRecetaCategoriaFavs.Where(x => x.UsuarioID == idUsuario).ToList();
            var recetas = new List<Receta>();

            preferenciasCategorias.ForEach(preferencia =>
            {
                var recetasDeCategoria = db.Recetas
                                           .Where(x => x.CategoriaID == preferencia.RecetaCategoriaID)
                                           .ToList();
                recetas.AddRange(recetasDeCategoria);
            });

            if (recetas.Count == 0)
            {
                recetas = db.Recetas
                            .Where(r => r.UsuarioID != idUsuario)
                            .ToList()
                            .Select(r => new
                            {
                                Receta = r,
                                NumeroLikes = db.Likes.Count(l => l.ReferenciaID == r.Id),
                                NumeroComentarios = db.Comentarios.Count(c => c.ReferenciaID == r.Id)
                            })
                            .OrderByDescending(r => r.NumeroLikes)
                            .ThenByDescending(r => r.NumeroComentarios)
                            .Select(r => r.Receta)
                            .Take(50) // Limita el número de recetas devueltas
                            .ToList();
            }
            recetas.ForEach(receta =>
            {
                db.Entry(receta).Collection(r => r.RecetaPasos).Load();
                db.Entry(receta).Collection(r => r.RecetaIngredientes).Load();
            });

            return recetas;
        }


    }
}

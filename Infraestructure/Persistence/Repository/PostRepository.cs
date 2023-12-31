﻿using Domain.Entities;
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
            var receta = db.Recetas.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Receta no encontrada");
            var recetaPasos = db.RecetaPasos.Where(x => x.RecetaID == id).ToList() ?? throw new Exception("RecetaPasos no encontrados");
            var recetaIngredientes = db.RecetaIngredientes.Where(x => x.RecetaID == id).ToList() ?? throw new Exception("RecetaIngredientes no encontrados");
            var likes = db.Likes.Where(x => x.ReferenciaID == id).ToList() ?? throw new Exception("Likes no encontrados");
            var comments = db.Comentarios.Where(x => x.ReferenciaID == id).ToList() ?? throw new Exception("Comentarios no encontrados");

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

            // eliminar la publicacion, el evento y notificacion
            var publicacion = db.Publicaciones.Where(x => x.ReferenciaID == id).FirstOrDefault() ?? throw new Exception("Publicacion no encontrada");
            var evento = db.Eventos.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Evento no encontrado");
            var notificacion = db.Notificaciones.Where(x => x.EventoID == evento.Id).FirstOrDefault() ?? throw new Exception("Notificacion no encontrada");

            db.Publicaciones.Remove(publicacion);
            db.Eventos.Remove(evento);
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
    }
}

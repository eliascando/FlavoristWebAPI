using Domain.Interfaces.Repository;
using Domain.Entities;
using Infraestructure.Persistence.Context;
using Domain.DTOs;
using System.Diagnostics;

namespace Infraestructure.Persistence.Repository
{
    public class LikeRepository
        : IRepositoryLike<Like, LikeDTO, UserDTO, Guid, Guid>
    {
        private DBContext db;

        public LikeRepository(DBContext _db)
        {
            db = _db;
        }

        //Dar like a un post
        public Like DarLike(Like entidad)
        {
            db.Likes.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        //Obtener cantidad de likes por el id de un post 
        public int ObtenerCantidadLikeDePost(Guid id)
        {
            var likes = db.Likes.Where(x => x.ReferenciaID == id).ToList();
            return likes.Count;
        }

        //Obtener lista de usuarios que le dieron like a un post
        public List<UserDTO> ObtenerLikesOwners(Guid idReferencia)
        {
            //Evento like EventoTipoID = 1

            var likes = db.Likes.Where(x => x.ReferenciaID == idReferencia).ToList();

            var listaUsuarios = new List<UserDTO>();
            var listaEventos = new List<Evento>();

            likes.ForEach(
                like =>
                {
                    var evento = db.Eventos.Where(x => x.Id == like.EventoID && x.EventoTipoID == 1).FirstOrDefault() ?? throw new Exception("Evento no encontrado");
                
                    listaEventos.Add(evento);
                }
            );

            listaEventos.ForEach(
                evento =>
                {
                    var usuario = db.Usuarios.Where(x => x.Id == evento.UsuarioID && x.Estado == true).FirstOrDefault() ?? throw new Exception("Usuario no encontrado");

                    var followDTO = new UserDTO()
                    {
                        Id = usuario.Id,
                        Nombres = usuario.Nombres,
                        Apellidos = usuario.Apellidos,
                        Correo = usuario.Correo,
                        Foto = usuario.Foto,
                    };

                    listaUsuarios.Add(followDTO);
                }
            );

            return listaUsuarios;
        }

        // Eliminar like por usuario y post
        public bool EliminarLikePorUsuarioYPost(Guid idUsuario, Guid idReferencia)
        {
            var likes = db.Likes.Where(x => x.ReferenciaID == idReferencia).ToList();

            var eventosDelUsuario = db.Eventos.Where(e => e.UsuarioID == idUsuario).Select(e => e.Id).ToList();
            var likeDelUsuario = likes.FirstOrDefault(l => eventosDelUsuario.Contains(l.EventoID));

            if (likeDelUsuario == null)
            {
                return false;
            }

            var evento = db.Eventos.FirstOrDefault(e => e.Id == likeDelUsuario.EventoID);
            var notificacion = db.Notificaciones.FirstOrDefault(n => n.EventoID == likeDelUsuario.EventoID);

            if (evento == null || notificacion == null)
            {
                return false;
            }

            // Elimina el like, el evento y la notificación.
            db.Likes.Remove(likeDelUsuario);
            db.Eventos.Remove(evento);
            db.Notificaciones.Remove(notificacion);

            db.SaveChanges();

            return !db.Likes.Any(l => l.Id == likeDelUsuario.Id) &&
                   !db.Eventos.Any(e => e.Id == evento.Id) &&
                   !db.Notificaciones.Any(n => n.Id == notificacion.Id);
        }

        public Like DarLikeDesdeDTO(LikeDTO entidadDTO)
        {
            throw new NotImplementedException();
        }

        public bool ExisteLikeDeUsuarioEnPost(Guid usuarioID, Guid referenciaID)
        {
            try
            {
                Debug.Write($" usuarioID: {usuarioID}, referenciaID: {referenciaID}");

                // Verificar si existe un like del usuario para la referencia específica
                var existeLike = db.Likes
                    .Join(db.Eventos,
                          like => like.EventoID,
                          evento => evento.Id,
                          (like, evento) => new { Like = like, Evento = evento })
                    .Any(le => le.Like.ReferenciaID == referenciaID && le.Evento.UsuarioID == usuarioID && le.Evento.EventoTipoID == 1);

                Debug.Write($" existe like? {existeLike}");
                return existeLike;
            }
            catch (Exception ex)
            {
                Debug.Write($"Excepción: {ex.Message}");
                return false;
            }
        }

    }
}

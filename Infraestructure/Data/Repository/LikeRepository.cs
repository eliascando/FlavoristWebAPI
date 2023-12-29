using Domain.Interfaces.Repository;
using Domain.Entities;
using Infraestructure.Data.Context;
using Domain.DTOs;
using Domain.Interfaces;
using System.Diagnostics;

namespace Infraestructure.Data.Repository
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


        //Eliminar like
        public bool EliminarLikePorUsuarioYPost(Guid idUsuario, Guid idReferencia)
        {
            Debug.WriteLine("idUsuario: " + idUsuario);
            Debug.WriteLine("idPost: " + idReferencia);

            var likes = db.Likes.Where(x => x.ReferenciaID == idReferencia).ToList();


            var evento = new List<Evento>();
            var likeFiltrado = new List<Like>();
            var notificaciones = new List<Notificacion>();

            likes.ForEach(
                like =>
                {
                    var eventos = db.Eventos.Where(x => x.Id == like.EventoID && x.UsuarioID == idUsuario).ToList() ?? throw new Exception("Evento no encontrado");
                    
                    evento.AddRange(eventos);
                }
            );

            likeFiltrado = likes.Where(x => x.EventoID == evento[0].Id).ToList() ?? throw new Exception("Like no encontrado");


            notificaciones = db.Notificaciones.Where(x => x.EventoID == evento[0].Id).ToList() ?? throw new Exception("Notificacion no encontrada");

            db.Likes.Remove(likeFiltrado[0]);
            db.Eventos.Remove(evento[0]);
            db.Notificaciones.Remove(notificaciones[0]);

            db.SaveChanges();
            return (db.Notificaciones.Where(x => x.EventoID == evento[0].Id).FirstOrDefault() == null);
        }

        public Like DarLikeDesdeDTO(LikeDTO entidadDTO)
        {
            throw new NotImplementedException();
        }
    }
}

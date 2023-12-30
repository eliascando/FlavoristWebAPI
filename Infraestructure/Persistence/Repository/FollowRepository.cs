using Domain.Entities;
using Domain.DTOs;
using Domain.Interfaces.Repository;
using Infraestructure.Persistence.Context;

namespace Infraestructure.Persistence.Repository
{
    public class FollowRepository
        : IRepositoryBase<Follow, Guid>
    {
        private DBContext db;

        public FollowRepository(DBContext _db)
        {
            db = _db;
        }

        public Follow Agregar(Follow entidad)
        {
            db.Follows.Add(entidad);
            return entidad;
        }

        public Follow ObtenerPorId(Guid id)
        {
            var follow = db.Follows.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Follow no encontrado");
            return follow;
        }

        public Follow Editar(Follow entidad)
        {
            throw new Exception("No se puede editar un follow");
        }

        public void Eliminar(Follow entidad)
        {
            var follow = db.Follows.Where(x => x.Id == entidad.Id).FirstOrDefault() ?? throw new Exception("Follow no encontrado");

            var evento = db.Eventos.Where(x => x.Id == follow.EventoID).FirstOrDefault() ?? throw new Exception("Evento no encontrado");

            var notificacion = db.Notificaciones.Where(x => x.EventoID == evento.Id).FirstOrDefault() ?? throw new Exception("Notificacion no encontrada");


            db.Notificaciones.Remove(notificacion);
            db.Eventos.Remove(evento);
            db.Follows.Remove(follow);

            db.SaveChanges();
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<Follow> Listar()
        {
            return db.Follows.ToList();
        }

        public Follow ObtenerPorUsuario(Guid id)
        {
            var follow = db.Follows.Where(x => x.SeguidorID == id).FirstOrDefault() ?? throw new Exception("Follow no encontrado");
            return follow;
        }
    }

    public class FollowsRepository
        : IRepositoryFollow<UserDTO, Guid, Guid, Guid>
    {
        private DBContext db;

        public FollowsRepository(DBContext _db)
        {
            db = _db;
        }
        public List<UserDTO> ObtenerSeguidores(Guid id)
        {
            var ids = db.Follows.Where(x => x.SeguidoID == id).Select(x => x.SeguidorID).ToList();
            var usuarios = db.Usuarios.Where(x => ids.Contains(x.Id)).ToList();

            var followers = new List<UserDTO>();

            usuarios.ForEach(
                x => followers.Add(new UserDTO
                {
                    Id = x.Id,
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos,
                    Correo = x.Correo,
                    Foto = x.Foto
                })
            );

            return followers;
        }

        public List<UserDTO> ObtenerSeguidos(Guid id)
        {
            var ids = db.Follows.Where(x => x.SeguidorID == id).Select(x => x.SeguidoID).ToList();
            var usuarios = db.Usuarios.Where(x => ids.Contains(x.Id)).ToList();

            var followers = new List<UserDTO>();

            usuarios.ForEach(
                x => followers.Add(new UserDTO
                {
                    Id = x.Id,
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos,
                    Correo = x.Correo,
                    Foto = x.Foto
                })
            );
            return followers;
        }

        public bool EliminarPorSeguidorYSeguido(Guid seguidor, Guid seguido)
        {
            var follow = db.Follows.Where(x => x.SeguidorID == seguidor && x.SeguidoID == seguido).FirstOrDefault() ?? throw new Exception("Follow no encontrado");

            var evento = db.Eventos.Where(x => x.Id == follow.EventoID).FirstOrDefault() ?? throw new Exception("Evento no encontrado");

            var notificacion = db.Notificaciones.Where(x => x.EventoID == evento.Id).FirstOrDefault() ?? throw new Exception("Notificacion no encontrada");

            db.Notificaciones.Remove(notificacion);
            db.Eventos.Remove(evento);
            db.Follows.Remove(follow);

            db.SaveChanges();

            if (db.Follows.Where(x => x.SeguidorID == seguidor && x.SeguidoID == seguido).FirstOrDefault() == null)
                return true;
            else
                return false;
        }
    }
}

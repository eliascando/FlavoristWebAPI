using Domain.Entities;
using Domain.DTOs;
using Domain.Interfaces.Repository;
using Infraestructure.Data.Context;

namespace Infraestructure.Data.Repository
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

            db.Follows.Remove(follow);
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
        : IRepositoryFollow<FollowsDTO, Guid>
    {
        private DBContext db;

        public FollowsRepository(DBContext _db)
        {
            db = _db;
        }
        public List<FollowsDTO> ObtenerSeguidores(Guid id)
        {
            var ids = db.Follows.Where(x => x.SeguidoID == id).Select(x => x.SeguidorID).ToList();
            var usuarios = db.Usuarios.Where(x => ids.Contains(x.Id)).ToList();

            var followers = new List<FollowsDTO>();

            usuarios.ForEach(
                x => followers.Add(new FollowsDTO
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

        public List<FollowsDTO> ObtenerSeguidos(Guid id)
        {
            var ids = db.Follows.Where(x => x.SeguidorID == id).Select(x => x.SeguidoID).ToList();
            var usuarios = db.Usuarios.Where(x => ids.Contains(x.Id)).ToList();

            var followers = new List<FollowsDTO>();

            usuarios.ForEach(
                x => followers.Add(new FollowsDTO
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
    }
}

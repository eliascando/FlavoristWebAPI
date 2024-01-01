using Domain.Entities;
using Domain.Interfaces.Repository;
using Infraestructure.Persistence.Context;

namespace Infraestructure.Persistence.Repository
{
    public class PublicacionRepository
        : IRepositoryBase<Publicacion, int, Guid>
    {
        private DBContext db;

        public PublicacionRepository(DBContext _db)
        {
            db = _db;
        }

        public Publicacion Agregar(Publicacion entidad)
        {
            db.Publicaciones.Add(entidad);
            return entidad;
        }

        public List<Publicacion> Listar()
        {
            return db.Publicaciones.ToList();
        }

        public Publicacion ObtenerPorId(Guid id)
        {
            var publicacion = db.Publicaciones.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Publicacion no encontrada");
            return publicacion;
        }

        public Publicacion Editar(Publicacion entidad)
        {
            throw new Exception("No se puede editar una publicacion");
        }

        public void Eliminar(Publicacion entidad)
        {
            var publicacion = db.Publicaciones.Where(x => x.Id == entidad.Id).FirstOrDefault() ?? throw new Exception("Publicacion no encontrada");

            db.Publicaciones.Remove(publicacion);
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public Publicacion ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

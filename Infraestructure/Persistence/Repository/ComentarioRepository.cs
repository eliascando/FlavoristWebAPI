using Domain.Entities;
using Domain.Interfaces.Repository;
using Infraestructure.Persistence.Context;

namespace Infraestructure.Persistence.Repository
{
    public class ComentarioRepository
        : IRepositoryComentario<Comentario, Guid>
    {
        private DBContext db;

        public ComentarioRepository(DBContext _db)
        {
            db = _db;
        }

        public Comentario Agregar (Comentario comentario)
        {
            db.Comentarios.Add(comentario);
            db.SaveChanges();
            return comentario;
        }

        public void EliminarComentario(Guid id)
        {
            var comentario = db.Comentarios.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Comentario no encontrado");

            db.Comentarios.Remove(comentario);
            db.SaveChanges();
        }
         
        public List<Comentario> ObtenerComentariosPadres(Guid id)
        {
                return db.Comentarios
                               .Where(c => c.ReferenciaID == id && c.ComentarioPadreID == null)
                               .ToList();
        }

        public List<Comentario> ObtenerComentariosHijos(Guid id)
        {
            return db.Comentarios
                   .Where(c => c.ComentarioPadreID == id)
                   .ToList();
        }

        public void Guardar()
        {
            db.SaveChanges();
        }
    }
}

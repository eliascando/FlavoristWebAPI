using Domain.Interfaces.Repository;
using Domain.Entities;
using Infraestructure.Persistence.Context;

namespace Infraestructure.Persistence.Repository
{
    public class EventoRepository
        : IRepositoryBase<Evento, int, Guid>
    {
        private DBContext db;

        public EventoRepository(DBContext _db)
        {
            db = _db;
        }

        public Evento Agregar(Evento entidad)
        {
            db.Eventos.Add(entidad);
            return entidad;
        }

        public List<Evento> Listar()
        {
            return db.Eventos.ToList();
        }

        public Evento ObtenerPorId(Guid id)
        {
            var evento = db.Eventos.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Evento no encontrado");
            return evento;
        }

        public Evento ObtenerPorUsuario(Guid id)
        {
            var evento = db.Eventos.Where(x => x.UsuarioID == id).FirstOrDefault() ?? throw new Exception("Evento no encontrado");
            return evento;
        }

        public Evento Editar(Evento entidad)
        {
            throw new Exception("No se puede editar un evento");
        }

        public void Eliminar(Evento entidad)
        {
            var evento = db.Eventos.Where(x => x.Id == entidad.Id).FirstOrDefault() ?? throw new Exception("Evento no encontrado");

            db.Eventos.Remove(evento);
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public Evento ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}

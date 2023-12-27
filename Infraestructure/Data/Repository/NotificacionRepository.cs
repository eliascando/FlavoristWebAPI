using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infraestructure.Data.Context;
using Domain.Interfaces.Repository;



namespace Infraestructure.Data.Repository
{
    public class NotificacionRepository
        : IRepositoryBase<Notificacion, Guid>
    {
        private DBContext db;

        public NotificacionRepository(DBContext _db)
        {
            db = _db;
        }

        public Notificacion Agregar(Notificacion entidad)
        {
            db.Notificaciones.Add(entidad);
            return entidad;
        }

        public List<Notificacion> Listar()
        {
            return db.Notificaciones.ToList();
        }

        public Notificacion ObtenerPorId(Guid id)
        {
            var notificacion = db.Notificaciones.Where(x => x.Id == id).FirstOrDefault() ?? throw new Exception("Notificacion no encontrada");
            return notificacion;
        }

        public Notificacion ObtenerPorUsuario(Guid id)
        {
            throw new NotImplementedException();
        }

        public Notificacion Editar(Notificacion entidad)
        {
           throw new NotImplementedException();
        }

        public void Eliminar(Notificacion entidad)
        {
            var notificacion = db.Notificaciones.Where(x => x.Id == entidad.Id).FirstOrDefault() ?? throw new Exception("Notificacion no encontrada");

            db.Notificaciones.Remove(notificacion);
        }

        public void Guardar()
        {
            db.SaveChanges();
        }
    }
}

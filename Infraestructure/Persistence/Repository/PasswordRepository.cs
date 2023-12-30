using Domain.Interfaces.Repository;
using Infraestructure.Persistence.Context;

namespace Infraestructure.Persistence.Repository
{
    public class PasswordRepository
        : IRepositoryPassword<Guid, string>
    {
        private readonly DBContext _db;

        public PasswordRepository(DBContext db)
        {
            _db = db;
        }

        public bool CambiarPassword(Guid id, string pass)
        {
            var usuario = _db.Usuarios.Find(id);

            if (usuario == null)
            {
                return false;
            }

            usuario.Password = pass;

            _db.Update(usuario);
            _db.SaveChanges();
            return true;
        }
        
        public string ObtenerCorreo(Guid id)
        {
            var usuario = _db.Usuarios.Find(id);

            if (usuario == null)
            {
                return null;
            }

            return usuario.Correo;
        }
    }
}

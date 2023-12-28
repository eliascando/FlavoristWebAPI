using Domain.Entities;
using Domain.DTOs;
using Domain.Interfaces.Repository;
using Infraestructure.Data.Context;

namespace Infraestructure.Data.Repository
{
    public class LoginRepository
        : IRepositoryAuthorization<AuthDTO, Usuario>
    {
        private DBContext db;

        public LoginRepository(DBContext _db)
        {
            db = _db;
        }

        public Usuario Login(AuthDTO entity)
        {
            var user = db.Set<Usuario>()
                         .Where(u => u.Correo == entity.Correo)
                         .FirstOrDefault() ?? throw new Exception("Usuario no encontrado");
            return user;
        }
    }
}

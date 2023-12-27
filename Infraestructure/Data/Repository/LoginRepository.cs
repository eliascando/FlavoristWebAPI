using Domain.Entities;
using Domain.DTOs;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repository
{
    public class LoginRepository
        : IRepositoryAuthorization<AuthDTO, Usuario>
    {
        private DbContext db;

        public LoginRepository(DbContext _db)
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

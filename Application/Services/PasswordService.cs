using Application.Interfaces;
using Domain.Interfaces.Repository;

namespace Application.Services
{
    public class PasswordService
        : IServicePassword<Guid, string>
    {

        private readonly IRepositoryPassword<Guid, string> _repository;

        public PasswordService(IRepositoryPassword<Guid, string> repository)
        {
            _repository = repository;
        }

        public bool CambiarPassword(Guid id, string pass)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(pass);
            _repository.CambiarPassword(id, hash);
            return true;
        }

        public string ObtenerCorreo(Guid id)
        {
            return _repository.ObtenerCorreo(id);
        }
    }
}

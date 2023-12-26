using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class AuthResultDTO
    {
        public Guid Id { get; set; }
        public string NombresCompletos { get; set; }
        public string Correo { get; set; }
        public string UsuarioTipo { get; set; }
        public string Token { get; set; }
    }
}

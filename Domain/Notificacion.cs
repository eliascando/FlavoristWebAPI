using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Notificacion
    {
        public Guid Id { get; set; }
        public Guid UsuarioID { get; set; }
        public Guid EventoId { get; set; }
        public Boolean Visto { get; set; }
        public DateTime Fecha { get; set; }
    }
}

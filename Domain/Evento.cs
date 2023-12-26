using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Evento
    {
        public Guid Id { get; set; }
        public int EventoTipoID { get; set; }
        public DateTime FechaHora { get; set; }
    }
}

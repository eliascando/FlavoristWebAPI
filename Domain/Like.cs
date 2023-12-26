using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Like
    {
        public int Id { get; set; }
        public Guid EntidadID { get; set; }
        public int EntidadTipoID { get; set; }
        public Guid UsuarioID { get; set; }
        public DateTime FechaHora { get; set; }
        public int EventoID { get; set; }
    }
}

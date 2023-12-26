using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UsuarioRecetaCategoriaFav
    {
        public Guid Id { get; set; }
        public Guid RecetaCategoriaID { get; set; }
        public Guid UsuarioID { get; set; }
    }
}

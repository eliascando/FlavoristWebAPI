using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UsuarioTipo
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        ///* Listas de objetos de relación */
        //public List<Usuario> Usuarios { get; set; }
    }
}

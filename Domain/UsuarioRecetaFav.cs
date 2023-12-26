using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UsuarioRecetaFav
    {
        public Guid Id { get; set; }
        public Guid RecetaID { get; set; }
        public Guid UsuarioID { get; set; }

        ///*Objetos de Relacion*/
        //public Receta Receta { get; set; }
        //public Usuario Usuario { get; set; }
    }
}

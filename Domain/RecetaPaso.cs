using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RecetaPaso
    {
        public int Id { get; set; }
        public Guid RecetaID { get; set; }
        public int Orden { get; set; }
        public string Descripcion { get; set; }
        public byte[]? Imagen { get; set; }

        ///*Objetos de Relacion*/
        //public Receta Receta { get; set; }
    }
}

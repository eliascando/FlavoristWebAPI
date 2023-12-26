using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RecetaIngrediente
    {
        public int Id { get; set; }
        public Guid RecetaID { get; set; }
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public int UnidadMedidaID { get; set; }
        public Guid CategoriaID { get; set; }
    }
}

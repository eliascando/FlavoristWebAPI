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

        ///* Objetos de Relacion */
        //public Receta Receta { get; set; }
        //public UnidadMedida UnidadMedida { get; set; }
        //public IngredienteCategoria Categoria { get; set; } 
    }
}

namespace Domain.Entities
{
    public class RecetaIngrediente
    {
        public Guid Id { get; set; }
        public Guid RecetaID { get; set; }
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public int UnidadMedidaID { get; set; }
        public Guid CategoriaID { get; set; }
    }
}

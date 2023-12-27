namespace Domain.Entities
{
    public class UsuarioRecetaCategoriaFav
    {
        public Guid Id { get; set; }
        public Guid RecetaCategoriaID { get; set; }
        public Guid UsuarioID { get; set; }
    }
}

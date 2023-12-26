namespace Domain
{
    public class UsuarioRecetaFav
    {
        public Guid Id { get; set; }
        public Guid RecetaID { get; set; }
        public Guid UsuarioID { get; set; }
    }
}

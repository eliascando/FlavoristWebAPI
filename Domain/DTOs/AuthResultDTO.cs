namespace Domain.DTOs
{
    public class AuthResultDTO
    {
        public Guid Id { get; set; }
        public string NombresCompletos { get; set; }
        public string Correo { get; set; }
        public string UsuarioTipo { get; set; }
        public string Token { get; set; }
    }
}

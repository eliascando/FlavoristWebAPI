namespace Domain.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set;}
        public byte[] ? Foto { get; set; }
    }
}

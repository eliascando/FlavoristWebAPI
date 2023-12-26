namespace Domain
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public Guid PaisID { get; set; }
        public Guid UsuarioTipoID { get; set; }
        public Boolean Estado { get; set; }
        public byte[] ? Foto { get; set; }
    }
}

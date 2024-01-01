using Domain.Entities;

namespace Domain.DTOs
{
    public class RecetaDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Categoria { get; set; }
        public string Dificultad { get; set; }
        public int Porciones { get; set; }
        public decimal Costo { get; set; }
    }
}

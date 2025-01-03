﻿namespace Domain.Entities
{
    public class Receta
    {
        public Guid Id { get; set; }
        public Guid UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal TiempoPreparacion { get; set; }
        public byte[] Imagen { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid CategoriaID { get; set; }
        public int DificultadID { get; set; }
        public int Porciones { get; set; }
        public decimal Costo { get; set; }
        public List<RecetaPaso> ? RecetaPasos { get; set; }
        public List<RecetaIngrediente> ? RecetaIngredientes { get; set; }
    }
}

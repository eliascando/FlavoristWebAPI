using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Config
{
    public class RecetaConfig : IEntityTypeConfiguration<Receta>
    {
        public void Configure(EntityTypeBuilder<Receta> builder)
        {
            builder.ToTable("Recetas");

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.UsuarioID).IsRequired();
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Descripcion).IsRequired();
            builder.Property(p => p.TiempoPreparacion).IsRequired();
            builder.Property(p => p.Porciones).IsRequired();
            builder.Property(p => p.FechaCreacion).IsRequired();
            builder.Property(p => p.CategoriaID).IsRequired();
            builder.Property(p => p.DificultadID).IsRequired();
            builder.Property(p => p.Porciones).IsRequired();
            builder.Property(p => p.Costo).IsRequired();
            
            builder.HasKey(p => p.Id);
        }
    }
}

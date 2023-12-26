using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class RecetaConfig : IEntityTypeConfiguration<Receta>
    {
        public void Configure(EntityTypeBuilder<Receta> builder)
        {
            builder.ToTable("Receta");

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
            builder.Property(p => p.EventoID).IsRequired();
            
            builder.HasKey(p => p.Id);
        }
    }
}

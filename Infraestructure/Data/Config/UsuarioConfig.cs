using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.Nombres).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Apellidos).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Correo).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.FechaNacimiento).IsRequired();
            builder.Property(u => u.Genero).IsRequired();
            builder.Property(u => u.PaisID).IsRequired();
            builder.Property(u => u.UsuarioTipoID).IsRequired();
            builder.Property(u => u.Estado).HasDefaultValue(true);

            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Correo).IsUnique();
        }
    }
}

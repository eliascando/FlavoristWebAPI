using Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Config
{
    public class UsuarioTipoConfig : IEntityTypeConfiguration<UsuarioTipo>
    {
        public void Configure(EntityTypeBuilder<UsuarioTipo> builder)
        {
            builder.ToTable("UsuarioTipos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Nombre).IsRequired();
        }
    }
}

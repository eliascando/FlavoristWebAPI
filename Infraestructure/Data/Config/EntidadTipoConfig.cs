using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class EntidadTipoConfig : IEntityTypeConfiguration<EntidadTipo>
    {
        public void Configure(EntityTypeBuilder<EntidadTipo> builder)
        {
            builder.ToTable("EntidadTipo");


            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasKey(e => e.Id);
        }
    }
}

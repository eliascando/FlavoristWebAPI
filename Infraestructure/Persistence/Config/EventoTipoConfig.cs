using Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Config
{
    public class EventoTipoConfig : IEntityTypeConfiguration<EventoTipo>
    {
        public void Configure(EntityTypeBuilder<EventoTipo> builder)
        {
            builder.ToTable("EventoTipos");


            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasKey(e => e.Id);
        }
    }
}

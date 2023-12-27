using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class RecetaPasoConfig : IEntityTypeConfiguration<RecetaPaso>
    {
        public void Configure(EntityTypeBuilder<RecetaPaso> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.RecetaID).IsRequired();
            builder.Property(e => e.Orden).IsRequired();
            builder.Property(e => e.Descripcion).IsRequired();
            builder.Property(e => e.Imagen).IsRequired(false);
        }
    }
}

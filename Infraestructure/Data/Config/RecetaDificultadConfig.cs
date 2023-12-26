using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class RecetaDificultadConfig : IEntityTypeConfiguration<RecetaDificultad>
    {
        public void Configure(EntityTypeBuilder<RecetaDificultad> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(50);
        }
    }
}

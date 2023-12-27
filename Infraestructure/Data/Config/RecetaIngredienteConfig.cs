using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class RecetaIngredienteConfig : IEntityTypeConfiguration<RecetaIngrediente>
    {
        public void Configure(EntityTypeBuilder<RecetaIngrediente> builder)
        {
            builder.ToTable("RecetaIngrediente");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.RecetaID).IsRequired();
            builder.Property(x => x.Nombre).IsRequired();
            builder.Property(x => x.Cantidad).IsRequired();
            builder.Property(x => x.UnidadMedidaID).IsRequired();
            builder.Property(x => x.CategoriaID).IsRequired();
        }
    }
}

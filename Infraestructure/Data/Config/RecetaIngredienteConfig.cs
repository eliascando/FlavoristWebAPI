using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
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

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.RecetaID).IsRequired();
            builder.Property(x => x.Nombre).IsRequired();
            builder.Property(x => x.Cantidad).IsRequired();
            builder.Property(x => x.UnidadMedidaID).IsRequired();
            builder.Property(x => x.CategoriaID).IsRequired();

            //builder.HasOne(x => x.Receta).WithMany(x => x.RecetaIngredientes).HasForeignKey(x => x.RecetaID);
        }
    }
}

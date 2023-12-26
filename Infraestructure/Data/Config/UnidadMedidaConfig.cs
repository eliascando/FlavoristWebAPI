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
    public class UnidadMedidaConfig : IEntityTypeConfiguration<UnidadMedida>
    {
        public void Configure(EntityTypeBuilder<UnidadMedida> builder)
        {
            builder.HasKey(builder => builder.Id);

            builder.Property(builder => builder.Id).ValueGeneratedOnAdd();
            builder.Property(builder => builder.Nombre).IsRequired().HasMaxLength(50);
        }
    }
}

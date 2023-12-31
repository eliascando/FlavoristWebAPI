﻿using Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Config
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

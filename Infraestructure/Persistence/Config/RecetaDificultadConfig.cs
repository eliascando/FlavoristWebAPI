﻿using Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Config
{
    public class RecetaDificultadConfig : IEntityTypeConfiguration<RecetaDificultad>
    {
        public void Configure(EntityTypeBuilder<RecetaDificultad> builder)
        {
            builder.ToTable("RecetaDificultades");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(50);
        }
    }
}

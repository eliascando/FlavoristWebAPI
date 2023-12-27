using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class ComentarioConfig : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentarios");

            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.ComentarioPadreID).IsRequired();
            builder.Property(e => e.ReferenciaID).IsRequired();
            builder.Property(e => e.Texto).IsRequired();
            builder.Property(e => e.EventoTipoID).IsRequired();
            builder.Property(e => e.EventoID).IsRequired();

            builder.HasKey(e => e.Id);
        }
    }
}

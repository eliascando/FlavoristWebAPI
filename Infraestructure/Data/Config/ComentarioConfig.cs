using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class ComentarioConfig : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.EntidadID).IsRequired();
            builder.Property(e => e.EntidadTipoID).IsRequired();
            builder.Property(e => e.UsuarioID).IsRequired();
            builder.Property(e => e.Texto).IsRequired();
            builder.Property(e => e.FechaHora).IsRequired();
            builder.Property(e => e.EventoID).IsRequired();

            builder.HasKey(e => e.Id);
        }
    }
}

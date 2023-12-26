using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class LikeConfig : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Like");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.EntidadID).IsRequired();
            builder.Property(e => e.EntidadTipoID).IsRequired();
            builder.Property(e => e.UsuarioID).IsRequired();
            builder.Property(e => e.FechaHora).IsRequired();
            builder.Property(e => e.EventoID).IsRequired();
        }
    }   
}

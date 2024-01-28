
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Config
{
    public class NotificacionesHistoricoConfig: IEntityTypeConfiguration<NotificacionesHistorico>
    {
        public void Configure(EntityTypeBuilder<NotificacionesHistorico> builder)
        {
            builder.ToTable("NotificacionesHistorico");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.UsuarioID).IsRequired();
        }
    }
}
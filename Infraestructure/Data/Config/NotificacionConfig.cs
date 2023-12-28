using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Config
{
    public class NotificacionConfig: IEntityTypeConfiguration<Notificacion>
    {
        public void Configure(EntityTypeBuilder<Notificacion> builder)
        {
            builder.ToTable("Notificaciones");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.EventoID).IsRequired();
            builder.Property(e => e.FechaHora).IsRequired();
        }
    }
}

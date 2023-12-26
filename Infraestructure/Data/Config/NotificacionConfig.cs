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
    public class NotificacionConfig: IEntityTypeConfiguration<Notificacion>
    {
        public void Configure(EntityTypeBuilder<Notificacion> builder)
        {
            builder.ToTable("Notificacion");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("NotificacionID");
            builder.Property(e => e.UsuarioID).HasColumnName("UsuarioID");
            builder.Property(e => e.EventoId).HasColumnName("EventoID");
            builder.Property(e => e.Visto).HasColumnName("Visto");
            builder.Property(e => e.Fecha).HasColumnName("Fecha");
        }
    }
}

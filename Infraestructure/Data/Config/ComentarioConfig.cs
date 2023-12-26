using Domain;
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

            //builder.HasOne(e => e.EntidadTipo).WithMany().HasForeignKey(e => e.EntidadTipoID);
            //builder.HasOne(e => e.Usuario).WithMany().HasForeignKey(e => e.UsuarioID);
            //builder.HasOne(e => e.Evento).WithMany().HasForeignKey(e => e.EventoID);    
        }
    }
}

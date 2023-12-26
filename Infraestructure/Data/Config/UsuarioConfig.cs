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
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.Nombres).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Apellidos).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Correo).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.FechaNacimiento).IsRequired();
            builder.Property(u => u.Genero).IsRequired();
            builder.Property(u => u.PaisID).IsRequired();
            builder.Property(u => u.UsuarioTipoID).IsRequired();
            builder.Property(u => u.Estado).HasDefaultValue(true);

            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Correo).IsUnique();

            //builder.HasMany(u => u.Comentarios).WithOne(c => c.Usuario).HasForeignKey(c => c.UsuarioID);
            //builder.HasOne(u => u.Pais).WithMany(p => p.Usuarios).HasForeignKey(u => u.PaisID);
            //builder.HasOne(u => u.UsuarioTipo).WithMany(ut => ut.Usuarios).HasForeignKey(u => u.UsuarioTipoID); 
            //builder.HasOne(u => u.UsuarioRecetaCategoriaFav).WithOne(urcf => urcf.Usuario).HasForeignKey<UsuarioRecetaCategoriaFav>(urcf => urcf.UsuarioID);
            //builder.HasOne(u => u.UsuarioRecetaFav).WithOne(urf => urf.Usuario).HasForeignKey<UsuarioRecetaFav>(urf => urf.UsuarioID);

        }
    }
}

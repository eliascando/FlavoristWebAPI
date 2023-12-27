using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infraestructure.Data.Config
{
    public class FollowConfig : IEntityTypeConfiguration<Follow>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Follow> builder)
        {
            builder.ToTable("Follows");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.SeguidoID).IsRequired();
            builder.Property(e => e.SeguidorID).IsRequired();
            builder.Property(e => e.EventoTipoID).IsRequired();
            builder.Property(e => e.EventoID).IsRequired();
        }
    }

}

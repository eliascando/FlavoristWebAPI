using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infraestructure.Data.Config
{
    public class FollowConfig : IEntityTypeConfiguration<Follow>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Follow> builder)
        {
            builder.ToTable("Follow");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.IdSeguidor).IsRequired();
            builder.Property(e => e.IdSeguido).IsRequired();
        }
    }

}

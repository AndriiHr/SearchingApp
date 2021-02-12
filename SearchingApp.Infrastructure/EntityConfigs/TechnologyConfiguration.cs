using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchingApp.DDD.Entities.Shared;

namespace SearchingApp.Infrastructure.EntityConfigs
{
    public class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IsActive);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.TechnologyPart).IsRequired();

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Technologies);
        }
    }
}

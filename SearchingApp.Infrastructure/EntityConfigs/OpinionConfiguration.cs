using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchingApp.DDD.Entities.User;

namespace SearchingApp.Infrastructure.EntityConfigs
{
    public class OpinionConfiguration : IEntityTypeConfiguration<Opinion>
    {
        public void Configure(EntityTypeBuilder<Opinion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description).IsRequired();
            builder.HasOne(x => x.Project).WithMany(x => x.Opinions);
        }
    }
}

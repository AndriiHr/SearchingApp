using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchingApp.DDD.Entities.User;

namespace SearchingApp.Infrastructure.EntityConfigs
{
    class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.IsActive);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.FinishDate).IsRequired();
            builder.HasMany(x => x.Users)
                   .WithMany(x => x.Projects);
                

            builder.HasMany(x => x.Opinions).WithOne(x => x.Project);
        }
    }
}

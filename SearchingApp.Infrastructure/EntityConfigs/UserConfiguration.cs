using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchingApp.DDD.Entities.User;

namespace SearchingApp.Infrastructure.EntityConfigs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(20);
            builder.Property(x => x.IsActive);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.ImageUrl);
            builder.Property(x => x.Role).IsRequired();
 
            builder.HasMany(x => x.Projects)
                   .WithMany(x => x.Users);

            builder.HasMany(x => x.Technologies)
                   .WithOne(x => x.User);

        }
    }
}

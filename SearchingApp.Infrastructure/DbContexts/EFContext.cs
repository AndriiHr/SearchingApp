using Microsoft.EntityFrameworkCore;
using SearchingApp.DDD.Entities.Shared;
using SearchingApp.DDD.Entities.User;

namespace SearchingApp.Infrastructure.DbContexts
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFContext).Assembly);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Opinion> Opinions { get; set; }

    }
}

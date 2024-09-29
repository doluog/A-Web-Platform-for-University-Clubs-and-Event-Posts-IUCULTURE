using IUCULTURE.Back.Core.Domain;
using IUCULTURE.Back.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IUCULTURE.Back.Persistence.Context
{
    public class IUCULTUREContext : DbContext
    {
        public IUCULTUREContext(DbContextOptions<IUCULTUREContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities => this.Set<Activity>();
        public DbSet<Club> Clubs => this.Set<Club>();
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();
        public DbSet<AppRole> AppRoles => this.Set<AppRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

    
}
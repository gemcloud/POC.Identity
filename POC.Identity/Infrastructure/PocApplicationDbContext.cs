using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using POC.Identity.Infrastructure.Entities;
using POC.Identity.Infrastructure.Entities.AspNetIdentity;
using POC.Identity.Infrastructure.EntityConfigurations;
using POC.Identity.Infrastructure.Seed;

namespace POC.Identity.Infrastructure
{
    //public class PocApplicationDbContext : IdentityDbContext<IdentityUser>  //IdentityDbContext<ApplicationUser, ApplicationRole, string>
    public class PocApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

        public PocApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        #region Add Entities
        public virtual DbSet<DashboardMenu> DashboardMenus { get; set; }
        public virtual DbSet<LinkRolesMenu> LinkRolesMenus { get; set; }


        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        #endregion

        /// <summary>
        /// The "Fluent API" Used!
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //----------------------------------------------------------------------------
            //Add Entity DashboardMenu.
            modelBuilder.ApplyConfiguration(new DashboardMenuConfiguration());
            modelBuilder.ApplyConfiguration(new LinkRolesMenuConfiguration());

            //----------------------------------------------------------------------------
            //Add Entity AppGroup.


            //----------------------------------------------------------------------------
            //Add UserRole Entity relationship.
            //modelBuilder.ApplyConfiguration(new ApplicationUserRoleConfiguration());

            //modelBuilder.Entity<Category>().ToTable("Category");
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            //----------------------------------------------------------------------------
            //Add Seed.
            modelBuilder.Seed();
        }

    }
}

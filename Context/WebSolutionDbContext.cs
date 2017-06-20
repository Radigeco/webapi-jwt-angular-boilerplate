using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Context.Entities;
using Context.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Context
{
    public class WebSolutionDbContext : IdentityDbContext<ApiUser>
    {
        public WebSolutionDbContext()
            : base("Identity", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            RequireUniqueEmail = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }

        public static WebSolutionDbContext Create()
        {
            return new WebSolutionDbContext();
        }

    }
}
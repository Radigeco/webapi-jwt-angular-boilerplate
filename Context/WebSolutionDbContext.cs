using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Context.Entities;

namespace Context
{
    public class WebSolutionDbContext : DbContext
    {
        public WebSolutionDbContext()
            : base("Movies")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }

    }
}
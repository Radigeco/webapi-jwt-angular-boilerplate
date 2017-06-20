using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Context.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Context
{
    public class ApplicationDbContext : IdentityDbContext<ApiUser>
    {
        public ApplicationDbContext()
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



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
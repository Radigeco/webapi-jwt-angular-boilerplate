using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity
{
    public class IdentityContext : IdentityDbContext<ApiUser>
    {
        public IdentityContext() : base("IdentityDb", throwIfV1Schema: false)
        {
            RequireUniqueEmail = true;
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}

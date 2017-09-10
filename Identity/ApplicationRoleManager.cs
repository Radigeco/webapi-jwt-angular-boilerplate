using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Identity
{
    public class ApplicationRoleManager : RoleManager<ApiRole>
    {
        public ApplicationRoleManager(IRoleStore<ApiRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var appRoleManager = new ApplicationRoleManager(new RoleStore<ApiRole>(context.Get<IdentityContext>()));

            return appRoleManager;
        }
    }
}
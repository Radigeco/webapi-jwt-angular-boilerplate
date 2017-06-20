using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Context.Identity
{
    public class ApplicationUserManager : UserManager<ApiUser>
    {
        public ApplicationUserManager(IUserStore<ApiUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<WebSolutionDbContext>();
            var appUserManager = new ApplicationUserManager(new UserStore<ApiUser>(appDbContext));
            SetUserValidator(appUserManager);
            SetPasswordValidator(appUserManager);

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                appUserManager.UserTokenProvider = new DataProtectorTokenProvider<ApiUser>(dataProtectionProvider.Create("ASP.NET Identity"))
                {
                    //Code for email confirmation and reset password life time
                    TokenLifespan = TimeSpan.FromHours(6)
                };
            }

            return appUserManager;
        }

        public static void SetUserValidator(ApplicationUserManager appUserManager)
        {
            appUserManager.UserValidator = new UserValidator<ApiUser>(appUserManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
        }

        public static void SetPasswordValidator(ApplicationUserManager appUserManager)
        {
            appUserManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true,
            };
        }
    }
}

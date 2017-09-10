using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity
{
    public class ApiUser : IdentityUser
    {
        [Microsoft.Build.Framework.Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Microsoft.Build.Framework.Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Microsoft.Build.Framework.Required]
        public byte Level { get; set; }

        [Microsoft.Build.Framework.Required]
        public DateTime JoinDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApiUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}

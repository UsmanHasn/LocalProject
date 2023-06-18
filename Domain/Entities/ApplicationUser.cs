using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser<int, IdentityModel.CustomUserLogin, IdentityModel.CustomUserRole,
        IdentityModel.CustomUserClaim>
    {

        public ApplicationUser() : base()
        {
            PreviousUserPasswords = new List<PasswordHistory>();
            UserTimeInInfoLogs = new List<UserTimeInInfoLog>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager, ClaimsIdentity identity = null)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            // userIdentity.AddClaim(new Claim(ClaimTypes.Email, Email));
            userIdentity.AddClaim(new Claim(ClaimTypes.Role, Roles.FirstOrDefault().ToString()));
            //userIdentity.AddClaim(new Claim(ClaimTypes.PrimarySid, Convert.ToString(Id)));


            userIdentity.AddClaim(new Claim("FullName", User.FullName));
            string token = identity?.FindFirst("SsoToken")?.Value;
            if (!string.IsNullOrEmpty(token))
            {
                userIdentity.AddClaim(new Claim("SsoToken", token));
            }
            string? userUniqueId = identity?.FindFirst("UserUniqueId")?.Value;
            if (!string.IsNullOrEmpty(userUniqueId))
            {
                userIdentity.AddClaim(new Claim("UserUniqueId", userUniqueId));
            }
            
            if (UserTimeInInfoLogs != null && UserTimeInInfoLogs.Count > 0)
            {
                if (UserTimeInInfoLogs.Count != 1)
                {
                    var timeInLog = UserTimeInInfoLogs[UserTimeInInfoLogs.Count - 2];
                    userIdentity.AddClaim(new Claim("LastLogin",
                        String.Format("{0:G}", timeInLog.TimeLoggedIn)));
                }
            }
            
            return userIdentity;
        }

        public UserProfile User { get; set; }

        public IList<UserTimeInInfoLog> UserTimeInInfoLogs { get; set; }
        public IList<PasswordHistory> PreviousUserPasswords { get; set; }

    }
}

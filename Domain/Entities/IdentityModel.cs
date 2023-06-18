using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities
{
    public class IdentityModel
    {
        //New drived classes stores
        /// <summary>
        /// Derived classes created to use Id as int as against GUID.
        /// </summary>

        public class CustomUserRole : IdentityUserRole<int>
        {
        }

        public class CustomUserClaim : IdentityUserClaim<int>
        {
        }

        public class CustomUserLogin : IdentityUserLogin<int>
        {
        }

        public class CustomRole : IdentityRole<int, CustomUserRole>
        {
            public CustomRole()
            {
            }

            public CustomRole(string name)
            {
                Name = name;
            }
        }
    }
}

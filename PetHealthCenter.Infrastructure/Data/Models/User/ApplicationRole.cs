using Microsoft.AspNetCore.Identity;

namespace PetHealthCenter.Infrastructure.Data.Models.User
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole() : base()
        {
            
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
            
        }
    }
}

using Microsoft.AspNetCore.Identity;

namespace RepairShopStudio.Infrastructure.Data.Models.User
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

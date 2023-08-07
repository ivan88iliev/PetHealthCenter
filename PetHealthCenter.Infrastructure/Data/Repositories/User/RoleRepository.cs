using PetHealthCenter.Infrastructure.Data.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHealthCenter.Infrastructure.Data.Common.User
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext context;
        public RoleRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public ICollection<ApplicationRole> GetRoles()
        {
            return context.Roles.ToList();
        }
    }
}

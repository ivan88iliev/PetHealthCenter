using RepairShopStudio.Infrastructure.Data.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Infrastructure.Data.Common.User
{
    public interface IRoleRepository
    {
        ICollection<ApplicationRole> GetRoles();
    }
}

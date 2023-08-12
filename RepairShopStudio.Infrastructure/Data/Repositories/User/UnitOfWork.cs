using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Infrastructure.Data.Common.User
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; }

        public IRoleRepository Role { get; }

        public UnitOfWork(IUserRepository user,
            IRoleRepository role)
        {
            User = user;
            Role = role;
        }
    }
}

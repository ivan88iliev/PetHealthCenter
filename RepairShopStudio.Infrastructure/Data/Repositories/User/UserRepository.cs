using RepairShopStudio.Infrastructure.Data.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Infrastructure.Data.Common.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public ApplicationUser GetUser(Guid id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);

            //var user =  context.Users.FirstOrDefault(u => u.Id == id);
            //if (user != null)
            //{
            //    return user;
            //}
            //else
            //{
            //    throw new NullReferenceException();
            //}
        }

        public  ICollection<ApplicationUser> GetUsers()
        {
            return context.Users.ToList();
        }

        public ApplicationUser UpdateUser(ApplicationUser user)
        {
            context.Update(user);
            context.SaveChanges();

            return user;
        }
    }
}

using RepairShopStudio.Infrastructure.Data.Models.User;

namespace RepairShopStudio.Infrastructure.Data.Common.User
{
    public interface IUserRepository
    {

        ICollection<ApplicationUser> GetUsers();

        ApplicationUser GetUser(Guid id);

        ApplicationUser UpdateUser(ApplicationUser user);
    }
}

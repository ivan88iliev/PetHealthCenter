using PetHealthCenter.Infrastructure.Data.Models.User;

namespace PetHealthCenter.Infrastructure.Data.Common.User
{
    public interface IUserRepository
    {

        ICollection<ApplicationUser> GetUsers();

        ApplicationUser GetUser(Guid id);

        ApplicationUser UpdateUser(ApplicationUser user);
    }
}

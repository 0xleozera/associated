using System.Threading.Tasks;
using Associated.Domain;

namespace Associated.Repositories.Interfaces
{
  public interface IUserRepository : IRepositoryBase<User>
  {
    Task<User> AuthUser(User user);
  }
}

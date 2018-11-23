using Associated.Domain;

namespace Associated.Repositories.Interfaces
{
  public interface IUserRepository : IRepositoryBase<User>
  {
    User AuthUser(User user);
  }
}

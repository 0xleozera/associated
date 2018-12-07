using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associated.Domain;
using Associated.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Associated.Repositories.Data
{
  public class UserRepository : IUserRepository
  {
    private DataContext dataContext;

    public UserRepository(DataContext dataContext)
    {
      this.dataContext = dataContext;
    }

    public async Task<User> AuthUser(User user)
    {
      return await dataContext.Users.SingleOrDefaultAsync(u => u.Name == user.Name && u.Password == user.Password);
    }

    public async Task Create(User user)
    {
      dataContext.Add(user);
      await dataContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      dataContext.Remove(GetById(id));
      await dataContext.SaveChangesAsync();
    }

    public async Task<List<User>> GetAll()
    {
      return await dataContext.Users.ToListAsync();
    }

    public async Task<User> GetById(int id)
    {
      return await dataContext.Users.SingleOrDefaultAsync(x=> x.Id == id);
    }

    public async Task Update(User user)
    {
      dataContext.Entry(user).State = EntityState.Modified;
      await dataContext.SaveChangesAsync();
    }
  }
}

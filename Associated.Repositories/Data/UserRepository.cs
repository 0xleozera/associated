using System.Collections.Generic;
using System.Linq;
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

    public User AuthUser(User user)
    {
      return dataContext.Users.SingleOrDefault(u => u.Name == user.Name && u.Password == user.Password);
    }

    public void Create(User user)
    {
      dataContext.Add(user);
      dataContext.SaveChanges();
    }

    public void Delete(int id)
    {
      dataContext.Remove(GetById(id));
      dataContext.SaveChanges();
    }

    public List<User> GetAll()
    {
      return dataContext.Users.ToList();
    }

    public User GetById(int id)
    {
      return dataContext.Users.SingleOrDefault(x=> x.Id == id);
    }

    public void Update(User user)
    {
      dataContext.Entry(user).State = EntityState.Modified;
      dataContext.SaveChanges();
    }
  }
}

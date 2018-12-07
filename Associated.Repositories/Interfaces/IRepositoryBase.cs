using System.Collections.Generic;
using System.Threading.Tasks;

namespace Associated.Repositories.Interfaces
{
  public interface IRepositoryBase<Entity> where Entity : class
  {
    Task Create(Entity obj);
    Task<List<Entity>> GetAll();
    Task Update(Entity obj);
    Task<Entity> GetById(int id);
    Task Delete(int id);
  }
}

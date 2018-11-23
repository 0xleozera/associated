using System.Collections.Generic;

namespace Associated.Repositories.Interfaces
{
  public interface IRepositoryBase<Entity> where Entity : class
  {
    void Create(Entity obj);
    List<Entity> GetAll();
    void Update(Entity obj);
    Entity GetById(int id);
    void Delete(int id);
  }
}

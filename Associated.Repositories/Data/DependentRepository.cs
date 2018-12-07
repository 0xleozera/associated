using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associated.Domain;
using Associated.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Associated.Repositories.Data
{
  public class DependentRepository : IDependentRepository
  {
    private DataContext dataContext;

    public DependentRepository(DataContext dataContext)
    {
      this.dataContext = dataContext;
    }

    public async Task Create(Dependent dependent)
    {
      dataContext.Add(dependent);
      await dataContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      dataContext.Remove(GetById(id));
      await dataContext.SaveChangesAsync();
    }

    public async Task<List<Dependent>> GetAll()
    {
      return await dataContext.Dependents.ToListAsync();
    }

    public async Task<Dependent> GetById(int id)
    {
      return await dataContext.Dependents.SingleOrDefaultAsync(x=> x.Id == id);
    }

    public async Task Update(Dependent dependent)
    {
      dataContext.Entry(dependent).State = EntityState.Modified;
      await dataContext.SaveChangesAsync();
    }
  }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associated.Domain;
using Associated.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Associated.Repositories.Data
{
  public class AssociateRepository : IAssociateRepository
  {
    private DataContext dataContext;

    public AssociateRepository(DataContext dataContext)
    {
      this.dataContext = dataContext;
    }

    public async Task Create(Associate associate)
    {
      dataContext.Add(associate);
      await dataContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      dataContext.Remove(GetById(id));
      await dataContext.SaveChangesAsync();
    }

    public async Task<List<Associate>> GetAll()
    {
      return await dataContext.Associated.ToListAsync();
    }

    public async Task<Associate> GetById(int id)
    {
      return await dataContext.Associated.SingleOrDefaultAsync(x=> x.Id == id);
    }

    public async Task Update(Associate associate)
    {
      dataContext.Entry(associate).State = EntityState.Modified;
      await dataContext.SaveChangesAsync();
    }
  }
}

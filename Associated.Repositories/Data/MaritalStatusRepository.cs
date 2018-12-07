using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associated.Domain;
using Associated.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Associated.Repositories.Data
{
  public class MaritalStatusRepository : IMaritalStatusRepository
  {
    private DataContext dataContext;

    public MaritalStatusRepository(DataContext dataContext)
    {
      this.dataContext = dataContext;
    }

    public async Task Create(MaritalStatus maritalStatus)
    {
      dataContext.Add(maritalStatus);
      await dataContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      dataContext.Remove(GetById(id));
      await dataContext.SaveChangesAsync();
    }

    public async Task<List<MaritalStatus>> GetAll()
    {
      return await dataContext.MaritalStatus.ToListAsync();
    }

    public async Task<MaritalStatus> GetById(int id)
    {
      return await dataContext.MaritalStatus.SingleOrDefaultAsync(x=> x.Id == id);
    }

    public async Task Update(MaritalStatus maritalStatus)
    {
      dataContext.Entry(maritalStatus).State = EntityState.Modified;
      await dataContext.SaveChangesAsync();
    }
  }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associated.Domain;
using Associated.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Associated.Repositories.Data
{
  public class KinshipRepository : IKinshipRepository
  {
    private DataContext dataContext;

    public KinshipRepository(DataContext dataContext)
    {
      this.dataContext = dataContext;
    }

    public async Task Create(Kinship kinship)
    {
      dataContext.Add(kinship);
      await dataContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      dataContext.Remove(GetById(id));
      await dataContext.SaveChangesAsync();
    }

    public async Task<List<Kinship>> GetAll()
    {
      return await dataContext.Kinships.ToListAsync();
    }

    public async Task<Kinship> GetById(int id)
    {
      return await dataContext.Kinships.SingleOrDefaultAsync(x=> x.Id == id);
    }

    public async Task Update(Kinship kinship)
    {
      dataContext.Entry(kinship).State = EntityState.Modified;
      await dataContext.SaveChangesAsync();
    }
  }
}

using System.Collections.Generic;
using System.Linq;
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

    public void Create(Kinship kinship)
    {
      dataContext.Add(kinship);
      dataContext.SaveChanges();
    }

    public void Delete(int id)
    {
      dataContext.Remove(GetById(id));
      dataContext.SaveChanges();
    }

    public List<Kinship> GetAll()
    {
      return dataContext.Kinships.ToList();
    }

    public Kinship GetById(int id)
    {
      return dataContext.Kinships.SingleOrDefault(x=> x.Id == id);
    }

    public void Update(Kinship kinship)
    {
      dataContext.Entry(kinship).State = EntityState.Modified;
      dataContext.SaveChanges();
    }
  }
}

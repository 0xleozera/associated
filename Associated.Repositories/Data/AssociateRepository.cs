using System.Collections.Generic;
using System.Linq;
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

    public void Create(Associate associate)
    {
      dataContext.Add(associate);
      dataContext.SaveChanges();
    }

    public void Delete(int id)
    {
      dataContext.Remove(GetById(id));
      dataContext.SaveChanges();
    }

    public List<Associate> GetAll()
    {
      return dataContext.Associated.ToList();
    }

    public Associate GetById(int id)
    {
      return dataContext.Associated.SingleOrDefault(x=> x.Id == id);
    }

    public void Update(Associate associate)
    {
      dataContext.Entry(associate).State = EntityState.Modified;
      dataContext.SaveChanges();
    }
  }
}

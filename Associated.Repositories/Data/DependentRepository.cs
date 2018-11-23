using System.Collections.Generic;
using System.Linq;
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

    public void Create(Dependent dependent)
    {
      dataContext.Add(dependent);
      dataContext.SaveChanges();
    }

    public void Delete(int id)
    {
      dataContext.Remove(GetById(id));
      dataContext.SaveChanges();
    }

    public List<Dependent> GetAll()
    {
      return dataContext.Dependents.ToList();
    }

    public Dependent GetById(int id)
    {
      return dataContext.Dependents.SingleOrDefault(x=> x.Id == id);
    }

    public void Update(Dependent dependent)
    {
      dataContext.Entry(dependent).State = EntityState.Modified;
      dataContext.SaveChanges();
    }
  }
}

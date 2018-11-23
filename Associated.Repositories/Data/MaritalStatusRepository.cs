using System.Collections.Generic;
using System.Linq;
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

    public void Create(MaritalStatus maritalStatus)
    {
      dataContext.Add(maritalStatus);
      dataContext.SaveChanges();
    }

    public void Delete(int id)
    {
      dataContext.Remove(GetById(id));
      dataContext.SaveChanges();
    }

    public List<MaritalStatus> GetAll()
    {
      return dataContext.MaritalStatus.ToList();
    }

    public MaritalStatus GetById(int id)
    {
      return dataContext.MaritalStatus.SingleOrDefault(x=> x.Id == id);
    }

    public void Update(MaritalStatus maritalStatus)
    {
      dataContext.Entry(maritalStatus).State = EntityState.Modified;
      dataContext.SaveChanges();
    }
  }
}

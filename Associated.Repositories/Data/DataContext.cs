using Associated.Domain;
using Microsoft.EntityFrameworkCore;

namespace Associated.Repositories.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Associate> Associated { get; set; }
    public DbSet<Dependent> Dependents { get; set; }
    public DbSet<MaritalStatus> MaritalStatus { get; set; }
    public DbSet<Kinship> Kinships { get; set; }
    public DbSet<User> Users { get; set; }
  }
}

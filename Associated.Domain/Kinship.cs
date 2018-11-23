using System.Collections.Generic;

namespace Associated.Domain
{
  public class Kinship
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public List<Dependent> Dependent { get; set; }
  }
}

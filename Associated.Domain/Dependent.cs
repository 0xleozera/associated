using System;

namespace Associated.Domain
{
  public class Dependent
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Kinship Kinship { get; set; }
  }
}

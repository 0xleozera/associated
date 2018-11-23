using System.Collections.Generic;

namespace Associated.Domain
{
  public class MaritalStatus
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public List<Associate> Associate { get; set; }
  }
}

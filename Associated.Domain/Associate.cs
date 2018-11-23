using System;
using System.Collections.Generic;

namespace Associated.Domain
{
  public class Associate
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Uf { get; set; }
    public string Cep { get; set; }
    public DateTime Date { get; set; }
    public List<Dependent> Dependents { get; set; }
    public  List<MaritalStatus> MaritalStatus { get; set; }
  }
}

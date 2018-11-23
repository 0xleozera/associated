using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Associated.Domain;
using Associated.Repositories;
using Associated.Repositories.Interfaces;

namespace Associated.API.Controllers
{
  [Route("api/[controller]")]
  public class DependentsController : Controller
  {
    private readonly IDependentRepository repository;

    public DependentsController(IDependentRepository repository){
      this.repository = repository;
    }

    [Authorize]
    [HttpGet]
    public IEnumerable<Dependent> Get()
    {
      return this.repository.GetAll();
    }

    [Authorize]
    [HttpGet("{id}")]
    public Dependent Get(int id)
    {
      return this.repository.GetById(id);
    }

    [Authorize]
    [HttpPost]
    public IActionResult Post([FromBody]Dependent dependent)
    {
      this.repository.Create(dependent);
      return Ok(dependent);
    }

    [Authorize]
    [HttpPut]
    public IActionResult Put([FromBody]Dependent dependent)
    {
      this.repository.Update(dependent);
      return Ok(dependent);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      this.repository.Delete(id);

      return Ok(new {
        message = "Deletado com sucesso.",
        id = id
      });
    }
  }
}

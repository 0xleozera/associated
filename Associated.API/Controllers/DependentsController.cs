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
    public async Task<IEnumerable<Dependent>> Get()
    {
      return await this.repository.GetAll();
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<Dependent> Get(int id)
    {
      return await this.repository.GetById(id);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]Dependent dependent)
    {
      await this.repository.Create(dependent);
      return Ok(dependent);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]Dependent dependent)
    {
      await this.repository.Update(dependent);
      return Ok(dependent);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      await this.repository.Delete(id);

      return Ok(new {
        message = "Deletado com sucesso.",
        id = id
      });
    }
  }
}

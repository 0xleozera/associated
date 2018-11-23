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
  public class MaritalStatusController : Controller
  {
    private readonly IMaritalStatusRepository repository;

    public MaritalStatusController(IMaritalStatusRepository repository){
      this.repository = repository;
    }

    [Authorize]
    [HttpGet]
    public IEnumerable<MaritalStatus> Get()
    {
      return this.repository.GetAll();
    }

    [HttpGet("{id}")]
    public MaritalStatus Get(int id)
    {
      return this.repository.GetById(id);
    }

    [HttpPost]
    public IActionResult Post([FromBody]MaritalStatus maritalStatus)
    {
      this.repository.Create(maritalStatus);
      return Ok(maritalStatus);
    }

    [HttpPut]
    public IActionResult Put([FromBody]MaritalStatus maritalStatus)
    {
      this.repository.Update(maritalStatus);
      return Ok(maritalStatus);
    }

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

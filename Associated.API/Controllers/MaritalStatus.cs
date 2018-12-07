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
    public async Task<IEnumerable<MaritalStatus>> Get()
    {
      return await this.repository.GetAll();
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<MaritalStatus> Get(int id)
    {
      return await this.repository.GetById(id);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]MaritalStatus maritalStatus)
    {
      await this.repository.Create(maritalStatus);
      return Ok(maritalStatus);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]MaritalStatus maritalStatus)
    {
      await this.repository.Update(maritalStatus);
      return Ok(maritalStatus);
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

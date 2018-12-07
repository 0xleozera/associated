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
  public class KinshipsController : Controller
  {
    private readonly IKinshipRepository repository;

    public KinshipsController(IKinshipRepository repository){
      this.repository = repository;
    }

    [Authorize]
    [HttpGet]
    public async Task<IEnumerable<Kinship>> Get()
    {
      return await this.repository.GetAll();
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<Kinship> Get(int id)
    {
      return await this.repository.GetById(id);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]Kinship kinship)
    {
      await this.repository.Create(kinship);
      return Ok(kinship);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]Kinship kinship)
    {
      await this.repository.Update(kinship);
      return Ok(kinship);
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

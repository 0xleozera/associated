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
    public IEnumerable<Kinship> Get()
    {
      return this.repository.GetAll();
    }

    [HttpGet("{id}")]
    public Kinship Get(int id)
    {
      return this.repository.GetById(id);
    }

    [HttpPost]
    public IActionResult Post([FromBody]Kinship kinship)
    {
      this.repository.Create(kinship);
      return Ok(kinship);
    }

    [HttpPut]
    public IActionResult Put([FromBody]Kinship kinship)
    {
      this.repository.Update(kinship);
      return Ok(kinship);
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

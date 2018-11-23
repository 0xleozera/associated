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
  public class AssociatedController : Controller
  {
    private readonly IAssociateRepository repository;

    public AssociatedController(IAssociateRepository repository){
      this.repository = repository;
    }

    [Authorize]
    [HttpGet]
    public IEnumerable<Associate> Get()
    {
      return this.repository.GetAll();
    }

    [HttpGet("{id}")]
    public Associate Get(int id)
    {
      return this.repository.GetById(id);
    }

    [HttpPost]
    public IActionResult Post([FromBody]Associate associate)
    {
      this.repository.Create(associate);
      return Ok(associate);
    }

    [HttpPut]
    public IActionResult Put([FromBody]Associate associate)
    {
      this.repository.Update(associate);
      return Ok(associate);
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

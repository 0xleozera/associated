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
using Associated.API.DTOs;

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
    public async Task<IEnumerable<AssociateDTO>> Get()
    {
      var associated = await this.repository.GetAll();
      var associatedDTO = new List<AssociateDTO>();

      associated.ForEach(associate => {
        associatedDTO.Add(new AssociateDTO{ Id = associate.Id, Name = associate.Name, Cpf = associate.Cpf, Email = associate.Email });
      });

      return associatedDTO;
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<Associate> Get(int id)
    {
      return await this.repository.GetById(id);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]Associate associate)
    {
      await this.repository.Create(associate);
      return Ok(associate);
    }

    [Authorize]
    [HttpPut]
    public IActionResult Put([FromBody]Associate associate)
    {
      this.repository.Update(associate);
      return Ok(associate);
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

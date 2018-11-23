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
  public class UsersController : Controller
  {
    private readonly IUserRepository repository;

    public UsersController(IUserRepository repository){
      this.repository = repository;
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
      return this.repository.GetAll();
    }

    [HttpGet("{id}")]
    public User Get(int id)
    {
      return this.repository.GetById(id);
    }

    [HttpPost]
    public IActionResult Post([FromBody]User user)
    {
      this.repository.Create(user);
      return Ok(user);
    }

    [HttpPut]
    public IActionResult Put([FromBody]User user)
    {
      this.repository.Update(user);
      return Ok(user);
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

    [HttpPost("authenticate")]
    public IActionResult Authentication([FromBody] User user)
    {
      var getUserAuth = this.repository.AuthUser(user);

      if(getUserAuth == null) {
        return BadRequest(new {
          message = "Login e/ou senha incorreto(s)."
        });
      }

      return Ok(new {
        token = BuildToken()
      });
    }

    public string BuildToken()
    {
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AssociatedProjectLPCCLASS"));
      var creed = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        audience: "Associated",
        issuer: "Associated",
        signingCredentials: creed
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}

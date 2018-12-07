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
  public class UsersController : Controller
  {
    private readonly IUserRepository repository;

    public UsersController(IUserRepository repository){
      this.repository = repository;
    }

    [Authorize]
    [HttpGet]
    public async Task<IEnumerable<UserDTO>> Get()
    {
      var users = await this.repository.GetAll();
      var usersDTO = new List<UserDTO>();

      users.ForEach(user => {
        usersDTO.Add(new UserDTO{ Id = user.Id, Name = user.Name });
      });

      return usersDTO;
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<User> Get(int id)
    {
      return await this.repository.GetById(id);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]User user)
    {
      await this.repository.Create(user);
      return Ok(user);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]User user)
    {
      await this.repository.Update(user);
      return Ok(user);
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

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authentication([FromBody] User user)
    {
      var getUserAuth = await this.repository.AuthUser(user);

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

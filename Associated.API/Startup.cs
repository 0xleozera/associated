using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Associated.Repositories;
using Associated.Repositories.Interfaces;
using Associated.Repositories.Data;

namespace Associated.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(i =>
        i.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = false,
          ValidateIssuerSigningKey = true,
          ValidAudience = "Associated",
          ValidIssuer = "Associated",
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AssociatedProjectLPCCLASS"))
        });

      services.AddMvc();
      services.AddDbContext<DataContext>(x => x.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

      services.AddMvc().AddJsonOptions(options =>
      {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      });

      services.AddScoped<IAssociateRepository, AssociateRepository>();
      services.AddScoped<IDependentRepository, DependentRepository>();
      services.AddScoped<IMaritalStatusRepository, MaritalStatusRepository>();
      services.AddScoped<IKinshipRepository, KinshipRepository>();
      services.AddScoped<IUserRepository, UserRepository>();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseAuthentication();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();
    }
  }
}

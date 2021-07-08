using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using restWebApiBooks.src.modules.book.infra.entityFrameworkCore.repositories;
using restWebApiBooks.src.modules.book.infra.repositories;
using restWebApiBooks.src.modules.person;
using restWebApiBooks.src.modules.person.infra.entityFrameworkCore.repositories;
using restWebApiBooks.src.modules.shared.infra.entityFrameworkCore.context;
using restWebApiBooks.src.modules.shared.infra.entityFrameworkCore.repositories;
using restWebApiBooks.src.modules.shared.repositories;
using Serilog;

namespace restWebApiBooks
{
  public class Startup
  {
    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Environment { get; }// config migrations
    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
      Configuration = configuration;
      Environment = environment;// config migrations

      Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();// config Logger
    }


    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      var connection = Configuration["MSSQLConnection:MSSQLConnectionString"];
      services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connection));

      if (Environment.IsDevelopment())
      {
        MigrateDatabase(connection);
      }

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "restWebApiBooks", Version = "v1" });
      });
      services.AddApiVersioning();
      services.AddScoped<IPersonRepository, PersonRepository>();
      services.AddScoped<IBookRepository, BookRepository>();

      services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "restWebApiBooks v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }

    private void MigrateDatabase(string connection)
    {
      try
      {
          var evolveConnection = new SqlConnection(connection);
          var evolve = new Evolve.Evolve(evolveConnection,msg => Log.Information(msg)){
            Locations = new List<string> {"src/dataBase/migrations","src/dataBase/seeders"},
            IsEraseDisabled = true,
          };
          evolve.Migrate();
      }
      catch (Exception ex)
      {
          Log.Error("Database Migration failed", ex);
          throw;
      }
    }
  }
}
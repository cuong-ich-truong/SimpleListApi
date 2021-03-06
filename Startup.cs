using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleListApi.Contexts;
using SimpleListApi.Services.CategoryService;
using SimpleListApi.Services.LineItemService;

namespace SimpleListApi
{
  public class Startup
  {
    readonly string AllowedOrigins = "AllowedOrigins";

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<SimpleListContext>(opt =>
        opt.UseSqlite("Filename=./db/SimpleList.db")
      );

      services.AddCors(options =>
      {
        options.AddPolicy(name: AllowedOrigins,
          builder =>
          {
            builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
          });
      });
      services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );;

      services.AddAutoMapper(typeof(Startup));
      services.AddScoped<ICategoryService, CategoryService>();
      services.AddScoped<ILineItemService, LineItemService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      if (env.IsDevelopment())
      {
        // Allow localhost in development
        app.UseCors(AllowedOrigins);
      }

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
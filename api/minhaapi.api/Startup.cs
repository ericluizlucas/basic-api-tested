using Microsoft.AspNetCore.Mvc.Formatters;
using minhaapi.Service;
using minhaapi.Services;

namespace minhaapi
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
      services.RegisterServiceIoC(Configuration);
      services.RegisterAutomapper(Configuration);
      
      services.AddControllers(options =>
      {
        options.OutputFormatters.RemoveType<TextOutputFormatter>();
        options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

    //   app.UseSwagger();
    //   app.UseSwaggerUI(c =>
    //   {
    //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Versão 1.0");
    //   });

     // app.UseHttpsRedirection();

      app.UseRouting();

      // app.Use(async (context, next) =>
      // {
      //     // Do work that doesn't write to the Response.
      //     await next.Invoke();
      //     // Do logging or other work that doesn't write to the Response.
      // });

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
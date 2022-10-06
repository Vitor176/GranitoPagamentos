using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;


namespace GranitoPagamento.APITaxas
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1",
						new Microsoft.OpenApi.Models.OpenApiInfo
						{
							Title = "GranitoPagamento",
							Version = "V1",
							Contact = new Microsoft.OpenApi.Models.OpenApiContact
							{
								Url = new System.Uri("https://www.linkedin.com/in/vitorgabrieloliveira-dev/"),
								Email = "mailto:vitor.gabriel.oliveira2002@gmail.com",
								Name = "Vitor Gabriel de Oliveira Andrade"
							}
						});
			});
			services.AddControllers();
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

			app.UseAuthorization();

			//Regions para injeção de dependência

			#region Inicializa Swagger

			app.UseSwagger();

			app.UseSwaggerUI(opt =>
			{
				opt.SwaggerEndpoint("/swagger/v1/swagger.json", "TaxasAPI V1");
			});

			#endregion

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

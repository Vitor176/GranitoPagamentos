using GranitoPagamento.Business;
using GranitoPagamento.Business.Interfaces;
using GranitoPagamento.Proxy;
using GranitoPagamento.Proxy.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

namespace GranitoPagamento.APICalculo
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

			#region Documentacao Swagger
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

			#endregion


			//Regions para injeção de dependência
			#region Proxy

			services.AddSingleton<ITaxaJurosProxy, TaxaJurosProxy>();

			#endregion

			#region Business

			services.AddSingleton<IJurosCompostoBusiness, JurosCompostoBusiness>();

			#endregion

			#region Network

			services.AddHttpClient();

			services.AddHttpClient("API_Taxa_Juros").ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
			{
				ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }

			});

			#endregion
			//

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();


			//Sessão resposável pela inicialização do Swagger
			#region Inicializa Swagger

			//Inicilizamos o Swagger
			app.UseSwagger();

			//Colocamos o Endpoint principal para a seguinte URL com o Nome da API
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

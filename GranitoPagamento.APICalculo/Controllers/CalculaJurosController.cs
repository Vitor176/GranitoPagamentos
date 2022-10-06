using GranitoPagamento.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GranitoPagamento.APICalculo.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CalculaJurosController : Controller
	{

		private readonly ILogger<CalculaJurosController> _logger;
		private readonly IJurosCompostoBusiness _JurosCompostoBusiness;

		public CalculaJurosController(ILogger<CalculaJurosController> logger, IJurosCompostoBusiness JurosCompostoBusiness)
		{
			_logger = logger;
			_JurosCompostoBusiness = JurosCompostoBusiness;
		}

		//Rota para retornar o valor dos juros compostos.
		[HttpGet]
		public async Task<IActionResult> Get(decimal valorinicial, int meses)
		{
			//Caso o Método retorne o valor do juros, a api segue e retorna um código 200 (Okay) 
			try
			{
				var result = await _JurosCompostoBusiness.RetornarJurosComposto(valorinicial, meses);
				return Ok(result);
			}
			catch (System.Exception e)
			{
				//Se não Armazenamos em log o Erro e a Mensagem e Retornamos um 500 Com a Mensagem de que Ocorreu um erro
				_logger.Log(LogLevel.Error, e.Message, e);
				return BadRequest("Ocorreu um erro!");
			}
		}

		//Action Responsável pela parte de ShowMeTheCode onde irá retorna apenas um Ok com a url de onde o está o reposítório
		[HttpGet("showmethecode")]
		public async Task<IActionResult> Get()
		{
			return Ok("https://github.com/Vitor176?tab=repositories");
		}
	}
}

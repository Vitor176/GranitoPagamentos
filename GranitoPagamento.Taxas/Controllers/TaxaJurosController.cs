using GranitoPagamento.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace GranitoPagamento.APITaxas.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TaxaJurosController : Controller
	{
		private readonly ILogger<TaxaJurosController> _logger;

		public TaxaJurosController(ILogger<TaxaJurosController> logger)
		{
			_logger = logger;
		}

		//Action criada para retornar o Valor do Juros, tanto em decimal quanto em percentual.
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(new TaxDTO { PercentValue = 1, DecimalValue = 0.01});
		}
	}
}

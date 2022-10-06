using GranitoPagamento.APICalculo.Controllers;
using GranitoPagamento.Business;
using GranitoPagamento.Business.Interfaces;
using GranitoPagamento.Proxy.Interfaces;
using Moq;
using System;
using Xunit;

namespace GranitoPagamento.Test
{
	public class UnitTest1
	{
		//Classe para Teste de Cálculos 
		[Fact]
		public void Calculo_OK()
		{
			var mockProxy = new Mock<ITaxaJurosProxy>();

			//MockProxy 
			mockProxy.Setup(_ => _.RetornarTaxaJuros()).ReturnsAsync(new DTO.TaxDTO { PercentValue = 1, DecimalValue = 0.01 });
			//MockBusiness
			var business = new JurosCompostoBusiness(mockProxy.Object);
			//Chamada da Business com parametros mocados
			var result = business.RetornarJurosComposto(100, 5).Result;
			//Se o Resultado for igual ao esperado, então nosso teste passou
			Assert.Equal(result, "105,10");

		}

		[Fact]
		public void Calculo_Error()
		{
			
			var mockProxy = new Mock<ITaxaJurosProxy>();

			//MockProxy com chamada de objeto fixo
			mockProxy.Setup(_ => _.RetornarTaxaJuros()).ReturnsAsync(new DTO.TaxDTO { PercentValue = 1, DecimalValue = 0.01 });
			//MockBusiness
			var business = new JurosCompostoBusiness(mockProxy.Object);
			var result = business.RetornarJurosComposto(100, 5).Result;
			//Esperamos que o teste retorne false
			Assert.False(result == "104,10");

		}
	}
}

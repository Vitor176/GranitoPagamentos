using GranitoPagamento.Business.Interfaces;
using GranitoPagamento.DTO;
using GranitoPagamento.Proxy.Interfaces;
using System;
using System.Threading.Tasks;

namespace GranitoPagamento.Business
{
	/// <summary>
	/// Centralizamos toda regra de negócio/calculo nesta classe, utilizando o conceito de responsabilidade 
	/// </summary>
	public class JurosCompostoBusiness : IJurosCompostoBusiness
	{
		private ITaxaJurosProxy _proxy;

		public JurosCompostoBusiness(ITaxaJurosProxy proxy)
		{
			_proxy = proxy;
		}

		//Retornando apenas o valor dos juros, retornando com 2 casas decimais após a vírgula
		public async Task<string> RetornarJurosComposto(decimal valorInicial, int meses)
		{
			var taxaJuros = await RetornarTaxaJuros();
			return CalcularJurosCompostos(valorInicial, meses, taxaJuros.DecimalValue).ToString("N2");
		}

		#region Métodos Privados

		/* Chamada da proxy para resgatar o valor do Juros Composto*/
		private async Task<TaxDTO> RetornarTaxaJuros()
		{
			return await _proxy.RetornarTaxaJuros();
		}

		/// Calculos centralizado neste método
		private double CalcularJurosCompostos(decimal valorInicial, int meses, double taxaJurosPercentual)
		{
			//Cálculo Utilizado : Valor Inicial * (1 + juros) ^ Tempo
			return Math.Round(((double)valorInicial * Math.Pow((1 + taxaJurosPercentual), meses)), 3);
		}

		#endregion
	}
}

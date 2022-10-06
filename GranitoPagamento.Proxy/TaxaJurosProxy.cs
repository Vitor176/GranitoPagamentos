using GranitoPagamento.DTO;
using GranitoPagamento.Proxy.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GranitoPagamento.Proxy
{
	public class TaxaJurosProxy : ITaxaJurosProxy
	{
		private readonly IHttpClientFactory _clientFactory;

		public TaxaJurosProxy(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
		}

		/*Método Criado para Retornar a Taxa de Juros, primeiro instanciamos o Objeto, logo após Criamos então o Cliente, que no caso seria a Api da taxa de juros */
		public async Task<TaxDTO> RetornarTaxaJuros()
		{
			var tax = new TaxDTO();

			var client = _clientFactory.CreateClient("API_Taxa_Juros");

			//Fazemos uma requisição na Api e validamos se a mesma está retornando sucesso, se estiver retornando valores, então pegamos o Content,
			//que irá ter armazenado o valor da Taxa de Juros e então convertemos o valor para um DTO.*/
			var responseMessage = await client.GetAsync("http://localhost:5262/TaxaJuros");
			if (responseMessage.IsSuccessStatusCode)
			{
				var content = await responseMessage.Content.ReadAsStringAsync();
				tax = JsonConvert.DeserializeObject<TaxDTO>(content);
			}

			return tax;
		}
	}
}

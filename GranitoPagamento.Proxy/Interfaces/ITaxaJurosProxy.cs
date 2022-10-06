using GranitoPagamento.DTO;
using System.Threading.Tasks;

namespace GranitoPagamento.Proxy.Interfaces
{
	public interface ITaxaJurosProxy
	{
		//Task para Retornar a Taxa de Juros
		Task<TaxDTO> RetornarTaxaJuros();
	}
}

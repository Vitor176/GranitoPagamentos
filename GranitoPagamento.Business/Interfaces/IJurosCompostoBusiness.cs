using System.Threading.Tasks;

namespace GranitoPagamento.Business.Interfaces
{
	public interface IJurosCompostoBusiness
	{
		Task<string> RetornarJurosComposto(decimal valorInicial, int meses);
	}
}

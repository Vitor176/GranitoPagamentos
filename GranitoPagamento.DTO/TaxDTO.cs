using Newtonsoft.Json;
using System;

namespace GranitoPagamento.DTO
{
	/// <summary>
	/// Objeto DTO para ser utilizado no projeto inteiro
	/// </summary>
	public class TaxDTO
	{
		/// <summary>
		/// 1%
		/// </summary>
		[JsonProperty("PercentValue")]
		public int PercentValue { get; set; }
		/// <summary>
		/// 0,01
		/// </summary>
		[JsonProperty("DecimalValue")]
		public double DecimalValue { get; set; }
	}
}

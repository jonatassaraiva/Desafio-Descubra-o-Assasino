using System;
using System.Collections.Generic;

namespace Desafio.DescubraAssassino.Domain
{
	/// <summary>
	/// Contrato de acesso a dados.
	/// </summary>
	public interface IDataContext
	{
		IEnumerable<string> Guns { get; }
		IEnumerable<string> Locals { get; }
		IEnumerable<Response> Responses { get; }
		IEnumerable<string> Suspects { get; }
	}
}

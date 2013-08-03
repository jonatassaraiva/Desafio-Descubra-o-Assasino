using Desafio.DescubraAssasino.Domain;
using System;
using System.Collections.Generic;

namespace Desafio.DescubraAssasino.Domain
{
	public interface IDataContext
	{
		IEnumerable<string> Guns { get; }
		IEnumerable<string> Locals { get; }
		IEnumerable<Response> Responses { get; }
		IEnumerable<string> Suspects { get; }
	}
}

using System;
using System.Collections.Generic;
namespace Desafio.DescubraAssasino.Infrastructure
{
	public interface IDataContext
	{
		IEnumerable<string> Guns { get; }
		IEnumerable<string> Locals { get; }
		IEnumerable<string> Suspects { get; }
	}
}

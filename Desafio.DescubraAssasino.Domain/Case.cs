using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.DescubraAssassino.Domain
{
	/// <summary>
	/// Representa um Caso.
	/// </summary>
	public class Case
	{
		public string Title { get; set; }
		
		public IEnumerable<string> Suspects { get; set; }

		public IEnumerable<string> Locals { get; set; }

		public IEnumerable<string> Guns { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.DescubraAssassino.Domain
{
	/// <summary>
	/// Representa uma Teoria com informações do Suspeito, Arama e Local.
	/// </summary>
	public class Theory
	{
		public string Suspect { get; set; }
		public string Gun { get; set; }
		public string Local { get; set; }
	}
}

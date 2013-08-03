using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.DescubraAssasino.Domain
{
	/// <summary>
	/// Representa um Detetive.
	/// </summary>
	public class Detective
	{
		public Detective(string name)
		{
			this.Name = name;
		}

		private InterrogationService interrogationService;

		public string Name { get; private set; }

		public Response SolveCase(Case caseToResulve, Witness witness)
		{
			this.interrogationService = new InterrogationService(witness, caseToResulve);

			return this.interrogationService.Start();
		}
	}
}

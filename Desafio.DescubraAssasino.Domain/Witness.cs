using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.DescubraAssasino.Domain
{
	public class Witness
	{
		public Witness (IDataContext dataConstext)
		{
			Random random = new Random();
			int index = random.Next(0, dataConstext.Responses.Count());
			this.response = dataConstext.Responses.ToList()[index];
		}

		private Response response;

		public ResponseType Reply(Theory theory)
		{
			if (!string.Equals(response.Suspect, theory.Suspect))
				return ResponseType.Suspect;
			else if (!string.Equals(response.Local, theory.Local))
				return ResponseType.Local;
			else if (!string.Equals(response.Gun, theory.Gun))
				return ResponseType.Gun;

			return ResponseType.Right;
		}
		
	}
}

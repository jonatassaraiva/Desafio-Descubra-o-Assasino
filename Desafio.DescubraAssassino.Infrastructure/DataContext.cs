using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Desafio.DescubraAssassino.Domain;

namespace Desafio.DescubraAssassino.Domain
{
	/// <summary>
	/// Implementação do IDataContext. Acessa dados de um Json
	/// </summary>
	public class DataContext : IDataContext
	{
		private JToken jsonToken;

		public DataContext(string localDataSource)
		{
			string jsonRead = File.ReadAllText(localDataSource);

			jsonToken = JObject.Parse(jsonRead);
		}

		public IEnumerable<string> Suspects
		{
			get
			{
				return this.jsonToken.SelectToken("suspects").Values<string>();
			}
		}

		public IEnumerable<string> Locals
		{
			get
			{
				return this.jsonToken.SelectToken("locals").Values<string>();
			}
		}

		public IEnumerable<string> Guns
		{
			get
			{
				return this.jsonToken.SelectToken("guns").Values<string>();
			}
		}

		public IEnumerable<Response> Responses
		{
			get
			{
				var jsonTokenResponses = this.jsonToken.SelectToken("responses").Children();
				ICollection<Response> responses = new List<Response>();
				foreach (var item in jsonTokenResponses)
				{
					var response = JsonConvert.DeserializeObject<Response>(item.ToString());
					responses.Add(response);
				}
				return responses;
			}
		}
	}
}

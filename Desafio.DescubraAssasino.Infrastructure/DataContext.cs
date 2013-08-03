using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Desafio.DescubraAssasino.Infrastructure
{
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
	}
}

using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.DescubraAssasino.Domain.Tests
{
	public static class HelpMock
	{
		public static Case MockCase()
		{
			Mock<IDataContext> mockContext = MockContext();

			Case casoMock = new Case()
			{
				Title = "Teste",
				Guns = mockContext.Object.Guns,
				Locals = mockContext.Object.Locals,
				Suspects = mockContext.Object.Suspects,
			};

			return casoMock;
		}

		private static Mock<IDataContext> MockContext()
		{
			Mock<IDataContext> mockContext = new Mock<IDataContext>();

			mockContext.Setup(m => m.Locals).Returns(new List<string>() { 
				"Local 1", "Local 2", "Local 3", "Local 4", "Local 5", "Local 6",
			});
			mockContext.Setup(m => m.Guns).Returns(new List<string>() { 
				"Arma 1", "Arma 2", "Arma 3", "Arma 4"
			});
			mockContext.Setup(m => m.Suspects).Returns(new List<string>() { 
				"Suspeito 1", "Suspeito 2", "Suspeito 3", "Suspeito 4", "Suspeito 5", "Suspeito 6", "Suspeito 7" 
			});

			mockContext.Setup(m => m.Responses).Returns(new List<Response>() { 
				ResposataUm(),
				ResposataDois()
			});

			return mockContext;
		}

		public static Response ResposataDois()
		{
			return new Response()
			{
				Gun = "Arma 2",
				Local = "Local 3",
				Suspect = "Suspeito 4"
			};
		}

		public static Response ResposataUm()
		{
			return new Response()
			{
				Gun = "Arma 4",
				Local = "Local 6",
				Suspect = "Suspeito 6"
			};
		}


		public static Witness MockWitnessWithResponse(int index)
		{
			Response resposta = MockContext().Object.Responses.ToList()[index];

			return new Witness(resposta);
		}
	}
}

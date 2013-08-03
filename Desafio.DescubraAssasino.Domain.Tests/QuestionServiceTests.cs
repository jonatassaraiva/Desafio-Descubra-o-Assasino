using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.DescubraAssasino.Domain.Tests
{
	[TestClass]
	public class QuestionServiceTests
	{
		Mock<IDataContext> mockContext;

		public QuestionServiceTests()
		{
			this.mockContext = new Mock<IDataContext>();

			this.mockContext.Setup(m => m.Locals).Returns(new List<string>() { 
				"Local 1", "Local 2", "Local 3", "Local 4", "Local 5", "Local 6",
			});
			this.mockContext.Setup(m => m.Guns).Returns(new List<string>() { 
				"Arma 1", "Arma 2", "Arma 3", "Arma 4"
			});
			this.mockContext.Setup(m => m.Suspects).Returns(new List<string>() { 
				"Suspeito 1", "Suspeito 2", "Suspeito 3", "Suspeito 4", "Suspeito 5", "Suspeito 6", "Suspeito 7" 
			});
		}

		[TestMethod]
		public void Obter_Resposta_Arma_2_Local_3_Suspeito_4()
		{
			// Arrange
			Response teoriaEsperada = new Response()
			{
				Gun = "Arma 2",
				Local = "Local 3",
				Suspect = "Suspeito 4"
			};
			this.mockContext.Setup(m => m.Responses).Returns(new List<Response>() { 
				teoriaEsperada
			});

			// Act
			InterrogationService questionService = new InterrogationService();
			Response teoriaCorreta = questionService.Start(mockContext.Object);

			// Assert
			Assert.AreEqual<string>(teoriaEsperada.Suspect, teoriaCorreta.Suspect);
			Assert.AreEqual<string>(teoriaEsperada.Local, teoriaCorreta.Local);
			Assert.AreEqual<string>(teoriaEsperada.Gun, teoriaCorreta.Gun);
		}


		[TestMethod]
		public void Obter_Resposta_Arma_4_Local_6_Suspeito_6()
		{
			// Arrange
			Response teoriaEsperada = new Response()
			{
				Gun = "Arma 4",
				Local = "Local 6",
				Suspect = "Suspeito 6"
			};
			this.mockContext.Setup(m => m.Responses).Returns(new List<Response>() { 
				teoriaEsperada
			});

			// Act
			InterrogationService questionService = new InterrogationService();
			Response teoriaCorreta = questionService.Start(mockContext.Object);

			// Assert
			Assert.AreEqual<string>(teoriaEsperada.Suspect, teoriaCorreta.Suspect);
			Assert.AreEqual<string>(teoriaEsperada.Local, teoriaCorreta.Local);
			Assert.AreEqual<string>(teoriaEsperada.Gun, teoriaCorreta.Gun);
		}
	}
}

using Desafio.DescubraAssassino.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.DescubraAssassino.Domain.Tests
{
	[TestClass]
	public class InterrogationServiceTests
	{
		private Case caso;

		private Mock<IDataContext> mockContext;

		public InterrogationServiceTests()
		{
			this.mockContext = new Mock<IDataContext>();
			this.caso = HelpMock.MockCase();
		}

		[TestMethod]
		public void Obter_Resposta_Arma_2_Local_3_Suspeito_4()
		{
			// Arrange
			Response respostaEsperada = new Response()
			{
				Gun = "Arma 2",
				Local = "Local 3",
				Suspect = "Suspeito 4"
			};


			Witness testemunha = new Witness(respostaEsperada);

			// Act
			InterrogationService servicoDeInterrogacao = new InterrogationService(testemunha, this.caso);
			Response respostaRetornada = servicoDeInterrogacao.Start();

			// Assert
			Assert.AreEqual<string>(respostaEsperada.Suspect, respostaRetornada.Suspect);
			Assert.AreEqual<string>(respostaEsperada.Local, respostaRetornada.Local);
			Assert.AreEqual<string>(respostaEsperada.Gun, respostaRetornada.Gun);
		}

		[TestMethod]
		public void Obter_Resposta_Arma_4_Local_6_Suspeito_6()
		{
			// Arrange
			Response respostaEsperada = new Response()
			{
				Gun = "Arma 4",
				Local = "Local 6",
				Suspect = "Suspeito 6"
			};
			
			Witness testemunha = new Witness(respostaEsperada);

			// Act
			InterrogationService servicoDeInterrogacao = new InterrogationService(testemunha, this.caso);
			Response respostaRetornada = servicoDeInterrogacao.Start();

			// Assert
			Assert.AreEqual<string>(respostaEsperada.Suspect, respostaRetornada.Suspect);
			Assert.AreEqual<string>(respostaEsperada.Local, respostaRetornada.Local);
			Assert.AreEqual<string>(respostaEsperada.Gun, respostaRetornada.Gun);
		}
	}
}

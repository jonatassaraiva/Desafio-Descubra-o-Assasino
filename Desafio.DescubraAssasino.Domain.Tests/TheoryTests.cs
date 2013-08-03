using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Desafio.DescubraAssasino.Domain;
using Moq;
using System.Collections.Generic;
using System.Threading;

namespace Desafio.DescubraAssasino.Domain.Tests
{
	[TestClass]
	public class TheoryTests
	{
		Mock<IDataContext> mockContext;

		public TheoryTests()
		{
			this.mockContext = new Mock<IDataContext>();
			this.mockContext.Setup(m => m.Locals).Returns(new List<string>() { "Local 1", "Local 2", "Local 3" });
			this.mockContext.Setup(m => m.Guns).Returns(new List<string>() { "Arma 1", "Arma 2" });
			this.mockContext.Setup(m => m.Suspects).Returns(new List<string>() { "Suspeito 1", "Suspeito 2", "Suspeito 3", "Suspeito 4" });
		}

		[TestMethod]
		public void ProximaTeoria_Local()
		{
			TheoryService theoryService = new TheoryService(mockContext.Object);

			// Rodada 1
			var antesDaProximaTeoria = theoryService.NextTheory(false, false, false);

			// Rodada 2
			var proximaTeoria = theoryService.NextTheory(false, false, false);
			Assert.AreNotEqual<string>(antesDaProximaTeoria.Local, proximaTeoria.Local);

			antesDaProximaTeoria = proximaTeoria;
			proximaTeoria = theoryService.NextTheory(false, true, false);

			Assert.AreEqual<string>(antesDaProximaTeoria.Local, proximaTeoria.Local);
		}

		[TestMethod]
		public void ProximaTeoria_Arma()
		{
			TheoryService theoryService = new TheoryService(mockContext.Object);

			// Rodada 1
			var antesDaProximaTeoria = theoryService.NextTheory(false, false, false);

			// Rodada 2
			var proximaTeoria = theoryService.NextTheory(false, false, false);
			Assert.AreNotEqual<string>(antesDaProximaTeoria.Gun, proximaTeoria.Gun);

			antesDaProximaTeoria = proximaTeoria;
			proximaTeoria = theoryService.NextTheory(false, false, true);

			Assert.AreEqual<string>(antesDaProximaTeoria.Gun, proximaTeoria.Gun);
		}

		[TestMethod]
		public void ProximaTeoria_Suspect()
		{
			TheoryService theoryService = new TheoryService(mockContext.Object);

			var antesDaProximaTeoria = theoryService.NextTheory(false, false, false);

			var proximaTeoria = theoryService.NextTheory(false, false, false);
			Assert.AreNotEqual<string>(antesDaProximaTeoria.Suspect, proximaTeoria.Suspect);

			antesDaProximaTeoria = proximaTeoria;
			proximaTeoria = theoryService.NextTheory(true, false, false);

			Assert.AreEqual<string>(antesDaProximaTeoria.Suspect, proximaTeoria.Suspect);
		}

		[TestMethod]
		public void Local_1_Arma_2_Suspeito_4_5_Tentativas()
		{
			TheoryService theoryService = new TheoryService(mockContext.Object);

			// Rodada 1
			var teoria = theoryService.NextTheory(false, true, false);
			// Acertou o local
			Assert.AreEqual<string>(teoria.Local, "Local 1");

			// Rodada 2
			teoria = theoryService.NextTheory(false, true, false);
			// Acertou a arma
			Assert.AreEqual<string>(teoria.Gun, "Arma 2");

			// Rodada 3
			teoria = theoryService.NextTheory(false, true, true);
			// Continua coma local e arma
			Assert.AreEqual<string>(teoria.Local, "Local 1");
			Assert.AreEqual<string>(teoria.Gun, "Arma 2");

			// Rodada 4
			teoria = theoryService.NextTheory(false, true, true);

			// Descobrio o assasino
			Assert.AreEqual<string>(teoria.Local, "Local 1");
			Assert.AreEqual<string>(teoria.Gun, "Arma 2");
			Assert.AreEqual<string>(teoria.Suspect, "Suspeito 4");
		}
	}
}

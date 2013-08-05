using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Desafio.DescubraAssassino.Domain;
using Moq;
using System.Collections.Generic;
using System.Threading;

namespace Desafio.DescubraAssassino.Domain.Tests
{
	[TestClass]
	public class TheoryTests
	{
		private Mock<IDataContext> mockContext;
		private Case caso;
		private TheoryService servicoDeTeoria;



		public TheoryTests()
		{
			this.mockContext = new Mock<IDataContext>();
			this.mockContext.Setup(m => m.Locals).Returns(new List<string>() { "Local 1", "Local 2", "Local 3" });
			this.mockContext.Setup(m => m.Guns).Returns(new List<string>() { "Arma 1", "Arma 2" });
			this.mockContext.Setup(m => m.Suspects).Returns(new List<string>() { "Suspeito 1", "Suspeito 2", "Suspeito 3", "Suspeito 4" });

			this.caso = new Case()
			{
				Title = "Teste",
				Guns = mockContext.Object.Guns,
				Locals = mockContext.Object.Locals,
				Suspects = mockContext.Object.Suspects,
			};

			this.servicoDeTeoria = new TheoryService(this.caso);

		}

		[TestMethod]
		public void ProximaTeoria_Local()
		{
			// Rodada 1
			var antesDaProximaTeoria = this.servicoDeTeoria.NextTheory(false, false, false);

			// Rodada 2
			var proximaTeoria = servicoDeTeoria.NextTheory(false, false, false);
			Assert.AreNotEqual<string>(antesDaProximaTeoria.Local, proximaTeoria.Local);

			antesDaProximaTeoria = proximaTeoria;
			proximaTeoria = servicoDeTeoria.NextTheory(false, true, false);

			Assert.AreEqual<string>(antesDaProximaTeoria.Local, proximaTeoria.Local);
		}

		[TestMethod]
		public void ProximaTeoria_Arma()
		{
			// Rodada 1
			var antesDaProximaTeoria = this.servicoDeTeoria.NextTheory(false, false, false);

			// Rodada 2
			var proximaTeoria = this.servicoDeTeoria.NextTheory(false, false, false);
			Assert.AreNotEqual<string>(antesDaProximaTeoria.Gun, proximaTeoria.Gun);

			antesDaProximaTeoria = proximaTeoria;
			proximaTeoria = this.servicoDeTeoria.NextTheory(false, false, true);

			Assert.AreEqual<string>(antesDaProximaTeoria.Gun, proximaTeoria.Gun);
		}

		[TestMethod]
		public void ProximaTeoria_Suspect()
		{
			var antesDaProximaTeoria = this.servicoDeTeoria.NextTheory(false, false, false);

			var proximaTeoria = this.servicoDeTeoria.NextTheory(false, false, false);
			Assert.AreNotEqual<string>(antesDaProximaTeoria.Suspect, proximaTeoria.Suspect);

			antesDaProximaTeoria = proximaTeoria;
			proximaTeoria = this.servicoDeTeoria.NextTheory(true, false, false);

			Assert.AreEqual<string>(antesDaProximaTeoria.Suspect, proximaTeoria.Suspect);
		}

		[TestMethod]
		public void Local_1_Arma_2_Suspeito_4_5_Tentativas()
		{
			// Rodada 1
			var teoria = this.servicoDeTeoria.NextTheory(false, true, false);
			// Acertou o local
			Assert.AreEqual<string>(teoria.Local, "Local 1");

			// Rodada 2
			teoria = this.servicoDeTeoria.NextTheory(false, true, false);
			// Acertou a arma
			Assert.AreEqual<string>(teoria.Gun, "Arma 2");

			// Rodada 3
			teoria = this.servicoDeTeoria.NextTheory(false, true, true);
			// Continua coma local e arma
			Assert.AreEqual<string>(teoria.Local, "Local 1");
			Assert.AreEqual<string>(teoria.Gun, "Arma 2");

			// Rodada 4
			teoria = this.servicoDeTeoria.NextTheory(false, true, true);

			// Descobrio o assasino
			Assert.AreEqual<string>(teoria.Local, "Local 1");
			Assert.AreEqual<string>(teoria.Gun, "Arma 2");
			Assert.AreEqual<string>(teoria.Suspect, "Suspeito 4");
		}
	}
}

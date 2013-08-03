using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Desafio.DescubraAssasino.Domain.Tests
{
	[TestClass]
	public class DetectiveTests
	{
		[TestMethod]
		public void Resolver_Caso_Resposata_Um()
		{
			Detective detetive = new Detective("Detetive de Teste");

			Case casoParaResolver = HelpMock.MockCase();
			Witness testemunha =  HelpMock.MockWitnessWithResponse(0);

			Response respostaDoCaso = detetive.SolveCase(casoParaResolver, testemunha);
			Response respostaEsperada = HelpMock.ResposataUm();

			this.VerificaResposta(respostaDoCaso, respostaEsperada);
		}

		private void VerificaResposta(Response respostaDoCaso, Response respostaEsperada)
		{
			Assert.AreEqual<string>(respostaEsperada.Suspect, respostaDoCaso.Suspect);
			Assert.AreEqual<string>(respostaEsperada.Local, respostaDoCaso.Local);
			Assert.AreEqual<string>(respostaEsperada.Gun, respostaDoCaso.Gun);
		}

		[TestMethod]
		public void Resolver_Caso_Resposata_Dois()
		{
			Detective detetive = new Detective("Detetive de Teste");

			Case casoParaResolver = HelpMock.MockCase();
			Witness testemunha = HelpMock.MockWitnessWithResponse(1);

			Response respostaDoCaso = detetive.SolveCase(casoParaResolver, testemunha);
			Response respostaEsperada = HelpMock.ResposataDois();

			this.VerificaResposta(respostaDoCaso, respostaEsperada);
		}
	}
}

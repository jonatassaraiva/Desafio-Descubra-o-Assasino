using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Desafio.DescubraAssasino.Domain;
using System.Reflection;

namespace Desafio.DescubraAssasino.Domain.Tests
{
	[TestClass]
	public class CarregaDadosTests
	{
		private Case caseInvestigation;

		private DataContext context;

		// Arrange
		public CarregaDadosTests()
		{

			DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

			string localFiles = directoryInfo.Parent.Parent.FullName + "\\App_Data\\data.json";

			this.context = new DataContext(localFiles);
			this.caseInvestigation = new Case();
			this.caseInvestigation.Title = "O empresário Bill G.";
		}

		[TestMethod]
		public void Carregar_Suspeitos()
		{
			// Atc
			this.caseInvestigation.Suspects = this.context.Suspects;

			// Assert
			Assert.IsNotNull(this.caseInvestigation.Suspects);
			Assert.IsTrue(this.caseInvestigation.Suspects.Count() == 6);
		}

		[TestMethod]
		public void Carregar_Locais()
		{
			// Act
			this.caseInvestigation.Locals = this.context.Locals;

			// Assert
			Assert.IsNotNull(this.caseInvestigation.Locals);
			Assert.IsTrue(this.caseInvestigation.Locals.Count() == 10);
		}

		[TestMethod]
		public void Carregar_Armas()
		{
			// Act
			this.caseInvestigation.Guns = this.context.Guns;

			// Assert
			Assert.IsNotNull(this.caseInvestigation.Guns);
			Assert.IsTrue(this.caseInvestigation.Guns.Count() == 6);
		}
	}
}

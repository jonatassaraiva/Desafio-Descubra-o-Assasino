using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.DescubraAssasino.Domain
{
	/// <summary>
	/// Serviço de Teoria.
	/// </summary>
	public class TheoryService
	{
		private Case caseForMountTheory;
		private int indexSuspec;
		private int indexGun;
		private int indexLocal;

		private Theory currenteTheory;

		public TheoryService(Case caseForMountTheory)
		{
			this.caseForMountTheory = caseForMountTheory;
			this.indexGun = 0;
			this.indexLocal = 0;
			this.indexSuspec = 0;
		}

		public Theory NextTheory(bool suspectIs, bool localIs, bool gunIs)
		{
			Theory nextTheory = new Theory();

			if (this.currenteTheory == null)
			{
				this.NextLocalIs(nextTheory);
				this.NextGun(nextTheory);
				this.NextSuspect(nextTheory);
			}
			else
			{
				if (!localIs)
					this.NextLocalIs(nextTheory);
				else
					nextTheory.Local = this.currenteTheory.Local;

				if (!gunIs)
					this.NextGun(nextTheory);
				else
					nextTheory.Gun = this.currenteTheory.Gun;

				if (!suspectIs)
					this.NextSuspect(nextTheory);
				else
					nextTheory.Suspect = this.currenteTheory.Suspect;
			}

			this.currenteTheory = nextTheory;
			return this.currenteTheory;
		}

		private void NextSuspect(Theory nextTheory)
		{
			if (this.indexSuspec < this.caseForMountTheory.Suspects.Count())
			{
				nextTheory.Suspect = this.caseForMountTheory.Suspects.ToList()[this.indexSuspec];
				this.indexSuspec++;
			}
			else
			{
				nextTheory.Suspect = this.caseForMountTheory.Suspects.ToList()[0];
				this.indexSuspec = 0;
			}
		}

		private void NextGun(Theory nextTheory)
		{
			if (this.indexGun < this.caseForMountTheory.Guns.Count())
			{
				nextTheory.Gun = this.caseForMountTheory.Guns.ToList()[this.indexGun];
				this.indexGun++;
			}
			else
			{
				nextTheory.Gun = this.caseForMountTheory.Locals.ToList()[0];
				this.indexGun = 0;
			}
		}

		private void NextLocalIs(Theory nextTheory)
		{
			if (this.indexLocal < this.caseForMountTheory.Locals.Count())
			{
				nextTheory.Local = this.caseForMountTheory.Locals.ToList()[this.indexLocal];
				this.indexLocal++;
			}
			else
			{
				nextTheory.Local = this.caseForMountTheory.Locals.ToList()[0];
				this.indexLocal = 0;
			}
		}
	}
}

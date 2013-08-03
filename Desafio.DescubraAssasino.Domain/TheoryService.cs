using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.DescubraAssasino.Domain
{
	public class TheoryService
	{
		private IDataContext dataContext;
		private int indexSuspec;
		private int indexGun;
		private int indexLocal;

		private Theory currenteTheory;

		public TheoryService(IDataContext dataContext)
		{
			this.dataContext = dataContext;
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
			if (this.indexSuspec < this.dataContext.Suspects.Count())
			{
				nextTheory.Suspect = this.dataContext.Suspects.ToList()[this.indexSuspec];
				this.indexSuspec++;
			}
			else
			{
				nextTheory.Suspect = this.dataContext.Suspects.ToList()[0];
				this.indexSuspec = 0;
			}
		}

		private void NextGun(Theory nextTheory)
		{
			if (this.indexGun < this.dataContext.Guns.Count())
			{
				nextTheory.Gun = this.dataContext.Guns.ToList()[this.indexGun];
				this.indexGun++;
			}
			else
			{
				nextTheory.Gun = this.dataContext.Locals.ToList()[0];
				this.indexGun = 0;
			}
		}

		private void NextLocalIs(Theory nextTheory)
		{
			if (this.indexLocal < this.dataContext.Locals.Count())
			{
				nextTheory.Local = this.dataContext.Locals.ToList()[this.indexLocal];
				this.indexLocal++;
			}
			else
			{
				nextTheory.Local = this.dataContext.Locals.ToList()[0];
				this.indexLocal = 0;
			}
		}
	}
}

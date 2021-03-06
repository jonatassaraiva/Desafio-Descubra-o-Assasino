﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.DescubraAssassino.Domain
{
	/// <summary>
	/// Serviço de interrogatório.
	/// </summary>
	public class InterrogationService
	{
		private Witness witness;
		TheoryService theoryService;

		public InterrogationService(Witness witness, Case caseForInterrogation)
		{
			this.witness = witness;
			this.theoryService = new TheoryService(caseForInterrogation);
		}

		public Response Start()
		{
			Theory theory = this.theoryService.NextTheory(false, false, false);

			ResponseType responseType = witness.Reply(theory);

			while (responseType != ResponseType.Right)
			{
				if (responseType == ResponseType.Suspect)
					WhoSuspect(responseType, ResponseType.Suspect, this.theoryService, witness, theory);

				if (responseType == ResponseType.Local)
					WhoLocal(responseType, ResponseType.Local, this.theoryService, witness, theory);

				if (responseType == ResponseType.Gun)
					WhoGun(responseType, ResponseType.Gun, this.theoryService, witness, theory);

				responseType = witness.Reply(theory);
			}

			Response response = new Response()
			{
				Gun = theory.Gun,
				Local = theory.Local,
				Suspect = theory.Suspect,
			};

			return response;
		}

		private bool WhoGun(ResponseType response, ResponseType responseRigth, TheoryService theoryService, Witness witness, Theory theory)
		{
			if (response == responseRigth)
			{
				Theory newTheory = theoryService.NextTheory(true, true, false);

				ResponseType newResponse = witness.Reply(newTheory);

				if (WhoGun(newResponse, response, theoryService, witness, theory))
					theory.Gun = newTheory.Gun;

				return false;
			}

			return true;
		}

		private bool WhoLocal(ResponseType response, ResponseType responseRigth, TheoryService theoryService, Witness witness, Theory theory)
		{
			if (response == responseRigth)
			{
				Theory newTheory = theoryService.NextTheory(true, false, true);

				ResponseType newResponse = witness.Reply(newTheory);

				if (WhoLocal(newResponse, response, theoryService, witness, theory))
					theory.Local = newTheory.Local;

				return false;
			}

			return true;
		}

		public bool WhoSuspect(ResponseType response, ResponseType responseRigth, TheoryService theoryService, Witness witness, Theory theory)
		{
			if (response == responseRigth)
			{
				Theory newTheory = theoryService.NextTheory(false, true, true);

				ResponseType newResponse = witness.Reply(newTheory);

				if (WhoSuspect(newResponse, response, theoryService, witness, theory))
					theory.Suspect = newTheory.Suspect;

				return false;
			}

			return true;
		}
	}
}

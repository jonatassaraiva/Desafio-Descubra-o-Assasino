using Desafio.DescubraAssassino.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Desafio.DescubraAssassino.Web.Controllers
{
    public class InvestigacaoController : Controller
    {
		private IDataContext dataContext;

		public InvestigacaoController()
		{
			dataContext = new DataContext(Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"App_Data\data.json"));
		}


        //
        // GET: /Investigacao/
		[HttpGet]
        public ActionResult Index()
        {
			Case caseInvestigation = this.GetCase();

            return View(caseInvestigation);
        }

		private Case GetCase()
		{
			Case caseInvestigation = new Case()
			{
				Title = "O assasinato de Bill G",
				Guns = dataContext.Guns,
				Locals = dataContext.Locals,
				Suspects = dataContext.Suspects
			};

			return caseInvestigation;
		}

		[HttpGet]
		public ActionResult Investigar()
		{
			return View("_Investigar", this.dataContext.Responses);
		}

		[HttpPost]
		public ActionResult Investigar(int response)
		{
			Detective detective = new Detective("Lin Ust Orvalds");

			Witness witness = new Witness(this.dataContext.Responses.ToList()[response]);

			Case caseInvestigation = this.GetCase();

			Response resposeOfCase = detective.SolveCase(caseInvestigation, witness);

			return View("_RespotaInvestigacao", resposeOfCase);
		}
    }
}

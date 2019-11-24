using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyNails.Service.RendezVousServices;
using Microsoft.AspNetCore.Mvc;
using FairyNails.Service.PrestationServices;
using FairyNailsApp.Models.RendezVous;

namespace FairyNailsApp.Controllers
{
    public class RendezVousController : Controller
    {
        private readonly IRendezVousService _rendezVousService;
        private readonly IPrestationService _prestationService;

        public RendezVousController (IRendezVousService rendezVousService, IPrestationService prestationService)
        {
            this._rendezVousService = rendezVousService;
            this._prestationService = prestationService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Calendar");
        }

        public IActionResult Calendar()
        {

            RendezVousViewModel rendezVous = new RendezVousViewModel()
            {
                Prestations = _prestationService.GetAllPrestations<PrestationViewModel>(),
                DateCodeRendezVousTaken = _rendezVousService.GetTakenRendezVousTimeCode()
            };
   
            return View(rendezVous);
        }

        [HttpPost]
        public IActionResult SaveRendezVous(RendezVousViewModel rdvData)
        {
            List<Int32> prestationChosenId = new List<Int32>();
            foreach (var prestation in rdvData.Prestations)
            {
                if(prestation.IsChosen)
                {
                    prestationChosenId.Add(prestation.IdPrestation);
                }
            }

            _rendezVousService.AddRendezVous(rdvData.IdClient, prestationChosenId, rdvData.DateCode);
            return RedirectToAction("Calendar");
        }
    }
}
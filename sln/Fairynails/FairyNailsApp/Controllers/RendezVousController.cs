using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyNails.Service.RendezVousServices;
using Microsoft.AspNetCore.Mvc;
using FairyNails.Service.PrestationServices;
using FairyNailsApp.Models.RendezVous;
using FairyNailsApp.Models.Prestation;
using Microsoft.AspNetCore.Authorization;

namespace FairyNailsApp.Controllers
{
    [Authorize]
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

            CalendarViewModel model = new CalendarViewModel()
            {
                Prestations = _prestationService.GetAllPrestations<PrestationViewModel>(),
                UnavaibleTimeCode = _rendezVousService.GetUnavailableDateCode(DateTime.Now.Month),
                FirstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            };
   
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveRendezVous(CalendarViewModel rdvData)
        { 
            if(ModelState.IsValid)
            {
                List<Int32> prestationChosenId = new List<Int32>();
                foreach (var prestation in rdvData.Prestations)
                {
                    if(prestation.IsChosen)
                    {
                        prestationChosenId.Add(prestation.IdPrestation);
                    }
                }

                bool addStatus = _rendezVousService.AddRendezVous(rdvData.IdClient, prestationChosenId, rdvData.DateCode);

                if (addStatus == true)
                {
                    TempData["success"] = "Merci, je vous confirme notre rendez vous au plus vite !";
                }
                else
                {
                    TempData["alert"] = "Merci de choisir au moins une prestation";
                }
            }
            else
            {
                TempData["alert"] = "Erreur lors de la prise du rendez vous, veuillez reessayer";
            }
            return RedirectToAction("Calendar");
        }
    }
}
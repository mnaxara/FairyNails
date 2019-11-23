using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyNails.Service.RendezVousServices;
using Microsoft.AspNetCore.Mvc;
using FairyNails.Service.PrestationServices;
using FairyNailsApp.Models;

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
            CalendarViewModel model = new CalendarViewModel()
            {
                rendezVous = new RendezVousViewModel(),
                prestations = _prestationService.GetAllPrestations<PrestationViewModel>()
            };

            return View(model);
        }
    }
}
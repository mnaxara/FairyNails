using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyNails.Service.PrestationServices;
using FairyNails.Service.RendezVousServices;
using FairyNailsApp.Models.RendezVous;
using Microsoft.AspNetCore.Mvc;

namespace FairyNailsApp.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IRendezVousService _rendezVousService;

        public AjaxController(IRendezVousService rendezVousService, IPrestationService prestationService)
        {
            this._rendezVousService = rendezVousService;
        }

        [HttpPost]
        public IActionResult ChangeMonth(Int32 month, Int32 year)
        {
            CalendarViewModel rendezVous = new CalendarViewModel()
            {
                DateCodeRendezVousTaken = _rendezVousService.GetTakenRendezVousTimeCode(),
                FirstDayOfMonth = new DateTime(year, month, 1)
            };

            return PartialView(rendezVous);
        }
    }
}
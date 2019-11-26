using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyNails.Service.PrestationServices;
using FairyNails.Service.RendezVousServices;
using FairyNailsApp.Models.Admin;
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

        [HttpPost]
        public IActionResult GetDayRendezVous(String date)
        {
            List<AdminRendezVousViewModel> rendezVous = _rendezVousService.GetDayRendezVousWithPrestationName<AdminRendezVousViewModel>(date);

            return PartialView(rendezVous);
        }

        [HttpPost]
        public IActionResult AcceptRejectRendezVous(Int32 idRdv, String command)
        {
            bool status = _rendezVousService.RendezVousValidReject(idRdv, command);

            List<AdminRendezVousViewModel> waitingRendezVous = _rendezVousService.GetWaitingRendezVous<AdminRendezVousViewModel>();

            return PartialView("WaitingRendezVous", waitingRendezVous);
        }
    }
}
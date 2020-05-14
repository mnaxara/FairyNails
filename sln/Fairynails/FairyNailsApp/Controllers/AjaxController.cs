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
        private readonly IPrestationService _prestationService;

        public AjaxController(IRendezVousService rendezVousService, IPrestationService prestationService)
        {
            this._rendezVousService = rendezVousService;
            this._prestationService = prestationService;
        }

        [HttpPost]
        public IActionResult CalendarChangeMonth(Int32 month, Int32 year)
        {
            CalendarViewModel rendezVous = new CalendarViewModel()
            {
                UnavaibleTimeCode = _rendezVousService.GetUnavailableDateCode(month),
                FirstDayOfMonth = new DateTime(year, month, 1)
            };

            return PartialView(rendezVous);
        }

        [HttpPost]
        public IActionResult GetRendezVousManagement()
        {
            AdminRendezVousManagementViewModel model = new AdminRendezVousManagementViewModel()
            {
                TodayShortDate = DateTime.Now.ToShortDateString(),
                RendezVousOfDay = _rendezVousService
                    .GetDayRendezVousWithPrestationName<AdminRendezVousViewModel>(DateTime.Now.ToShortDateString()),
                WaitingRendezVous = _rendezVousService.GetWaitingRendezVous<AdminRendezVousViewModel>()
            };
            return PartialView("AdminRendezVousManagement", model);
        }

        [HttpPost]
        public IActionResult GetPrestationsManagement()
        {

            List<AdminPrestationViewModel> model = _prestationService.GetAllPrestations<AdminPrestationViewModel>();
            return PartialView("AdminGetPrestationsManagement", model);
        }

        [HttpPost]
        public IActionResult GetEditPrestationForm(Int32 idPrestation)
        {
            AdminPrestationViewModel model = _prestationService.GetPrestationById<AdminPrestationViewModel>(idPrestation);

            return PartialView("AdminGetEditPrestationForm", model);
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

            if (!status)
            {
                TempData["alert"] = "Vous avez déja un rendez vous prévu dans cet horaire";
            }
            return PartialView("WaitingRendezVous", waitingRendezVous);
        }

        [HttpPost]
        public IActionResult GetAddPrestationForm()
        {
            return PartialView("AdminAddPrestationForm");
        }
    }
}
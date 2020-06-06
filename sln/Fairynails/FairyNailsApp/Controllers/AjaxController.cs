using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyNails.Service.ClientService;
using FairyNails.Service.MailerServices;
using FairyNails.Service.PrestationServices;
using FairyNails.Service.RendezVousServices;
using FairyNailsApp.Models.Admin;
using FairyNailsApp.Models.RendezVous;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FairyNailsApp.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IRendezVousService _rendezVousService;
        private readonly IPrestationService _prestationService;
        private readonly IClientService _clientService;
        private readonly IMailerService _mailerService;

        public AjaxController(
            IRendezVousService rendezVousService,
            IPrestationService prestationService,
            IClientService clientService,
            IMailerService mailerService)
        {
            this._rendezVousService = rendezVousService;
            this._prestationService = prestationService;
            this._clientService = clientService;
            this._mailerService = mailerService;
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult GetRendezVousManagement()
        {
            AdminRendezVousManagementViewModel model = new AdminRendezVousManagementViewModel()
            {
                TodayShortDate = DateTime.Now.ToShortDateString(),
                RendezVousOfDay = _rendezVousService
                    .GetDayRendezVousWithPrestationName<AdminRendezVousModel>(DateTime.Now.ToShortDateString()),
                WaitingRendezVous = _rendezVousService.GetWaitingRendezVous<AdminRendezVousModel>()
            };
            return PartialView("AdminRendezVousManagement", model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult GetPrestationsManagement()
        {

            List<AdminPrestationViewModel> model = _prestationService.GetAllPrestations<AdminPrestationViewModel>();
            return PartialView("AdminGetPrestationsManagement", model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult GetEditPrestationForm(Int32 idPrestation)
        {
            AdminPrestationViewModel model = _prestationService.GetPrestationById<AdminPrestationViewModel>(idPrestation);

            return PartialView("AdminGetEditPrestationForm", model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult GetDayRendezVous(String date)
        {
            List<AdminRendezVousModel> rendezVous = _rendezVousService.GetDayRendezVousWithPrestationName<AdminRendezVousModel>(date);

            return PartialView(rendezVous);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AcceptRejectRendezVous(Int32 idRdv, String command)
        {
            bool status = _rendezVousService.RendezVousValidReject(idRdv, command);

            List<AdminRendezVousModel> waitingRendezVous = _rendezVousService.GetWaitingRendezVous<AdminRendezVousModel>();

            if (!status)
            {
                TempData["alert"] = "Vous avez déja un rendez vous prévu dans cet horaire";
            }
            return PartialView("WaitingRendezVous", waitingRendezVous);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CancelRendezVous(Int32 idRdv, String date)
        {
            bool status = _rendezVousService.CancelRendezVous(idRdv);

            List<AdminRendezVousModel> rendezVous = _rendezVousService.GetDayRendezVousWithPrestationName<AdminRendezVousModel>(date);

            if (!status)
            {
                TempData["alert"] = "Le Rendez Vous n'existe pas";
            }
            return PartialView("GetDayRendezVous", rendezVous);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult GetAddPrestationForm()
        {
            return PartialView("AdminAddPrestationForm");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult GetClientsManagement()
        {
            List<AdminClientViewModel> clients = _clientService.GetAllClientWithAdminData<AdminClientViewModel, AdminRendezVousModel>();
            return PartialView("AdminAllClients", clients);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> SendInfoEmail(List<string> adress, string subject, string content)
        {
            var sendResult = await _mailerService.SendInfoEmailAsync(adress, subject, content);
            if (sendResult)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
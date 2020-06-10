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
using System.Net;
using FairyNails.Ressources;

namespace FairyNailsApp.Controllers
{
    [Authorize]
    public class RendezVousController : Controller
    {
        private readonly IRendezVousService _rendezVousService;
        private readonly IPrestationService _prestationService;

        public RendezVousController(IRendezVousService rendezVousService, IPrestationService prestationService)
        {
            this._rendezVousService = rendezVousService;
            this._prestationService = prestationService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Calendar");
        }

        public IActionResult Calendar(ViewMessage message = null)
        {

            CalendarViewModel model = new CalendarViewModel()
            {
                Prestations = _prestationService.GetAllPrestations<PrestationViewModel>(),
                UnavaibleTimeCode = _rendezVousService.GetUnavailableDateCode(DateTime.Now.Month),
                FirstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                Message = message
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveRendezVous(CalendarViewModel rdvData)
        {
            ViewMessage message = new ViewMessage();
            if (ModelState.IsValid)
            {
                List<Int32> prestationChosenId = new List<Int32>();
                foreach (var prestation in rdvData.Prestations)
                {
                    if (prestation.IsChosen)
                    {
                        prestationChosenId.Add(prestation.IdPrestation);
                    }
                }
                if (prestationChosenId.Count > 0)
                {
                    try
                    {
                        _rendezVousService.AddRendezVous(rdvData.IdClient, prestationChosenId, rdvData.DateCode, WebUtility.HtmlEncode(rdvData.Comments));
                        message.MessageType = "success";
                        message.Content = "Merci, je vous confirme notre rendez vous au plus vite !";
                    }
                    catch (Exception e)
                    {
                        message.MessageType = "danger";
                        message.Content = e.Message;
                    }
                }
                else
                {
                    message.MessageType = "danger";
                    message.Content = "Vous devez choisir au moins une prestations";
                }
            }
            else
            {
                message.MessageType = "alert";
                message.Content = "Paramètres invalides";
            }
            return RedirectToAction("Calendar", message);
        }
    }
}
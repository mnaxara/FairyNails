using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyNails.Service.PrestationServices;
using FairyNails.Service.RendezVousServices;
using FairyNailsApp.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FairyNails.Service.ClientService;
using FairyNails.Service.MailerServices;
using FairyNails.Ressources;

namespace FairyNailsApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IPrestationService _prestationService;
        private readonly IClientService _clientService;
        private readonly IMailerService _mailerService;

        public AdminController(
            RoleManager<IdentityRole> rolemanager,
            IPrestationService prestationService,
            IClientService clientService,
            IMailerService mailerService)
        {
            this._rolemanager = rolemanager;
            this._prestationService = prestationService;
            this._clientService = clientService;
            this._mailerService = mailerService;
        }
        [Route("/{controller}/Client/{clientID}")]
        public IActionResult GetClientInfo(String clientId)
        {
            try
            {
                AdminClientViewModel client = _clientService.GetClientById<AdminClientViewModel, AdminRendezVousModel>(clientId);
                if (client == null)
                {
                    var message = new ViewMessage() { MessageType = "danger", Content = "Aucun client trouvé avec cet identifiant" };
                    return View("Index", message);
                }
                else
                {
                    return View(client);
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = $"{e.Message}";
                return View("Index");
            }
        }

        public IActionResult Index(ViewMessage message = null)
        {
            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePrestation(AdminPrestationViewModel prestation)
        {
            _prestationService.UpdatePrestation<AdminPrestationViewModel>(prestation);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePrestation(Int32 idPrestation)
        {
            _prestationService.DeletePrestation(idPrestation);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPrestation(AdminPrestationViewModel prestation)
        {
            _prestationService.AddPrestation(prestation);
            return RedirectToAction("Index");
        }

    }
}

    //TODO: Gallerie / Admin Gallerie / Admin Générale
    //TODO: Envoi mail (reservation annulation, acceptation)
    //TODO: Numero tel?
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

namespace FairyNailsApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IPrestationService _prestationService;
        private readonly IClientService _clientService;

        public AdminController(RoleManager<IdentityRole> rolemanager, IPrestationService prestationService, IClientService clientService)
        {
            this._rolemanager = rolemanager;
            this._prestationService = prestationService;
            this._clientService = clientService;
        }

        public IActionResult Index()
        {
            return View();
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

        [Route("/Client/{clientID}")]
        public IActionResult GetClientInfo(String clientId)
        {            
            try
            {
                AdminClientViewModel client = _clientService.GetClientById<AdminClientViewModel, AdminRendezVousModel>(clientId);

                if (client == null)
                {
                    ViewBag.Message = "Aucun Client trouvé avec cet Identifiant";
                    return View("Index");
                }
                return View(client);
            }
            catch(Exception e)
            {
                ViewBag.Message = $"{e.Message}";
                return View("Index");
            }
        }
    }
}

    //TODO: Gallerie / Admin Gallerie / Admin Générale
    //TODO: Envoi mail (reservation annulation, acceptation)
    //TODO: Numero tel?
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyNails.Service.PrestationServices;
using FairyNailsApp.Models.Prestation;
using Microsoft.AspNetCore.Mvc;

namespace FairyNailsApp.Controllers
{
    public class PrestationController : Controller
    {

        private readonly IPrestationService _prestationService;

        public PrestationController(IPrestationService prestationService)
        {
            this._prestationService = prestationService;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel()
            {
                Prestations = _prestationService.GetAllPrestations<PrestationViewModel>()
            };
            
            return View(model);
        }
    }
}
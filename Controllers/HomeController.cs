using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiteLanche.Models;
using SiteLanche.Repositories;
using SiteLanche.ViewModels;

namespace SiteLanche.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILanchesRepository _lancheRepository;

        public HomeController(ILanchesRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel 
            { 
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            };
            return View(homeViewModel);
        }
        public ViewResult AccessDenied()
        {
            return View();
        }



    }
}

using Doorang.Bussiness.Service.Abstracts;
using DoorangTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoorangTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExplorerService _explorerService;

        public HomeController(IExplorerService explorerService)
        {
            _explorerService = explorerService;
        }

        public IActionResult Index()
        {
            var explorers = _explorerService.GetAllExplorer();
            return View(explorers);
        }


      
    }
}

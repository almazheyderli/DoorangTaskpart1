using Doorang.Bussiness.Exceptions;
using Doorang.Bussiness.Service.Abstracts;
using Doorang.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoorangTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExplorerController : Controller
    {
        private readonly IExplorerService _explorerService;

        public ExplorerController(IExplorerService explorerService)
        {
            _explorerService = explorerService;
        }

        public IActionResult Index()
        {
            var explorers = _explorerService.GetAllExplorer();
            return View(explorers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Explorer explorer) { 
        if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _explorerService.AddExplorer(explorer);
            }
         catch (FileContentException ex)
            {
                ModelState.AddModelError(ex.PropertyName,ex.Message);
            }
            catch (FileSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var existExplorer=_explorerService.GetExplorer(x=>x.Id== id);
            if(existExplorer==null) return NotFound();
            _explorerService.RemoveExplorer(existExplorer.Id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            var oldExplorer=_explorerService.GetExplorer(x=>x.Id == id);
            if(oldExplorer==null) return NotFound();
            return View(oldExplorer);   
        }
        [HttpPost]
        public IActionResult Update(Explorer explorer)
        {
            if(!ModelState.IsValid) { return View(); }
            _explorerService.Update(explorer.Id, explorer);
            return RedirectToAction(nameof(Index));
        }
    }
}

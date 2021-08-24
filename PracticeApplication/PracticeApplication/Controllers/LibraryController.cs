using Microsoft.AspNetCore.Mvc;
using PracticeApplication.Models;
using PracticeApplication.Orchestrator.Interface;
using System.Collections.Generic;

namespace PracticeApplication.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryOrchestrator _orchestrator;

        public LibraryController(ILibraryOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }

        public IActionResult ComposerIndex()
        {
            List<ComposerViewModel> models = _orchestrator.GetAllComposers();
            return View(models);
        }

        public IActionResult ComposerDetail(string id)
        {
            ComposerViewModel model = _orchestrator.GetComposer(id);
            return View(model);
        }

        public IActionResult AddComposer()
        {
            ComposerViewModel model = new ComposerViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddComposer(ComposerViewModel model)
        {
            string newComposerId = _orchestrator.AddComposer(model);
            return RedirectToAction("ComposerDetail", new { id = newComposerId });
        }
    }
}

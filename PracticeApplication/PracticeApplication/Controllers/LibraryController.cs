using Microsoft.AspNetCore.Mvc;
using PracticeApplication.DataAccess.Repository.Interface;
using PracticeApplication.Models;
using PracticeApplication.Orchestrator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeApplication.Controllers
{
    public class LibraryController : Controller
    {
        private ILibraryOrchestrator _orchestrator;

        public LibraryController(ILibraryOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }

        public IActionResult ComposerIndex()
        {
            List<ComposerViewModel> models = _orchestrator.GetComposers();
            return View(models);
        }
    }
}

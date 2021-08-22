﻿using Microsoft.AspNetCore.Mvc;
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

        //TODO: call orchestrator to save model and return id
        [HttpPost]
        public IActionResult AddComposer(ComposerViewModel model)
        {
            string newComposerId = _orchestrator.AddComposer(model);
            return RedirectToAction("ComposerDetail", new { id = newComposerId });
        }
    }
}

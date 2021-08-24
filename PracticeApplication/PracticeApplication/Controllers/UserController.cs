using Microsoft.AspNetCore.Mvc;
using PracticeApplication.WebUI.Models;
using PracticeApplication.WebUI.Orchestrator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Security;

namespace PracticeApplication.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserOrchestrator _userOrchestrator;

        public UserController(IUserOrchestrator userOrchestrator)
        {
            _userOrchestrator = userOrchestrator;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}

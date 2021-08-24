using PracticeApplication.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeApplication.WebUI.Orchestrator.Interface
{
    public interface IUserOrchestrator
    {
        string AuthenticateUser(UserLoginModel user);
        void RegisterUser(UserRegistrationModel user);
    }
}

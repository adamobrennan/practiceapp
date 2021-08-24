using PracticeApplication.DataAccess.Repository;
using PracticeApplication.DataAccess.Repository.Interface;
using PracticeApplication.Domain.Entity;
using PracticeApplication.WebUI.Models;
using PracticeApplication.WebUI.Orchestrator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeApplication.WebUI.Orchestrator
{
    public class UserOrchestrator : IUserOrchestrator
    {
        private readonly IUserRepository _userRepository;

        public UserOrchestrator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public string AuthenticateUser(UserLoginModel user)
        {
            return _userRepository.Authenticate(user.Username, user.Password);
        }

        public void RegisterUser(UserRegistrationModel user)
        {
            User userEntity = new User()
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate
            };
            _userRepository.CreateUser(userEntity);
        }
    }
}

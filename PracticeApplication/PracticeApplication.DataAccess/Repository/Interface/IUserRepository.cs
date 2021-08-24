using PracticeApplication.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApplication.DataAccess.Repository.Interface
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(string id);
        User CreateUser(User user);
        void UpdateUser(string id, User user);
        void DeleteUser(string id);
        string Authenticate(string username, string password);
    }
}

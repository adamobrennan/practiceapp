using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using PracticeApplication.DataAccess.Encryption;
using PracticeApplication.DataAccess.Repository.Interface;
using PracticeApplication.DataAccess.Settings;
using PracticeApplication.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PracticeApplication.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;
        private readonly string _key;

        public UserRepository(IPracticeDatabaseSettings settings, IConfiguration configuration)
        {
            IMongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase db = client.GetDatabase(settings.DatabaseName);

            _users = db.GetCollection<User>(settings.UserCollectionName);

            _key = configuration.GetSection("JwtToken").ToString();
        }

        public List<User> GetUsers()
        {
            return _users.Find(user => true).ToList();
        }

        public User GetUser(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        public User CreateUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void UpdateUser(string id, User user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
        }

        public void DeleteUser(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public string Authenticate(string username, string password)
        {
            User user = _users.Find(user => user.Email == username && user.Password == password).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] tokenKey = Encoding.ASCII.GetBytes(_key);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

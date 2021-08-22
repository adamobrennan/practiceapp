using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApplication.DataAccess
{
    public interface IRepository<T>
    {
        T GetById(string id);
        List<T> GetAll();
        string Insert(T data);
        void Update(string id, T data);
        void Delete(string id);
    }
}

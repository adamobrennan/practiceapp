using System.Collections.Generic;

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

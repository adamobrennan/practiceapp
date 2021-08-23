using PracticeApplication.Domain.Entity;
using System.Collections.Generic;

namespace PracticeApplication.DataAccess.Repository.Interface
{
    public interface IComposerRepository : IRepository<Composer>
    {
        List<Composer> GetComposerByLastName(string name);
    }
}

using PracticeApplication.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApplication.DataAccess.Repository.Interface
{
    public interface IComposerRepository : IRepository<Composer>
    {
        List<Composer> GetComposerByLastName(string name);
    }
}

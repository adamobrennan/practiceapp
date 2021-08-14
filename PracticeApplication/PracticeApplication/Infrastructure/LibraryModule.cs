using Ninject.Modules;
using PracticeApplication.DataAccess.Repository;
using PracticeApplication.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeApplication.Infrastructure
{
    public class LibraryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPieceRepository>().To<PieceRepository>().InSingletonScope();
        }
    }
}

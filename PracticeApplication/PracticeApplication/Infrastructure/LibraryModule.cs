using Ninject.Modules;
using PracticeApplication.DataAccess.Repository;
using PracticeApplication.DataAccess.Repository.Interface;

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

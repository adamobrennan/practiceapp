using PracticeApplication.Domain.Entity;
using System.Collections.Generic;

namespace PracticeApplication.DataAccess.Repository.Interface
{
    public interface IPieceRepository : IRepository<Piece>
    {
        Piece GetPieceByTitle(string title);
        List<Piece> GetPiecesByComposer(string id);
    }
}

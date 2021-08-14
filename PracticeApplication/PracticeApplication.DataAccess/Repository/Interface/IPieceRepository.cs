using PracticeApplication.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApplication.DataAccess.Repository.Interface
{
    public interface IPieceRepository : IRepository<Piece>
    {
        Piece GetPieceByTitle(string title);
        List<Piece> GetPiecesByComposer(string id);
    }
}

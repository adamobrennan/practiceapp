using PracticeApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApplication.Orchestrator.Interface
{
    public interface ILibraryOrchestrator
    {
        List<PieceViewModel> GetPieces();
        List<PieceViewModel> GetPiecesByComposer(string id);
        List<ComposerViewModel> GetComposers();
    }
}

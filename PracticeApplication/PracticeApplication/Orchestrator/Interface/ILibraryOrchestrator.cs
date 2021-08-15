using PracticeApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApplication.Orchestrator.Interface
{
    public interface ILibraryOrchestrator
    {
        List<PieceViewModel> GetPieces();
        List<ComposerViewModel> GetComposers();
        ComposerViewModel GetComposer(string id);
    }
}

using PracticeApplication.WebUI.Models;
using System.Collections.Generic;

namespace PracticeApplication.Orchestrator.Interface
{
    public interface ILibraryOrchestrator
    {
        List<PieceViewModel> GetAllPieces();
        List<ComposerViewModel> GetAllComposers();
        ComposerViewModel GetComposer(string id);
        string AddComposer(ComposerViewModel composer);
    }
}

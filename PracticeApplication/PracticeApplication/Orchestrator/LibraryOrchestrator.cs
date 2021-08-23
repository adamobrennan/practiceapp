using PracticeApplication.DataAccess.Repository.Interface;
using PracticeApplication.Domain.Entity;
using PracticeApplication.Models;
using PracticeApplication.Orchestrator.Interface;
using PracticeApplication.Orchestrator.Mapper;
using System.Collections.Generic;
using System.Linq;

namespace PracticeApplication.Orchestrator
{
    public class LibraryOrchestrator : ILibraryOrchestrator
    {
        private IPieceRepository _pieceRepository;
        private IComposerRepository _composerRepository;

        public LibraryOrchestrator(IPieceRepository pieceRepository, IComposerRepository composerRepository)
        {
            _pieceRepository = pieceRepository;
            _composerRepository = composerRepository;
        }
        public List<ComposerViewModel> GetAllComposers()
        {
            List<Composer> composers = _composerRepository.GetAll();
            List<Piece> pieces = _pieceRepository.GetAll();
            return LibraryMapper.MapComposerCollectionToView(composers, pieces);
        }

        public List<PieceViewModel> GetAllPieces()
        {
            List<Piece> pieces = _pieceRepository.GetAll();
            return LibraryMapper.MapPieceCollectionToView(pieces);
        }

        public ComposerViewModel GetComposer(string id)
        {
            return GetAllComposers().Where(c => c.Id == id).FirstOrDefault();
        }

        public string AddComposer(ComposerViewModel composer)
        {
            Composer composerEntity = LibraryMapper.MapComposerViewToEntity(composer);
            string newComposerId = _composerRepository.Insert(composerEntity);
            return newComposerId;
        }
    }
}

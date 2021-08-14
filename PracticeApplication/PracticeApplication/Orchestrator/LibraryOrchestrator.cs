using PracticeApplication.DataAccess.Repository.Interface;
using PracticeApplication.Domain.Entity;
using PracticeApplication.Models;
using PracticeApplication.Orchestrator.Interface;
using PracticeApplication.Orchestrator.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public List<ComposerViewModel> GetComposers()
        {
            List<Composer> composers = _composerRepository.GetAll();
            List<Piece> pieces = _pieceRepository.GetAll();
            return LibraryMapper.MapComposerCollectionToView(composers, pieces);
        }

        public List<PieceViewModel> GetPieces()
        {
            List<Piece> pieces = _pieceRepository.GetAll();
            return LibraryMapper.MapPieceCollectionToView(pieces);
        }

        public List<PieceViewModel> GetPiecesByComposer(string id)
        {
            return GetPieces().Where(p => p.ComposerId == id).ToList();
        }
    }
}

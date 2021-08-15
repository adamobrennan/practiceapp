﻿using PracticeApplication.Domain.Entity;
using PracticeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeApplication.Orchestrator.Mapper
{
    public static class LibraryMapper
    {
        public static ComposerViewModel MapSingleComposerToView(Composer entity, List<Piece> pieces)
        {
            return new ComposerViewModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Birthdate = entity.Birthdate,
                Died = entity.Died,
                Pieces = MapPieceCollectionToView(pieces)
            };
        }

        public static List<ComposerViewModel> MapComposerCollectionToView(List<Composer> entities, List<Piece> pieces)
        {
            return entities.Select(
                e => new ComposerViewModel()
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Birthdate = e.Birthdate,
                    Died = e.Died,
                    Pieces = MapComposerToPieces(e, pieces)
                }).ToList();
        }

        private static List<PieceViewModel> MapComposerToPieces(Composer composer, List<Piece> pieces)
        {
            List<Piece> composerPieces = pieces.Where(p => p.ComposerId == composer.Id).ToList();
            return MapPieceCollectionToView(composerPieces);
        }

        public static List<PieceViewModel> MapPieceCollectionToView(List<Piece> pieces)
        {
            return pieces.Select(
                p => new PieceViewModel() 
                { 
                    Id = p.Id,
                    Title = p.Title,
                    ComposerId = p.ComposerId,
                    Date = p.Date
                }).ToList();
        }
    }
}

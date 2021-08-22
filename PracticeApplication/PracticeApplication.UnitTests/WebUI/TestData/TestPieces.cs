﻿using PracticeApplication.Domain.Entity;
using PracticeApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApplication.UnitTests.WebUI.TestData
{
    public class TestPieces
    {
        public List<Piece> PieceEntities { get; set; }
        public List<PieceViewModel> PieceViews { get; set; }

        public TestPieces()
        {
            PieceEntities = LoadTestPieceEntities();
            PieceViews = LoadTestPieceViewModels();
        }

        private List<PieceViewModel> LoadTestPieceViewModels()
        {
            return new List<PieceViewModel>()
            {
                new PieceViewModel()
                {
                    Id = "1",
                    ComposerId = "1",
                    Title = "Test Piece 1",
                    Date = DateTime.Now
                },
                new PieceViewModel()
                {
                    Id = "2",
                    ComposerId = "1",
                    Title = "Test Piece 2",
                    Date = DateTime.Now
                },
                new PieceViewModel()
                {
                    Id = "3",
                    ComposerId = "2",
                    Title = "Test Piece 3",
                    Date = DateTime.Now
                },
            };
        }

        private List<Piece> LoadTestPieceEntities()
        {
            return new List<Piece>()
            {
                new Piece()
                {
                    Id = "1",
                    ComposerId = "1",
                    Title = "Test Piece 1",
                    Date = DateTime.Now
                },
                new Piece()
                {
                    Id = "2",
                    ComposerId = "1",
                    Title = "Test Piece 2",
                    Date = DateTime.Now
                },
                new Piece()
                {
                    Id = "3",
                    ComposerId = "2",
                    Title = "Test Piece 3",
                    Date = DateTime.Now
                },
            };
        }
    }
}
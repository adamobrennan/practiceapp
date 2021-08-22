using PracticeApplication.Domain.Entity;
using PracticeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticeApplication.UnitTests.WebUI.TestData
{
    public class TestComposers
    {
        public List<Composer> ComposerEntities { get; set; }
        public List<ComposerViewModel> ComposerViews { get; set; }

        public TestComposers()
        {
            ComposerEntities = LoadTestComposerEntities();
            ComposerViews = LoadTestComposerViews();
        }

        private static List<Composer> LoadTestComposerEntities()
        {
            return new List<Composer>()
            {
                new Composer()
                {
                    Id = "1",
                    FirstName = "Composer1",
                    LastName = "Test1",
                    Birthdate = DateTime.MinValue,
                    Died = DateTime.MinValue.AddYears(60)
                },
                new Composer()
                {
                    Id = "2",
                    FirstName = "Composer2",
                    LastName = "Test2",
                    Birthdate = DateTime.MinValue,
                    Died = DateTime.MinValue.AddYears(60)
                }
            };
        }

        private static List<ComposerViewModel> LoadTestComposerViews()
        {
            List<PieceViewModel> testPieces = new TestPieces().PieceViews;
            return new List<ComposerViewModel>()
            {
                new ComposerViewModel()
                {
                    Id = "1",
                    FirstName = "Composer1",
                    LastName = "Test1",
                    Birthdate = DateTime.MinValue,
                    Died = DateTime.MinValue.AddYears(60),
                    Pieces = testPieces.Where(p => p.Id == "1").ToList()
                },
                new ComposerViewModel()
                {
                    Id = "2",
                    FirstName = "Composer2",
                    LastName = "Test2",
                    Birthdate = DateTime.MinValue,
                    Died = DateTime.MinValue.AddYears(60),
                    Pieces = testPieces.Where(p => p.Id == "2").ToList()
                }
            };
        }
    }
}

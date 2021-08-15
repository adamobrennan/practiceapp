using NUnit.Framework;
using PracticeApplication.Orchestrator;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using PracticeApplication.DataAccess.Repository;
using PracticeApplication.Domain.Entity;
using PracticeApplication.UnitTests.WebUI.TestData;
using PracticeApplication.Models;
using PracticeApplication.DataAccess.Repository.Interface;
using PracticeApplication.DataAccess.Exceptions;
using System.Linq;

namespace PracticeApplication.UnitTests.WebUI.Orchestrator
{
    [TestFixture]
    public class LibraryOrchestratorTests
    {
        private LibraryOrchestrator sotOrchestrator;
        private TestPieces testPieces;
        private TestComposers testComposers;

        [SetUp]
        public void SetUp()
        {
            testPieces = new TestPieces();
            testComposers = new TestComposers();
            IMock<IPieceRepository> mockPieceRepository = SetUpPieceRepository();
            IMock<IComposerRepository> mockComposerRepository = SetUpComposerRepository();
            sotOrchestrator = new LibraryOrchestrator(mockPieceRepository.Object, mockComposerRepository.Object);
        }

        [Test]
        public void GetComposers_ReturnsExpectedList()
        {
            // Arrange
            List<ComposerViewModel> expected = new TestComposers().ComposerViews;

            // Act
            List<ComposerViewModel> actual = sotOrchestrator.GetComposers();

            // Assert
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].ToString(), actual[0].ToString());
        }

        public void GetPieceByTitle_PieceInData_ReturnsPieceWithExpectedTitle()
        {
            // Arrange
            string expected = testPieces.PieceViews[0].Title;

            // Act

            // Assert

        }

        private IMock<IPieceRepository> SetUpPieceRepository()
        {
            Mock<IPieceRepository> mock = new Mock<IPieceRepository>();
            mock.Setup(m => m.GetAll()).Returns(testPieces.PieceEntities);
            mock.Setup(m => m.GetPieceByTitle(It.IsAny<string>()))
                .Returns<string>(s => testPieces.PieceEntities
                        .Where(p => p.Title == s)
                        .FirstOrDefault() == null ? 
                            throw new PieceNotFoundException() : 
                                testPieces.PieceEntities.Where(p => p.Title == s).First());
            return mock;
        }
        private IMock<IComposerRepository> SetUpComposerRepository()
        {
            Mock<IComposerRepository> mock = new Mock<IComposerRepository>();
            mock.Setup(m => m.GetAll()).Returns(testComposers.ComposerEntities);
            return mock;
        }
    }
}

using NUnit.Framework;
using System;
using System.IO;
using TurtleChallenge.App.Services;

namespace TurtleChallenge.Tests
{
    [TestFixture]
    public class FileServiceTests
    {
        private const string FileMoves = @"TurtleChallenge.App\moves.json";
        private const string FileSettings = @"TurtleChallenge.App\game-settings.json";

        private FileService _fileService;

        [SetUp]
        public void Setup()
        {
            _fileService = new FileService();
        }

        [Test]
        public void GetSequences_WhenCalled_ReturnSequences()
        {
            var root = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf(typeof(FileServiceTests).Namespace));

            var jsonFile = Path.Combine(root, FileMoves);

            var sequences = _fileService.GetSequences(jsonFile);

            Assert.That(sequences, Is.All.Not.Null);
        }

        [Test]
        [TestCase("xxx.json")]
        [TestCase("")]
        [TestCase(null)]
        public void GetSequences_WhenErrorOccurs_ThrowsException(string jsonFile)
        {
            var ex = Assert.Throws<Exception>(() => _fileService.GetSequences(jsonFile));

            Assert.That(ex.Message, Is.EqualTo($"Error getting {jsonFile} file."));
        }

        [Test]
        public void GetGame_WhenCalled_ReturnGame()
        {
            var root = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf(typeof(FileServiceTests).Namespace));

            var jsonFile = Path.Combine(root, FileSettings);

            var game = _fileService.GetGame(jsonFile);

            Assert.That(game, Is.Not.Null);
        }

        [Test]
        [TestCase("xxx.json")]
        [TestCase("")]
        [TestCase(null)]
        public void GetGame_WhenErrorOccurs_ThrowsException(string jsonFile)
        {
            var ex = Assert.Throws<Exception>(() => _fileService.GetGame(jsonFile));

            Assert.That(ex.Message, Is.EqualTo($"Error getting {jsonFile} file."));
        }
    }
}
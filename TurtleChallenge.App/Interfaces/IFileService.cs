using System.Collections.Generic;
using TurtleChallenge.App.Entities;

namespace TurtleChallenge.App.Interfaces
{
    public interface IFileService
    {
        Game GetGame(string settingsFile);
        IEnumerable<Sequence> GetSequences(string fileMoves);
    }
}
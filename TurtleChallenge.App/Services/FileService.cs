using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TurtleChallenge.App.Entities;
using TurtleChallenge.App.Interfaces;

namespace TurtleChallenge.App.Services
{
    public class FileService : IFileService
    {
        public IEnumerable<Sequence> GetSequences(string fileMoves)
        {
            try
            {
                return JsonConvert.DeserializeObject<IEnumerable<Sequence>>(ReadFile(fileMoves));
            }
            catch(Exception ex)
            {
                throw new Exception($"Error getting {fileMoves} file.", ex);
            }
        }

        public Game GetGame(string fileSettings)
        {
            try
            {
                return JsonConvert.DeserializeObject<Game>(ReadFile(fileSettings));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting {fileSettings} file.", ex);
            }
        }

        private string ReadFile(string file) => System.IO.File.ReadAllText(file);
    }
}

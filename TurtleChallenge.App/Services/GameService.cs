using System;
using System.Collections.Generic;
using TurtleChallenge.App.Entities;
using TurtleChallenge.App.Interfaces;

namespace TurtleChallenge.App.Services
{
    public class GameService : IGameService
    {
        private readonly IFileService _fileService;

        public GameService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Play(string fileSettings, string fileMoves)
        {
            try
            {
                IEnumerable<Sequence> sequences = GetSequences(fileMoves);

                var numSequence = 0;

                foreach (var sequence in sequences)
                {
                    numSequence++;

                    Console.WriteLine($"*******************Start Squence{numSequence}*******************");

                    var game = CreateGame(fileSettings);
                    var gameOver = false;

                    foreach (var action in sequence.Actions)
                    {
                        gameOver = PlayGame(game, action);
                        if (gameOver)
                            break;
                    };

                    EndGame(numSequence, game, gameOver);

                    Console.WriteLine($"****************************************************");
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has ocurred during the game -> {ex.Message}");
            }
            finally
            {
                Console.Read();
            }
        }

        private IEnumerable<Sequence> GetSequences(string fileMoves)
        {
            var sequences = _fileService.GetSequences(fileMoves);
            if (sequences == null)
                throw new ArgumentNullException($"The {fileMoves} file is empty.");

            return sequences;
        }

        private Game CreateGame(string fileSettings)
        {
            var game = _fileService.GetGame(fileSettings);
            if (game == null)
                throw new ArgumentNullException($"The {fileSettings} file is empty.");

            game.Validate();

            game.Board.Initialize(game.Mines, game.Exit);

            return game;
        }

        private bool PlayGame(Game game, Enums.Action action)
        {
            if (action == Enums.Action.Move)
            {
                if (game.IsMovementAllowed(game.Board, game.Turtle))
                {
                    game.Turtle.Move();

                    Console.WriteLine($"Turtle has moved to cell: [{game.Turtle.X}, {game.Turtle.Y}]");

                    return game.IsGameOver();
                }
                else
                    Console.WriteLine($"Warning: Turtle is trying to escape from the cell: [{game.Turtle.X}, {game.Turtle.Y}]!");
            }
            else if (action == Enums.Action.Rotate)
            {
                game.Turtle.Rotate();

                Console.WriteLine($"Turtle has rotated to: {game.Turtle.Direction}");
            }
            else
                throw new ArgumentOutOfRangeException($"{action} is not a valid action.");

            return false;
        }

        private void EndGame(int numSequence, Game game, bool gameOver)
        {
            if (!gameOver)
                Console.WriteLine($"Squence{numSequence} result: Still in danger!");
            else
            {
                var endCell = game.Board.Cells[game.Turtle.X, game.Turtle.Y];

                if (endCell is Mine)
                    Console.WriteLine($"Squence{numSequence} result: Mine hit!");
                else
                    Console.WriteLine($"Squence{numSequence} result: Success!");
            }
        }
    }
}
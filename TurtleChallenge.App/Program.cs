using Microsoft.Extensions.DependencyInjection;
using TurtleChallenge.App.Interfaces;
using TurtleChallenge.App.Services;

namespace TurtleChallenge.App
{
    class Program
    {
        static void Main()
        {            
            var fileSettings = "game-settings.json";
            var fileMoves = "moves.json";

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileService, FileService>()
                .AddSingleton<IGameService, GameService>()
                .BuildServiceProvider();

            var gameService = serviceProvider.GetService<IGameService>();
            gameService.Play(fileSettings, fileMoves);
        }
    }
}

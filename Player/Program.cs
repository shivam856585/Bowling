using Bowling;
using Bowling.Interface;
using Bowling.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace Player
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var game = StartGame();
            for (int i = 0; i < 9; i++)
            {
                game.Add(4);
                game.Add(4);
            }
            game.Add(10);

            Console.WriteLine($"{game.Score}");
        }

        public static IBowlingGame StartGame()
        {
            var container = new ServiceCollection();
            container.AddSingleton<IBowlingFactory, BowlingFactory>();
            container.AddTransient<IScorer, Scorer>();
            container.AddTransient<IBowlingGame, BowlingGame>();

            var provider = container.BuildServiceProvider();
            IBowlingFactory factory = provider.GetService<IBowlingFactory>();
            IBowlingGame bowlingGame = factory.Create();
            return bowlingGame;
        }
    }
}
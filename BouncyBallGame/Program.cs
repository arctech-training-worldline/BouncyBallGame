using System;

namespace BouncyBallGame
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Press any key to start the game");
            Console.ReadKey();

            var game = new BouncyBallGame();
            game.StartGame();
        }
    }
}

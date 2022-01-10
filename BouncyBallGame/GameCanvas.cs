using System;

namespace BouncyBallGame
{
    internal class GameCanvas : IGameCanvas
    {
        public int Width => Console.WindowWidth;
        public int Height => Console.WindowHeight;

        public Point TopRight => new(Console.WindowWidth, 0);


        public void ShowCharacter(char ch, Point point, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            using (new ColorBackup(foregroundColor, backgroundColor))
            {
                ShowCharacter(ch, point);
            }
        }

        public void ShowCharacter(char ch, Point point)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(ch);
        }

        public void ShowText(string text, Point point, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            using (new ColorBackup(foregroundColor, backgroundColor))
            {
                ShowText(text, point);
            }
        }

        public void ShowText(string text, Point point)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(text);
        }

        public void ShowCursor()
        {
            Console.CursorVisible = true;
        }

        public void HideCursor()
        {
            Console.CursorVisible = false;
        }

        public bool GetKeyIfAvailable(out ConsoleKey key)
        {
            if (!Console.KeyAvailable)
            {
                key = default;
                return false;
            }

            var keyInfo = Console.ReadKey(true);
            key = keyInfo.Key;

            return true;
        }
    }
}

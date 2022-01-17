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
            var colorBackup = new ColorBackup(foregroundColor, backgroundColor);

            ShowCharacter(ch, point);

            colorBackup.Revert();
        }

        public void ShowCharacter(char ch, Point point)
        {
            Console.SetCursorPosition(point.X, point.Y);
            Console.Write(ch);
        }

        public void ShowText(string text, Point point, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            var colorBackup = new ColorBackup(foregroundColor, backgroundColor);
            ShowText(text, point);
            colorBackup.Revert();
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

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void DisplayGameOver()
        {
            string[] gameOverText =
            {
                @" ________                          ________                      ",
                @" /  _____/_____    _____   ____     \_____  \___  __ ___________ ",
                @"/   \  ___\__  \  /     \_/ __ \     /   |   \  \/ // __ \_  __ \",
                @"\    \_\  \/ __ \|  Y Y  \  ___/    /    |    \   /\  ___/|  | \/",
                @" \______  (____  /__|_|  /\___  >   \_______  /\_/  \___  >__|   ",
                @"        \/     \/      \/     \/            \/          \/       "
            };

            DisplayAsciiArt(gameOverText);
            Console.WriteLine("\a\a");
        }

        /// <summary>
        /// Ascii Graphic art generated at
        /// http://www.network-science.de/ascii/
        /// </summary>
        public void DisplayBanner()
        {
            string[] bannerText =
            {
                @"\______   \_______   ____   ______ ______   _____    ____ ___.__.",
                @" |     ___/\_  __ \_/ __ \ /  ___//  ___/   \__  \  /    <   |  |",
                @" |    |     |  | \/\  ___/ \___ \ \___ \     / __ \|   |  \___  |",
                @" |____|     |__|    \___  >____  >____  >   (____  /___|  / ____|",
                @"                        \/     \/     \/         \/     \/\/     ",
                @" __                      __               _________ __                 __   ",
                @"|  | __ ____ ___.__.   _/  |_  ____      /   _____//  |______ ________/  |_ ",
                @"|  |/ // __ <   |  |   \   __\/  _ \     \_____  \\   __\__  \\_  __ \   __\",
                @"|    <\  ___/\___  |    |  | (  <_> )    /        \|  |  / __ \|  | \/|  |  ",
                @"|__|_ \\___  > ____|    |__|  \____/    /_______  /|__| (____  /__|   |__|  ",
                @"     \/    \/\/                                 \/           \/             ",
                @"  __  .__                 ________                       ",
                @"_/  |_|  |__   ____      /  _____/_____    _____   ____  ",
                @"\   __\  |  \_/ __ \    /   \  ___\__  \  /     \_/ __ \ ",
                @" |  | |   Y  \  ___/    \    \_\  \/ __ \|  Y Y  \  ___/ ",
                @" |__| |___|  /\___  >    \______  (____  /__|_|  /\___  >",
                @"           \/     \/            \/     \/      \/     \/ ",
            };


            DisplayAsciiArt(bannerText);
        }

        private void DisplayAsciiArt(string[] asciiArtText)
        {
            ClearScreen();

            const ConsoleColor foregroundColor = ConsoleColor.Cyan;
            const ConsoleColor backgroundColor = ConsoleColor.Black;

            var colorBackup = new ColorBackup(foregroundColor, backgroundColor);

            var point = new Point(0, (Height - asciiArtText.Length) / 2);

            foreach (var text in asciiArtText)
            {
                point.X = (Width - text.Length) / 2;
                ShowText(text, point);
                point.Y++;
            }
            
            colorBackup.Revert();

            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Spacebar && key.Key != ConsoleKey.Enter) { }

            ClearScreen();
        }
    }
}

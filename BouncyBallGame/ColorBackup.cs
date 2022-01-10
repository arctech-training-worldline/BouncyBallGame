using System;

namespace BouncyBallGame
{
    internal class ColorBackup : IDisposable
    {
        private readonly ConsoleColor _backupForegroundColor;
        private readonly ConsoleColor _backupBackgroundColor;

        public ColorBackup(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            _backupForegroundColor = Console.ForegroundColor;
            _backupBackgroundColor = Console.BackgroundColor;

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
        }
        public void Dispose()
        {
            Console.BackgroundColor = _backupBackgroundColor;
            Console.ForegroundColor = _backupForegroundColor;
        }
    }
}
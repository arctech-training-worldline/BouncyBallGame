using System;
using System.Threading;

namespace BouncyBallGame
{
    internal class ColorBackup
    {
        private static readonly object LockObj = new();

        private readonly ConsoleColor _backupForegroundColor;
        private readonly ConsoleColor _backupBackgroundColor;

        public ColorBackup(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Monitor.Enter(LockObj);

            _backupForegroundColor = Console.ForegroundColor;
            _backupBackgroundColor = Console.BackgroundColor;

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;

        }
        public void Revert()
        {
            Console.BackgroundColor = _backupBackgroundColor;
            Console.ForegroundColor = _backupForegroundColor;

            Monitor.Exit(LockObj);
        }
    }
}
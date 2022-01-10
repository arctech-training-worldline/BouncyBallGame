using System;

namespace BouncyBallGame
{
    internal interface IGameCanvas
    {
        int Width { get; }
        int Height { get; }
        Point TopRight { get; }
        void ShowCharacter(char ch, Point point, ConsoleColor foreColor, ConsoleColor backColor);
        void ShowCharacter(char ch, Point point);
        void ShowText(string text, Point point, ConsoleColor foregroundColor, ConsoleColor backgroundColor);
        void ShowText(string text, Point point);
        void ShowCursor();
        void HideCursor();
        bool GetKeyIfAvailable(out ConsoleKey key);
    }
}
using System;
using System.Threading;

namespace BouncyBallGame
{
    internal class Ball
    {
        private readonly IGameCanvas _gameCanvas;
        
        private const int MaxBrakeSpeed = 300;
        //private const char BallCharacter = (char)0x7F;
        private const char BallCharacter = '@';

        private static int _xFactor = 3;
        private static int _yFactor = 1;

        private int _speedBrake;

        private Point Position { get; }

        public Ball(int x, int y, IGameCanvas gameCanvas)
        {
            _gameCanvas = gameCanvas;
            Position = new Point(x, y);
            _speedBrake = 50;
        }

        //public void IncreaseSpeed(int value)
        public static Ball operator >>(Ball b, int value)
        {
            if (b._speedBrake - value <= 0)
                b._speedBrake = 0;
            else
                b._speedBrake -= value;
            return b;
        }

        //public void DecreaseSpeed(int value)
        public static Ball operator <<(Ball b, int value)
        {
            if (b._speedBrake + value > MaxBrakeSpeed)
                b._speedBrake = MaxBrakeSpeed;
            else
                b._speedBrake += value;
            return b;
        }

        //public void MoveBall()
        public static Ball operator ++(Ball b)
        {
            var newX = b.Position.X + _xFactor;
            var newY = b.Position.Y + _yFactor;

            if (newX < 0 || newX > Console.WindowWidth)
                _xFactor = -_xFactor;

            if (newY < 0 || newY > Console.WindowHeight)
                _yFactor = -_yFactor;

            b.Position.X += _xFactor;
            b.Position.Y += _yFactor;

            return b;
        }

        public void Draw()
        {
            _gameCanvas.ShowCharacter(BallCharacter, Position, ConsoleColor.White, ConsoleColor.DarkRed);
            ShowLogMessage();
            Thread.Sleep(_speedBrake);
        }

        private void ShowLogMessage()
        {
            var text = $"x:{Position.X:000} y:{Position.Y:000} speedBrake: {_speedBrake:000}";
            var canvasTopRight = _gameCanvas.TopRight;
            canvasTopRight.X -= text.Length;

            _gameCanvas.ShowText(text, canvasTopRight);
        }

        internal void Clear()
        {
            _gameCanvas.ShowCharacter(' ', Position);
        }
    }
}
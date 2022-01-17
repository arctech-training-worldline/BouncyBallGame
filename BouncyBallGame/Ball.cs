using System;
using System.Threading;

namespace BouncyBallGame
{
    internal class Ball : IDisposable
    {
        public event EventHandler<Point> BottomBoundaryHit;
        private readonly IGameCanvas _gameCanvas;
        
        private const char BallCharacter = '@';

        private static int _xFactor = 3;
        private static int _yFactor = 1;

        private readonly int _speedBrake;

        private Point Position { get; }

        private bool _exitThread;

        public Ball(int x, int y, IGameCanvas gameCanvas)
        {
            _gameCanvas = gameCanvas;
            Position = new Point(x, y);
            _speedBrake = 50;
        }

        internal void StartBouncing()
        {
            Draw();

            var thread1 = new Thread(DoWork);
            thread1.Start();
        }

        internal void StopBouncing()
        {
            _exitThread = true;
        }

        private void DoWork()
        {
            do
            {
                ShowLogMessage();
                Thread.Sleep(_speedBrake);

                Hide();
                Move();
                Draw();
            } while (!_exitThread);

            Hide();
        }

        public void Move()
        {
            var newX = Position.X + _xFactor;
            var newY = Position.Y + _yFactor;

            if (newX < 0)
                _xFactor = -_xFactor;

            if (newX >= Console.WindowWidth)
                _xFactor = -_xFactor;

            if (newY < 0)
                _yFactor = -_yFactor;

            if (newY >= Console.WindowHeight)
            {
                _yFactor = -_yFactor;
                BottomBoundaryHit?.Invoke(this, Position);
            }

            Position.X += _xFactor;
            Position.Y += _yFactor;
        }
        public void Draw()
        {
            _gameCanvas.ShowCharacter(BallCharacter, Position, ConsoleColor.White, ConsoleColor.DarkRed);
        }

        internal void Hide()
        {
            _gameCanvas.ShowCharacter(' ', Position);
        }

        private void ShowLogMessage()
        {
            var text = $"x:{Position.X:000} y:{Position.Y:000} speedBrake: {_speedBrake:000}";
            var canvasTopRight = _gameCanvas.TopRight;
            canvasTopRight.X -= text.Length;

            _gameCanvas.ShowText(text, canvasTopRight);
        }

        public void Dispose()
        {
            StopBouncing();
        }
    }
}

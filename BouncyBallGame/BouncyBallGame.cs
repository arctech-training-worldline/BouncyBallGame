using System;

namespace BouncyBallGame
{
    internal class BouncyBallGame
    {
        private readonly IGameCanvas _canvas;
        private Score _score;
        private Ball _ball;
        private Block _block;

        public BouncyBallGame()
        {
            _canvas = new GameCanvas();
            _score = new Score(_canvas);
            _ball = new Ball(10, 5, _canvas);
            _ball.BottomBoundaryHit += BallOnBottomBoundaryHit;
            _block = new Block(_canvas);
        }

        private void BallOnBottomBoundaryHit(object sender, Point point)
        {
            if (_block.IntersectsX(point.X))
                _score++;   // increase points
            else
                _score--;   // decrease lives;

            _score.Show();
        }

        public void StartGame()
        {
            _canvas.HideCursor();
            _canvas.DisplayBanner();

            _ball.Draw();
            _block.Draw();
            _score.Show();

            bool stopGame;
            do
            {
                _ball.Clear();
                _ball++;
                _ball.Draw();

                stopGame = CheckKeyPressedToStopGame();
            } while (!stopGame && _score.LivesRemaining);

            _canvas.DisplayGameOver();

            _canvas.ShowCursor();
        }

        private bool CheckKeyPressedToStopGame()
        {
            if (!_canvas.GetKeyIfAvailable(out var key))
                return false;

            switch (key)
            {
                case ConsoleKey.Escape:
                    return true;
                case ConsoleKey.Add:
                    _ball >>= 1;
                    break;
                case ConsoleKey.Subtract:
                    _ball <<= 1;
                    break;
                case ConsoleKey.Multiply:
                    _ball >>= 10;
                    break;
                case ConsoleKey.Divide:
                    _ball <<= 10;
                    break;
                case ConsoleKey.RightArrow:
                    _block++;
                    break;
                case ConsoleKey.LeftArrow:
                    _block--;
                    break;
            }

            return false;
        }
    }
}

using System;

namespace BouncyBallGame
{
    internal class BouncyBallGame
    {
        private IGameCanvas _canvas;
        private Score _score;
        private Ball _ball;
        private Block _block;

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
            _canvas = new GameCanvas();

            _canvas.HideCursor();
            _canvas.DisplayBanner();

            _block = new Block(_canvas);
            _block.Draw();

            _score = new Score(_canvas);
            _score.Show();

            using (_ball = new Ball(10, 5, _canvas))
            {
                _ball.BottomBoundaryHit += BallOnBottomBoundaryHit;
                _ball.StartBouncing();

                bool stopGame;
                do
                {
                    stopGame = CheckKeyPressedToStopGame();

                } while (!stopGame && _score.LivesRemaining);

                _ball.StopBouncing();
            }

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
                case ConsoleKey.RightArrow:
                    _block.MoveRight();
                    break;
                case ConsoleKey.LeftArrow:
                    _block.MoveLeft();
                    break;
            }

            return false;
        }
    }
}

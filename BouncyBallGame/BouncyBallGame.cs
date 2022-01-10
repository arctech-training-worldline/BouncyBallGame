using System;

namespace BouncyBallGame
{
    internal class BouncyBallGame
    {
        private Ball _ball;
        private Block _block;
        private readonly IGameCanvas _canvas;

        public BouncyBallGame()
        {
            _canvas = new GameCanvas();
            _ball = new Ball(10, 5, _canvas);
            _block = new Block(_canvas);
        }

        public void StartGame()
        {
            _canvas.HideCursor();

            _ball.Clear();
            _block.Draw();

            bool stopGame;
            do
            {
                _ball.Clear();
                _ball++;
                _ball.Draw();

                stopGame = CheckKeyPressedToStopGame();
            } while (!stopGame);

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
                    //b.IncreaseSpeed(1);
                    //b = b >> 1;
                    _ball >>= 1;
                    break;
                case ConsoleKey.Subtract:
                    //b.DeceaseSpeed(1);
                    //b = b << 1;
                    _ball <<= 1;
                    break;
                case ConsoleKey.Multiply:
                    //b.IncreaseSpeed(1);
                    //b = b >> 10;
                    _ball >>= 10;
                    break;
                case ConsoleKey.Divide:
                    //b.DecreaseSpeed(1);
                    //b = b << 10;
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

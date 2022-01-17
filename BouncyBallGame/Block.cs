using System;

namespace BouncyBallGame
{
    internal class Block
    {
        private const int Width = 20;
        private const int Height = 1;
        private const int Speed = 5;
        private readonly string _blockText;

        private readonly IGameCanvas _gameCanvas;
        private readonly Point _point;
        private int Right => _point.X + Width;

        public Block(IGameCanvas gameCanvas)
        {
            _gameCanvas = gameCanvas;
            _point = new Point(_gameCanvas.Width / 2 - Width, _gameCanvas.Height - Height);
            _blockText =  new string(' ', Width);
        }

        public void Draw()
        {
            _gameCanvas.ShowText(_blockText, _point, ConsoleColor.White, ConsoleColor.DarkRed);
        }

        private void Hide()
        {
            _gameCanvas.ShowText(_blockText, _point);
        }

        public void MoveRight()
        {
            Hide();

            var newX = _point.X + Speed;

            if (newX > _gameCanvas.Width - Width - 1)
                _point.X = _gameCanvas.Width - Width - 1;
            else
                _point.X = newX;
            
            Draw();           
        }

        public void MoveLeft()
        {
            Hide();

            var newY = _point.X - Speed;
            _point.X = newY < 0 ? 0 : newY;

            Draw();
        }

        public bool IntersectsX(int x)
        {
            return x >= _point.X && x <= Right;
        }
    }
}
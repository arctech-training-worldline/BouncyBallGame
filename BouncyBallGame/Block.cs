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

        public static Block operator ++(Block block)
        {
            block.Clear();

            if (block._point.X + Speed > block._gameCanvas.Width - Width)
                block._point.X = block._gameCanvas.Width - Width;
            else
                block._point.X += Speed;
            
            block.Draw();
            
            return block;
        }

        public static Block operator --(Block block)
        {
            block.Clear();

            if (block._point.X - Speed < 0)
                block._point.X = 0;
            else
                block._point.X -= Speed;

            block.Draw();

            return block;
        }

        private void Clear()
        {
            _gameCanvas.ShowText(_blockText, _point);
        }

        public bool IntersectsX(int x)
        {
            return x >= _point.X && x <= Right;
        }

        private int Right => _point.X + Width;
    }
}
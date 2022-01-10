namespace BouncyBallGame
{
    internal class Score
    {
        private const int MaxLives = 3;

        private readonly IGameCanvas _gameCanvas;
        private int _points;

        private int _lives;

        public Score(IGameCanvas gameCanvas)
        {
            _gameCanvas = gameCanvas;
            _points = 0;
            _lives = MaxLives;
        }

        public static Score operator ++(Score score)
        {
            score._points++;
            return score;
        }

        public bool LivesRemaining => _lives > 0;

        public static Score operator --(Score score)
        {
            if (score._lives > 0)
                score._lives--;

            return score;
        }

        public void Show()
        {
            var text = $"Score:{_points:000} | Lives:{_lives:000}";
            _gameCanvas.ShowText(text, new Point(0, 0));
        }
    }
}
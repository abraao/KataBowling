namespace KataBowling
{
    public class Game
    {

        private readonly int[][] _scoreBoard;
        private int _currentRound = 0;
        private int _currentThrow = 0;

        public Game()
        {
            _scoreBoard = new int[10][];
            for (int i = 0; i < 10; i++)
            {
                _scoreBoard[i] = new int[4];
                _scoreBoard[i][0] = 0;
                _scoreBoard[i][1] = 0;
                _scoreBoard[i][2] = 0;
                _scoreBoard[i][3] = 0;
            }
        }

        public void Roll(int currentScore)
        {
            _scoreBoard[_currentRound][_currentThrow] = currentScore;

            HandlePreviousRoundIsStrike(currentScore);

            HandlePreviousRoundIsSpare(currentScore);

            AdvanceGame(currentScore);
        }

        private void HandlePreviousRoundIsSpare(int currentScore)
        {
            if (_currentThrow == 0)
            {
                CarryIfSpare(currentScore);
            }
        }

        private void HandlePreviousRoundIsStrike(int currentScore)
        {
            if (IsPreviousRoundAStrike())
            {
                _scoreBoard[_currentRound - 1][2 + _currentThrow] = currentScore;
            }
        }

        private void AdvanceGame(int currentScore)
        {
            if (_currentThrow == 0)
            {
                if (currentScore == 10)
                {
                    _currentRound++;
                }
                else
                {
                    _currentThrow++;
                }
            }
            else
            {
                _currentThrow = 0;
                _currentRound++;
            }
        }

        private bool IsPreviousRoundAStrike()
        {
            if (_currentRound == 0)
            {
                return false;
            }

            if (_scoreBoard[_currentRound - 1][0] == 10)
            {
                return true;
            }

            return false;
        }

        private void CarryIfSpare(int currentScore)
        {
            if (_currentRound > 0)
            {
                int previousRoundScore = GetPreviousRoundScore();
                if (previousRoundScore == 10)
                {
                    _scoreBoard[_currentRound - 1][2] = currentScore;
                }
            }
        }

        private int GetPreviousRoundScore()
        {
            return _scoreBoard[_currentRound - 1][0] + _scoreBoard[_currentRound - 1][1];
        }

        public int Score()
        {
            int totalScore = 0;
            for (int round = 0; round < 10; round++)
            {
                totalScore += _scoreBoard[round][0];
                totalScore += _scoreBoard[round][1];
                totalScore += _scoreBoard[round][2];
                totalScore += _scoreBoard[round][3];
            }
            return totalScore;
        }
    }
}

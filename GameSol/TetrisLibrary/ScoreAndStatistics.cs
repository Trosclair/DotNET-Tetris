namespace TetrisLibrary
{
    public class ScoreAndStatistics
    {
        #region Singleton
        private ScoreAndStatistics() { }
        private static readonly Lazy<ScoreAndStatistics> lazy = new Lazy<ScoreAndStatistics>(() => new ScoreAndStatistics());
        public static ScoreAndStatistics Instance => lazy.Value;
        #endregion

        #region Properties
        public int Lines { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }

        public int L { get; set; }
        public int J { get; set; }
        public int I { get; set; }
        public int U { get; set; }
        public int Z { get; set; }
        public int S { get; set; }
        public int T { get; set; }
        #endregion

        #region Public Methods
        public void ResetScoreAndStatistics()
        {
            L =
            I =
            S =
            T =
            Z =
            J =
            U =
            Score =
            Lines =
            Level = 0;
        }

        public void UpdateScoreOnLinesCleared(int linesCleared)
        {
            switch (linesCleared)
            {
                case 1:
                    Score += 100 * (Level + 1);
                    break;
                case 2:
                    Score += 300 * (Level + 1);
                    break;
                case 3:
                    Score += 600 * (Level + 1);
                    break;
                case 4:
                    Score += 1000 * (Level + 1);
                    break;
            }
            Lines += linesCleared;
            if (Level * 10 + 10 <= Lines)
            {
                Level++;
            }
        }
        #endregion
    }
}

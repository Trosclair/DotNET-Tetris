namespace GameSol
{
    public class ScoreAndStatistics
    {
        public ScoreAndStatistics()
        {
            ResetScoreAndStats();
        }

        public void ResetScoreAndStats()
        {
            L = 0;
            I = 0;
            S = 0;
            T = 0;
            Z = 0;
            J = 0;
            U = 0;
            Score = 0;
        }

        public int Score { get; set; }

        public int L { get; set; }

        public int J { get; set; }

        public int I { get; set; }

        public int U { get; set; }

        public int Z { get; set; }

        public int S { get; set; }

        public int T { get; set; }
    }
}

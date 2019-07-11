namespace GameSol
{
    public static class ScoreAndStatistics
    {

        public static void SetScoreAndStats()
        {
            L = 0;
            I = 0;
            S = 0;
            T = 0;
            Z = 0;
            J = 0;
            U = 0;
            Score = 0;
            Lines = 0;
            Level = 0;
        }

        public static void UpdateScore(int linesCleared)
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

        public static int Lines { get; set; }
        public static int Level { get; set; }
        public static int Score { get; set; }

        public static int L { get; set; }

        public static int J { get; set; }

        public static int I { get; set; }

        public static int U { get; set; }

        public static int Z { get; set; }

        public static int S { get; set; }

        public static int T { get; set; }
    }
}

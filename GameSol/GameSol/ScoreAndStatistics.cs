using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSol
{
    public class ScoreAndStatistics
    {
        private int _L;
        private int _J;
        private int _I;
        private int _U;
        private int _Z;
        private int _S;
        private int _T;
        private int _score;

        public ScoreAndStatistics()
        {
            ResetScoreAndStats();
        }

        public void ResetScoreAndStats()
        {
            _L = 0;
            _I = 0;
            _S = 0;
            _T = 0;
            _Z = 0;
            _J = 0;
            _U = 0;
            _score = 0;
        }

        public int Score
        {
            get
            {
                return _score;
            }

            set
            {
                _score = value;
            }
        }

        public int L
        {
            get
            {
                return _L;
            }

            set
            {
                _L = value;
            }
        }

        public int J
        {
            get
            {
                return _J;
            }

            set
            {
                _J = value;
            }
        }

        public int I
        {
            get
            {
                return _I;
            }

            set
            {
                _I = value;
            }
        }

        public int U
        {
            get
            {
                return _U;
            }

            set
            {
                _U = value;
            }
        }

        public int Z
        {
            get
            {
                return _Z;
            }

            set
            {
                _Z = value;
            }
        }

        public int S
        {
            get
            {
                return _S;
            }

            set
            {
                _S = value;
            }
        }

        public int T
        {
            get
            {
                return _T;
            }

            set
            {
                _T = value;
            }
        }
    }
}

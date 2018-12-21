using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSol
{
    class L : Piece
    {
        public L(int[,] board)
        {
            One = new Block(0, 5);
            Two = new Block(1, 5);
            Three = new Block(2, 5);
            Four = new Block(2, 6);
            Piece_Type = "L";
            Board = board;
        }

        ///*****
        ///**1**
        ///**2**
        ///**34*
        ///*****

        public override void RotateRight()
        {
            if (Three.Y + 1 == Four.Y)
            {
                if (Board[Two.X, Two.Y-1] == 0 && Board[Two.X+1, Two.Y-1] == 0 && Board[Two.X, Two.Y+1] == 0)
                {
                    if (Three.Y != 0)
                    {
                        One.X++;
                        One.Y++;
                        Three.X--;
                        Three.Y--;
                        Four.Y -= 2;
                    }
                }
            }
            else if (Three.X + 1 == Four.X)
            {
                if (Board[Two.X-1, Two.Y] == 0 && Board[Two.X-1, Two.Y-1] == 0 && Board[Two.X+1, Two.Y] == 0)
                {
                    One.X++;
                    One.Y--;
                    Three.X--;
                    Three.Y++;
                    Four.X -= 2;
                }
            }
            else if (Four.Y + 1 == Three.Y)
            {
                if (Board[Two.X, Two.Y+1] == 0 && Board[Two.X-1, Two.Y+1] == 0 && Board[Two.X, Two.Y-1] == 0)
                {
                    if (Three.Y != 9)
                    {
                        One.X--;
                        One.Y--;
                        Three.X++;
                        Three.Y++;
                        Four.Y += 2;
                    }
                }
            }
            else if (Three.X - 1 == Four.X)
            {
                if (Board[Two.X+1, Two.Y] == 0 && Board[Two.X+1, Two.Y+1] == 0 && Board[Two.X-1, Two.Y] == 0)
                {
                    if (Three.X != 19)
                    {
                        One.X--;
                        One.Y++;
                        Three.X++;
                        Three.Y--;
                        Four.X += 2;
                    }
                }
            }
        }

        public override void RotateLeft()
        {
            if (Three.Y + 1 == Four.Y)
            {
                if (Board[Two.X, Two.Y-1] == 0 && Board[Two.X+1, Two.Y+1] == 0 && Board[Two.X, Two.Y+1] == 0)
                {
                    if (Three.Y != 0)
                    {
                        One.X++;
                        One.Y--;
                        Three.X--;
                        Three.Y++;
                        Four.X -= 2;
                    }
                }
            }
            else if (Three.X - 1 == Four.X)
            {
                if (Board[Two.X-1, Two.Y] == 0 && Board[Two.X+1, Two.Y] == 0 && Board[Two.X-1, Two.Y-1] == 0)
                {
                    if (Three.X != 19)
                    {
                        One.X++;
                        One.Y++;
                        Three.X--;
                        Three.Y--;
                        Four.Y -= 2;
                    }
                }
            }
            else if (Three.Y - 1 == Four.Y)
            {
                if (Board[Two.X, Two.Y-1] == 0 && Board[Two.X+1, Two.Y-1] == 0 && Board[Two.X, Two.Y+1] == 0)
                {
                    if (Three.Y != 9)
                    {
                        One.X--;
                        One.Y++;
                        Three.X++;
                        Three.Y--;
                        Four.X += 2;
                    }
                }
            }
            else
            {
                if (Board[Two.X-1, Two.Y] == 0 && Board[Two.X+1, Two.Y] == 0 && Board[Two.X+1, Two.Y+1] == 0)
                {
                    One.X--;
                    One.Y--;
                    Three.X++;
                    Three.Y++;
                    Four.Y += 2;
                }
            }
        }
    }
}

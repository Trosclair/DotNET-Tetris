using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSol
{
    class J : Piece
    {
        public J(int[,] board)
        {
            One = new Block(0, 5);
            Two = new Block(1, 5);
            Three = new Block(2, 5);
            Four = new Block(2, 4);
            Piece_Type = "J";
            Board = board;
        }

            ///*****
            ///**1**
            ///**2**
            ///*43**
            ///*****
        public override void RotateLeft()
        {
            if (Four.Y + 1 == Three.Y)
            {
                if (Board[Two.X,Two.Y-1] == 0 && Board[Two.X, Two.Y+1] == 0 && Board[Two.X+1, Two.Y+1] == 0)
                {
                    if (Three.Y != 9)
                    {
                        Four.Y += 2;
                        Three.X--;
                        Three.Y++;
                        One.X++;
                        One.Y--;
                    }
                }
            }
            else if (Four.X + 1 == Three.X)
            {
                if (Board[Three.X+1, Three.Y] == 0 && Board[Three.X+1, Three.Y+1] == 0 && Board[Two.X, Two.Y+1] == 0)
                {
                    if (Three.X != 19)
                    {
                        Four.X += 2;
                        Three.X++;
                        Three.Y++;
                        One.X--;
                        One.Y--;
                    }
                }
            }
            else if (Three.Y + 1 == Four.Y)
            {
                if (Board[Two.X, Two.Y-1] == 0 && Board[Two.X-1, Two.Y-1] == 0 && Board[Two.X, Two.Y+1] == 0)
                {
                    if (Three.Y != 0)
                    {
                        Four.Y -= 2;
                        Three.X++;
                        Three.Y--;
                        One.X--;
                        One.Y++;
                    }
                }
            }
            else
            {
                if (Board[Two.X-1, Two.Y] == 0 && Board[Two.X+1, Two.Y] == 0 && Board[Two.X-1, Two.Y+1] == 0)
                {
                    Four.X -= 2;
                    Three.X--;
                    Three.Y--;
                    One.X++;
                    One.Y++;
                }
            }
        }

        public override void RotateRight()
        {
            if (Four.Y + 1 == Three.Y)
            {
                if (Board[Two.X, Two.Y-1] == 0 && Board[Two.X-1, Two.Y-1] == 0 && Board[Two.X, Two.Y + 1] == 0)
                {
                    if (Three.Y != 9)
                    {
                        Four.X -= 2;
                        Three.X--;
                        Three.Y--;
                        One.X++;
                        One.Y++;
                    }
                }
            }
            else if (Four.X + 1 == Three.X)
            {
                if (Board[Two.X-1, Two.Y] == 0 && Board[Two.X-1, Two.Y+1] == 0 && Board[Two.X+1, Two.Y] == 0)
                {
                    if (Three.X != 19)
                    {
                        Four.Y += 2;
                        Three.X--;
                        Three.Y++;
                        One.X++;
                        One.Y--;
                    }
                }
            }
            else if (Three.Y + 1 == Four.Y)
            {
                if (Board[Two.X, Two.Y+1] == 0 && Board[Two.X+1, Two.Y+1] == 0 && Board[Two.X, Two.Y-1] == 0)
                {
                    if (Three.Y != 0)
                    {
                        Four.X += 2;
                        Three.X++;
                        Three.Y++;
                        One.X--;
                        One.Y--;
                    }
                }
            }
            else
            {
                if (Board[Two.X+1, Two.Y] == 0 && Board[Two.X+1, Two.Y-1] == 0 && Board[Two.X-1, Two.Y] == 0)
                {
                    Four.Y -= 2;
                    Three.X++;
                    Three.Y--;
                    One.X--;
                    One.Y++;
                }
            }
        }
    }
}

namespace TetrisLibrary.Pieces
{
    public class J : Piece
    {
        public J() : base(PieceType.J, 'J')
        {
            One = new Block(0, 5);
            Two = new Block(1, 5);
            Three = new Block(2, 5);
            Four = new Block(2, 4);
        }

        ///*****
        ///**1**
        ///**2**
        ///*43**
        ///*****
        public override void RotateLeft(int[,] board)
        {
            if (Four.Y + 1 == Three.Y)
            {
                if (Two.Y != 9)
                {
                    if (board[Two.X, Two.Y - 1] == 0 && board[Two.X, Two.Y + 1] == 0 && board[Two.X + 1, Two.Y + 1] == 0)
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
            }
            else if (Four.X + 1 == Three.X)
            {
                if (board[Three.X + 1, Three.Y] == 0 && board[Three.X + 1, Three.Y + 1] == 0 && board[Two.X, Two.Y + 1] == 0)
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
                if (Two.Y > 0)
                {
                    if (board[Two.X, Two.Y - 1] == 0 && board[Two.X - 1, Two.Y - 1] == 0 && board[Two.X, Two.Y + 1] == 0)
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
            }
            else
            {
                if (board[Two.X - 1, Two.Y] == 0 && board[Two.X + 1, Two.Y] == 0 && board[Two.X - 1, Two.Y + 1] == 0)
                {
                    Four.X -= 2;
                    Three.X--;
                    Three.Y--;
                    One.X++;
                    One.Y++;
                }
            }
        }

        public override void RotateRight(int[,] board)
        {
            if (Four.Y + 1 == Three.Y)
            {
                if (Two.Y != 9)
                {
                    if (board[Two.X, Two.Y - 1] == 0 && board[Two.X - 1, Two.Y - 1] == 0 && board[Two.X, Two.Y + 1] == 0)
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
            }
            else if (Four.X + 1 == Three.X)
            {
                if (board[Two.X - 1, Two.Y] == 0 && board[Two.X - 1, Two.Y + 1] == 0 && board[Two.X + 1, Two.Y] == 0)
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
                if (Two.Y > 0)
                {
                    if (board[Two.X, Two.Y + 1] == 0 && board[Two.X + 1, Two.Y + 1] == 0 && board[Two.X, Two.Y - 1] == 0)
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
            }
            else
            {
                if (board[Two.X + 1, Two.Y] == 0 && board[Two.X + 1, Two.Y - 1] == 0 && board[Two.X - 1, Two.Y] == 0)
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

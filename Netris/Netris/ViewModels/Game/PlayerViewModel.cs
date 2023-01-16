using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using WPFUtilities;
using Netris.ViewModels.Game.Pieces;
using Netris.ViewModels.Parameters;
using Netris.ViewModels.Settings;
using Netris.ViewModels.Settings.Controls;

namespace Netris.ViewModels.Game
{
    public class PlayerViewModel : ObservableObject
    {
        private readonly Shadow shadow;
        private readonly Action pause;
        private readonly PieceFactory pieceFactory;
        private readonly List<DASStateViewModel> dasControls = new();
        private readonly KeyboardPlayerControlsViewModel playerControls;
        private PieceViewModel currentPiece;
        private long autoDropTime = 0;
        private long currentDropTime = 0;
        private bool hasHeld = false;
        private PieceViewModel next, holdPiece, one, two, three, four;

        public ObservableCollection<BlockViewModel> Board { get; } = new();
        public PieceViewModel Next { get => next; set { next = value; OnPropertyChanged(nameof(Next)); } }
        public PieceViewModel HoldPiece { get => holdPiece; set { holdPiece = value; OnPropertyChanged(nameof(HoldPiece)); } }
        public PieceViewModel One { get => one; set { one = value; OnPropertyChanged(nameof(One)); } }
        public PieceViewModel Two { get => two; set { two = value; OnPropertyChanged(nameof(Two)); } }
        public PieceViewModel Three { get => three; set { three = value; OnPropertyChanged(nameof(Three)); } }
        public PieceViewModel Four { get => four; set { four = value; OnPropertyChanged(nameof(Four)); } }
        public bool GameOver { get; set; } = false;
        public int PiecesGenerated { get; set; } = 0;
        public BlockViewModel this[int i, int j] { get => Board[(i * 10) + j]; set => Board[(i * 10) + j] = value; }
        public BlockViewModel this[BlockViewModel block] { get => this[block.X, block.Y]; set => this[block.X, block.Y] = value; }
        public int PlayerNumber { init; get; }

        public PlayerViewModel(SettingsViewModel settings, ParametersViewModel parameters, PieceFactory pieceFactory, Action pause, int playerNumber)
        {
            for (int i = 0; i < 200; i++)
                Board.Add(new BlockViewModel(i / 10, i % 10, Colors.Transparent, Brushes.Transparent));

            this.pieceFactory = pieceFactory;

            next = pieceFactory.GetNextPiece(this);
            one = pieceFactory.GetNextPiece(this);
            two = pieceFactory.GetNextPiece(this);
            three = pieceFactory.GetNextPiece(this);
            four = pieceFactory.GetNextPiece(this);
            holdPiece = new Empty(this);

            PlayerNumber = playerNumber;
            this.pause = pause;

            shadow = new(this);
            currentPiece = Pop();
            AddPieceToBoard(currentPiece);

            playerControls = settings.ControlSettings.KeyboardViewModels[playerNumber];
            dasControls.Add(new(parameters.DAS, MoveDown, () => Keyboard.IsKeyDown(playerControls.MoveDown)));
            dasControls.Add(new(parameters.DAS, MoveRight, () => Keyboard.IsKeyDown(playerControls.MoveRight)));
            dasControls.Add( new(parameters.DAS, MoveLeft, () => Keyboard.IsKeyDown(playerControls.MoveLeft)));
            dasControls.Add(new(parameters.DAS, RotateClockwise, () => Keyboard.IsKeyDown(playerControls.RotateClockwise)));
            dasControls.Add(new(parameters.DAS, RotateCounterClockwise, () => Keyboard.IsKeyDown(playerControls.RotateCounterClockwise)));
            dasControls.Add(new(parameters.DAS, HardDrop, () => Keyboard.IsKeyDown(playerControls.HardDrop)));

            //dasControls.Add(playerControls.Hold, (Hold, 0));
            //dasControls.Add(playerControls.Pause, (Pause, 0));
            //dasControls.Add(playerControls.HardDrop, (HardDrop, 0));
        }


        public PieceViewModel Pop()
        {
            PieceViewModel result = Next;
            Next = One;
            One = Two;
            Two = Three;
            Three = Four;
            Four = pieceFactory.GetNextPiece(this);
            hasHeld = false;
            return result;
        }

        public PieceViewModel SwapHoldPiece(PieceViewModel currentPiece)
        {
            if (!hasHeld)
            {
                PieceViewModel result;

                currentPiece.ResetPiecePosition();

                if (HoldPiece is Empty)
                {
                    HoldPiece = currentPiece;
                    result = Pop();
                }
                else
                {
                    result = HoldPiece;
                    HoldPiece = currentPiece;
                }
                hasHeld = true;

                return result;
            }
            else
            {
                return currentPiece;
            }
        }

        private void MoveLeft()
        {
            currentPiece.MoveLeft();
        }

        private void MoveRight()
        {
            currentPiece.MoveRight();
        }

        private void MoveDown()
        {
            if (!currentPiece.MoveDown())
            {
                CheckBoardForLineClears();
                currentPiece = Pop();
                AddPieceToBoard(currentPiece);
            }
            autoDropTime = MainViewModel.GlobalTimer.ElapsedMilliseconds;
        }

        private void Hold()
        {
            RemovePieceFromBoard(currentPiece);
            currentPiece = SwapHoldPiece(currentPiece);
            AddPieceToBoard(currentPiece);
        }

        private void RotateCounterClockwise()
        {
            currentPiece.RotateCounterClockwise();
        }

        private void RotateClockwise()
        {
            currentPiece.RotateClockwise();
        }

        private void HardDrop()
        {
            currentPiece.HardDrop();
            CheckBoardForLineClears();
            currentPiece = Pop();
            AddPieceToBoard(currentPiece);
        }

        private void Pause()
        {
            pause();
        }

        public void CheckForInput()
        {
            if (Keyboard.IsKeyDown(playerControls.Pause))
            {
                Pause();
            }
            else if (Keyboard.IsKeyDown(playerControls.Hold))
            {
                Hold();
            }
            else
            {
                foreach (DASStateViewModel dasControl in dasControls)
                {
                    if (dasControl.Predicate())
                    {
                        if (!dasControl.IsDown)
                        {
                            dasControl.Move();
                            dasControl.IsDown = true;
                        }
                        dasControl.Update();
                    }
                    else
                    {
                        if (dasControl.IsDown)
                            dasControl.IsDown = false;
                    }
                }
            }
        }

        public bool MakeMoveIfValid(PieceViewModel piece, Action makeMove, Action revertMove)
        {
            bool isMoveValid;

            RemovePieceFromBoard(piece);

            makeMove();

            isMoveValid = !PieceViewModelExtensions.IsOutOfBounds(piece);

            if (isMoveValid)
            {
                foreach (BlockViewModel block in piece.Blocks)
                {
                    if (!this[block.X, block.Y].IsEmpty)
                    {
                        isMoveValid = false;
                        revertMove();
                        break;
                    }
                }
            }
            else
            {
                revertMove();
            }

            AddPieceToBoard(piece);

            return isMoveValid;
        }

        public void AddPieceToBoard(PieceViewModel piece)
        {
            UpdateShadow(piece);

            foreach (BlockViewModel block in piece.Blocks)
            {
                this[block.X, block.Y].Color = piece.One.Color;
                this[block.X, block.Y].Brush = piece.One.Brush;
            }
        }

        public void RemovePieceFromBoard(PieceViewModel piece)
        {
            foreach (BlockViewModel block in piece.Blocks)
            {
                this[block.X, block.Y].Color = Colors.Transparent;
                this[block.X, block.Y].Brush = Brushes.Transparent;
            }
        }

        public int CheckBoardForLineClears()
        {
            int linesCleared = 0;

            for (int i = 19; i >= 0; i--)
            {
                bool isClear = true;

                for (int j = 0; j < 10; j++)
                {
                    isClear &= !this[i, j].IsEmpty;
                }

                if (isClear)
                {
                    linesCleared++;
                    ClearLine(i);
                    i++;
                }
            }

            return linesCleared;
        }

        private void UpdateShadow(PieceViewModel piece)
        {
            foreach (BlockViewModel block in shadow.Blocks)
            {
                if (this[block].Brush == Brushes.White)
                {
                    this[block].Brush = Brushes.Transparent;
                    this[block].Color = Colors.Transparent;
                }
            }

            shadow.One = new(piece.One.X, piece.One.Y, Colors.White, Brushes.White);
            shadow.Two = new(piece.Two.X, piece.Two.Y, Colors.White, Brushes.White);
            shadow.Three = new(piece.Three.X, piece.Three.Y, Colors.White, Brushes.White);
            shadow.Four = new(piece.Four.X, piece.Four.Y, Colors.White, Brushes.White);

            do
            {
                shadow.One.X++;
                shadow.Two.X++;
                shadow.Three.X++;
                shadow.Four.X++;
            }
            while (!shadow.IsOutOfBounds() && this[shadow.One].IsEmpty && this[shadow.Two].IsEmpty && this[shadow.Three].IsEmpty && this[shadow.Four].IsEmpty);

            shadow.One.X--;
            shadow.Two.X--;
            shadow.Three.X--;
            shadow.Four.X--;

            foreach (BlockViewModel block in shadow.Blocks)
            {
                this[block].Color = shadow.One.Color;
                this[block].Brush = shadow.One.Brush;
            }
        }

        private void ClearLine(int rowToClear)
        {
            for (int i = rowToClear; i >= 1; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    this[i, j].Color = this[i - 1, j].Color;
                    this[i, j].Brush = this[i - 1, j].Brush;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                this[0, i].Color = Colors.Transparent;
                this[0, i].Brush = Brushes.Transparent;
            }
        }
    }
}

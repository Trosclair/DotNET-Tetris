﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFTetris.ViewModels.Game.Pieces
{
    public class Shadow : PieceViewModel
    {
        public Shadow(BoardViewModel board) : base(PieceType.Shadow, board)
        {
            One = new(0, 0, Colors.White, Brushes.White);
            Two = new(0, 0, Colors.White, Brushes.White);
            Three = new(0, 0, Colors.White, Brushes.White);
            Four = new(0, 0, Colors.White, Brushes.White);
        }

        public override void ResetPiecePosition() { }
        public override void RotateClockwise() { }
        public override void RotateCounterClockwise() { }
    }
}
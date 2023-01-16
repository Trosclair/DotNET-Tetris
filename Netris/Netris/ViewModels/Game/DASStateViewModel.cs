using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netris.ViewModels.Parameters;

namespace Netris.ViewModels.Game
{
    public class DASStateViewModel
    {
        private readonly int acceleration, topDelay, startingDelay;
        private bool isDown = false;
        private int currentDelay = 0;
        private long lastUpdate = 0;
        public int CurrentDelay { get => currentDelay; set { currentDelay = Math.Max(value, topDelay); } }
        public bool IsDown { get => isDown; set { isDown = value; CurrentDelay = value ? startingDelay : 0; lastUpdate = MainViewModel.GlobalTimer.ElapsedMilliseconds; } }
        public Action Move { get; set; }
        public Func<bool> Predicate { get; }
        public DASStateViewModel(DASViewModel das, Action move, Func<bool> predicate)
        {
            acceleration = das.Acceleration;
            topDelay = das.EndingDelay;
            startingDelay = das.StartingDelay;
            Move = move;
            Predicate = predicate;
        }

        public void Update()
        {
            if (IsDown)
            {
                if (lastUpdate + CurrentDelay < MainViewModel.GlobalTimer.ElapsedMilliseconds)
                {
                    Move();
                    CurrentDelay -= acceleration;
                    lastUpdate = MainViewModel.GlobalTimer.ElapsedMilliseconds;
                }
            }
        }
    }
}

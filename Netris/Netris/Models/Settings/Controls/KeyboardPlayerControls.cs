using Newtonsoft.Json;
using System.Windows.Input;

namespace Netris.Models.Settings.Controls
{
    public class KeyboardPlayerControls
    {
        public Key MoveDown { get; set; }
        public Key MoveRight { get; set; }
        public Key MoveLeft { get; set; }
        public Key HardDrop { get; set; }
        public Key RotateClockwise { get; set; }
        public Key RotateCounterClockwise { get; set; }
        public Key Hold { get; set; }
        public Key Pause { get; set; }
        public int PlayerNumber { get; set; }

        [JsonConstructor]
        public KeyboardPlayerControls() { }

        public KeyboardPlayerControls(Key moveDown, Key moveRight, Key moveLeft, Key hardDrop, Key rotateClockwise, Key rotateCounterClockwise, Key hold, Key pause, int playerNumber)
        {
            MoveDown = moveDown;
            MoveRight = moveRight;
            MoveLeft = moveLeft;
            HardDrop = hardDrop;
            RotateClockwise = rotateClockwise;
            RotateCounterClockwise = rotateCounterClockwise;
            Hold = hold;
            Pause = pause;
            PlayerNumber = playerNumber;
        }
    }
}

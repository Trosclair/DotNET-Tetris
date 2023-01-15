using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Netris.Models.Settings.Controls;
using Netris.Views.Settings.Controls;
using Newtonsoft.Json.Linq;
using WPFUtilities;
using WPFUtilities.Commands;

namespace Netris.ViewModels.Settings.Controls
{
    public class KeyboardPlayerControlsViewModel : ObservableObject
    {
        private readonly KeyboardPlayerControls model;
        private readonly ObservableCollection<KeyboardPlayerControlsViewModel> allPlayerKeyboards;
        private Key readKeyFromRebind = Key.None;
        private Key previousBoundKey = Key.None;
        private string commandToRebind = string.Empty;
        private RebindConfirmation? rebindConfirmation = null;
        private ReadKey? readKey = null;

        private bool isReadKeyEnabled;
        private string moveDownKeyText = string.Empty, moveRightKeyText = string.Empty, moveLeftKeyText = string.Empty, hardDropKeyText = string.Empty,
            rotateClockwiseKeyText = string.Empty, rotateCounterClockwiseKeyText = string.Empty, holdKeyText = string.Empty, pauseKeyText = string.Empty;

        public Key MoveDown { get => model.MoveDown; set { model.MoveDown = value; MoveDownKeyText = StringifyKey(value); OnPropertyChanged(nameof(MoveDown)); } }
        public Key MoveRight { get => model.MoveRight; set { model.MoveRight = value; MoveRightKeyText = StringifyKey(value); OnPropertyChanged(nameof(MoveRight)); } }
        public Key MoveLeft { get => model.MoveLeft; set { model.MoveLeft = value; MoveLeftKeyText = StringifyKey(value); OnPropertyChanged(nameof(MoveLeft)); } }
        public Key HardDrop { get => model.HardDrop; set { model.HardDrop = value; HardDropKeyText = StringifyKey(value); OnPropertyChanged(nameof(HardDrop)); } }
        public Key RotateClockwise { get => model.RotateClockwise; set { model.RotateClockwise = value; RotateClockwiseKeyText = StringifyKey(value); OnPropertyChanged(nameof(RotateClockwise)); } }
        public Key RotateCounterClockwise { get => model.RotateCounterClockwise; set { model.RotateCounterClockwise = value; RotateCounterClockwiseKeyText = StringifyKey(value); OnPropertyChanged(nameof(RotateCounterClockwise)); } }
        public Key Hold { get => model.Hold; set { model.Hold = value; HoldKeyText = StringifyKey(value); OnPropertyChanged(nameof(Hold)); } }
        public Key Pause { get => model.Pause; set { model.Pause = value; PauseKeyText = StringifyKey(value); OnPropertyChanged(nameof(Pause)); } }
        public bool IsReadKeyEnabled { get => isReadKeyEnabled; set { isReadKeyEnabled = value; OnPropertyChanged(nameof(IsReadKeyEnabled)); } }
        public int PlayerNumber { get => model.PlayerNumber; set { model.PlayerNumber = value; OnPropertyChanged(nameof(PlayerNumber)); } }
        public string MoveDownKeyText { get => moveDownKeyText; set { moveDownKeyText = value; OnPropertyChanged(nameof(MoveDownKeyText)); } }
        public string MoveRightKeyText { get => moveRightKeyText; set { moveRightKeyText = value; OnPropertyChanged(nameof(MoveRightKeyText)); } }
        public string MoveLeftKeyText { get => moveLeftKeyText; set { moveLeftKeyText = value; OnPropertyChanged(nameof(MoveLeftKeyText)); } }
        public string HardDropKeyText { get => hardDropKeyText; set { hardDropKeyText = value; OnPropertyChanged(nameof(HardDropKeyText)); } }
        public string RotateClockwiseKeyText { get => rotateClockwiseKeyText; set { rotateClockwiseKeyText = value; OnPropertyChanged(nameof(RotateClockwiseKeyText)); } }
        public string RotateCounterClockwiseKeyText { get => rotateCounterClockwiseKeyText; set { rotateCounterClockwiseKeyText = value; OnPropertyChanged(nameof(RotateCounterClockwiseKeyText)); } }
        public string HoldKeyText { get => holdKeyText; set { holdKeyText = value; OnPropertyChanged(nameof(HoldKeyText)); } }
        public string PauseKeyText { get => pauseKeyText; set { pauseKeyText = value; OnPropertyChanged(nameof(PauseKeyText)); } }

        public RelayCommand ChangeKeyboardBindCommand => new(ChangeKeyboardBind);
        public RelayCommand CancelRebindCommand => new(CancelRebind);
        public RelayCommand RebindCommand => new(Rebind);
        public RelayCommand DuplicateBindCommand => new(DuplicateBind);
        public RelayCommand UnbindCommand => new(Unbind);

        public KeyboardPlayerControlsViewModel(KeyboardPlayerControls keyboardPlayerControls, ObservableCollection<KeyboardPlayerControlsViewModel> keyboards) 
        { 
            model = keyboardPlayerControls; 
            allPlayerKeyboards = keyboards;

            MoveDownKeyText = StringifyKey(MoveDown);
            MoveLeftKeyText = StringifyKey(MoveLeft);
            MoveRightKeyText = StringifyKey(MoveRight);
            HardDropKeyText = StringifyKey(HardDrop);
            RotateClockwiseKeyText = StringifyKey(RotateClockwise);
            RotateCounterClockwiseKeyText = StringifyKey(RotateCounterClockwise);
            HoldKeyText = StringifyKey(Hold);
            PauseKeyText = StringifyKey(Pause);
        }

        private static string StringifyKey(Key key)
        {
            return key.ToString();
        }

        private void ChangeKeyboardBind(object? commandParameter)
        {
            if (commandParameter is not string)
            {
                throw new NotImplementedException();
            }

            commandToRebind = (string)commandParameter;

            readKey = new() { DataContext = this };
            readKey.ShowDialog();
            readKeyFromRebind = readKey.PressedKey;

            previousBoundKey = GetCurrentlyBoundKey();
            BindKey(Key.None);

            if (readKeyFromRebind != Key.None && allPlayerKeyboards.Sum(x => x.HowManyTimesIsKeyBound(readKeyFromRebind)) > 0)
            {
                rebindConfirmation = new() { DataContext = this };
                rebindConfirmation.ShowDialog();
            }
            else
            {
                BindKey(readKeyFromRebind);
            }
        }

        private void BindKey(Key key)
        {
            switch (commandToRebind)
            {
                case "MoveDown":
                    MoveDown = key;
                    break;
                case "MoveRight":
                    MoveRight = key;
                    break;
                case "MoveLeft":
                    MoveLeft = key;
                    break;
                case "HardDrop":
                    HardDrop = key;
                    break;
                case "RotateClockwise":
                    RotateClockwise = key;
                    break;
                case "RotateCounterClockwise":
                    RotateCounterClockwise = key;
                    break;
                case "Hold":
                    Hold = key;
                    break;
                case "Pause":
                    Pause = key;
                    break;
            }
        }

        private Key GetCurrentlyBoundKey()
        {
            return commandToRebind switch
            {
                "MoveDown" => MoveDown,
                "MoveRight" => MoveRight,
                "MoveLeft" => MoveLeft,
                "HardDrop" => HardDrop,
                "RotateClockwise" => RotateClockwise,
                "RotateCounterClockwise" => RotateCounterClockwise,
                "Hold" => Hold,
                "Pause" => Pause,
                _ => Key.None,
            };
        }

        private void CancelRebind()
        {
            if (rebindConfirmation is not null && rebindConfirmation.IsActive)
            {
                BindKey(previousBoundKey);
                previousBoundKey = readKeyFromRebind = Key.None;
                rebindConfirmation.Close();
                rebindConfirmation = null;
            }
        }

        private void Rebind()
        {
            if (rebindConfirmation is not null && rebindConfirmation.IsActive)
            {
                foreach (KeyboardPlayerControlsViewModel keyboard in allPlayerKeyboards)
                {
                    keyboard.UnbindAllThatMatchKey(readKeyFromRebind);
                }
                BindKey(readKeyFromRebind);
                previousBoundKey = readKeyFromRebind = Key.None;
                rebindConfirmation.Close();
                rebindConfirmation = null;
            }
        }

        private void DuplicateBind()
        {
            if (rebindConfirmation is not null && rebindConfirmation.IsActive)
            {
                BindKey(readKeyFromRebind);
                previousBoundKey = readKeyFromRebind = Key.None;
                rebindConfirmation.Close();
                rebindConfirmation = null;
            }
        }

        private void Unbind()
        {
            if (readKey is not null && readKey.IsActive)
            {
                readKey.PressedKey = Key.None;
                readKey.Close();
            }
        }

        public int HowManyTimesIsKeyBound(Key key) /// TODO: Use reflection to have a list of properties that match the Key Enum type and just do a loop. It's slower, but the code won't look (as much) like shit.
        {
            int count = 0;

            if (MoveLeft == key)
            {
                count++;
            }

            if (MoveDown == key)
            {
                count++;
            }

            if (MoveRight == key)
            {
                count++;
            }

            if (HardDrop == key)
            {
                count++;
            }

            if (RotateClockwise == key)
            {
                count++;
            }

            if (RotateCounterClockwise == key)
            {
                count++;
            }

            if (Hold == key)
            {
                count++;
            }

            if (Pause == key)
            {
                count++;
            }

            return count;
        }

        public void UnbindAllThatMatchKey(Key key)
        {
            if (MoveLeft == key)
            {
                MoveLeft = Key.None;
            }

            if (MoveDown == key)
            {
               MoveDown = Key.None;
            }

            if (MoveRight == key)
            {
                MoveRight = Key.None;
            }

            if (HardDrop == key)
            {
                HardDrop = Key.None;
            }

            if (RotateClockwise == key)
            {
                RotateClockwise = Key.None;
            }

            if (RotateCounterClockwise == key)
            {
                RotateCounterClockwise = Key.None;
            }

            if (Hold == key)
            {
                Hold = Key.None;
            }

            if (Pause == key)
            {
                Pause = Key.None;
            }
        }
    }
}

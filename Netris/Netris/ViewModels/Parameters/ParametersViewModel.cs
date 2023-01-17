using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netris.Models.Parameters;
using WPFUtilities;
using WPFUtilities.Commands;
using WPFUtilities.Extensions;

namespace Netris.ViewModels.Parameters
{
    public class ParametersViewModel : ObservableObject
    {
        private readonly Models.Parameters.Parameters model;
        private LevelViewModel? selectedLevel = null;

        public DASViewModel DAS { get; }
        public PieceGenerationViewModel PieceGeneration { get; }
        public ObservableCollection<LevelViewModel> Levels { get; } = new();
        private LevelViewModel? SelectedLevel { get => selectedLevel; set { selectedLevel = value; OnPropertyChanged(nameof(SelectedLevel)); } }
        public int StartingLevel { get => model.StartingLevel; set { model.StartingLevel = value; OnPropertyChanged(nameof(StartingLevel)); } }

        public RelayCommand AddLevelCommand => new(AddLevel);
        public RelayCommand DeleteLevelCommand => new(DeleteLevel);

        public ParametersViewModel(Models.Parameters.Parameters parameters)
        {
            model = parameters;

            DAS = new(model.DAS);
            PieceGeneration = new(model.PieceGeneration);
            Levels.AddRange(model.Levels.Select(x => new LevelViewModel(x)));

            if (Levels.Count == 0)
            {
                Levels.Add(new(new()));
            }
        }

        private void AddLevel()
        {
            Levels.Add(new(new()));
        }

        private void DeleteLevel()
        {
            if (SelectedLevel is not null)
            {
                int index = Levels.IndexOf(SelectedLevel);
                Levels.RemoveAt(index);
                if (index >= Levels.Count)
                {
                    SelectedLevel = Levels.LastOrDefault();
                }
                else
                {
                    SelectedLevel = Levels[index];
                }
            }
        }
    }
}

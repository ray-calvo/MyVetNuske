using System.Collections.ObjectModel;
using MyVetNuske.Common.Models;
using Prism.Navigation;

namespace MyVetNuske.Prism.ViewModels
{
    public class PetPageViewModel : ViewModelBase
    {
        private PetResponse _pet;
       // private ObservableCollection<HistoryItemViewModel> _histories;
        public PetPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public PetResponse Pet
        {
            get => _pet;
            set => SetProperty(ref _pet, value);
        }

      

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("pet"))
            {
                Pet = parameters.GetValue<PetResponse>("pet");
                Title = Pet.Name;

            }
        }
    }
}

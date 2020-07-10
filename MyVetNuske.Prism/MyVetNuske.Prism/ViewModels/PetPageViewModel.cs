using MyVetNuske.Common.Helpers;
using MyVetNuske.Common.Models;
using Newtonsoft.Json;
using Prism.Navigation;

namespace MyVetNuske.Prism.ViewModels
{
    public class PetPageViewModel : ViewModelBase
    {
        private PetResponse _pet;
        // private ObservableCollection<HistoryItemViewModel> _histories;
        public PetPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "DEtails";
        }

        public PetResponse Pet
        {
            get => _pet;
            set => SetProperty(ref _pet, value);
        }



        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Pet = JsonConvert.DeserializeObject<PetResponse>(Settings.Pet);
        }
    }
}

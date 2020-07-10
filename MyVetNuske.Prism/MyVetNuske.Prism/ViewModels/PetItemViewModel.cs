using MyVetNuske.Common.Helpers;
using MyVetNuske.Common.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;

namespace MyVetNuske.Prism.ViewModels
{
    public class PetItemViewModel : PetResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectPetCommand;

        public PetItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectPetCommand =>
            _selectPetCommand ?? (_selectPetCommand = new DelegateCommand(SelecPet));

        private async void SelecPet()
        {
            Settings.Pet = JsonConvert.SerializeObject(this);
            await _navigationService.NavigateAsync("PetTabbedPage");
        }
    }
}

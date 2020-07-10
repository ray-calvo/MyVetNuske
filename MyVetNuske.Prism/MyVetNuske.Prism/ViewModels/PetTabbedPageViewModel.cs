using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using MyVetNuske.Common.Helpers;
using MyVetNuske.Common.Models;
using Newtonsoft.Json;
using Prism.Navigation;

namespace MyVetNuske.Prism.ViewModels
{
    public class PetTabbedPageViewModel : ViewModelBase
    {
        public PetTabbedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            var pet = JsonConvert.DeserializeObject<PetResponse>(Settings.Pet);
            Title = $"Pet: {pet.Name}" ;

        }
    }
}

using MyVetNuske.Common.Models;
using Prism.Commands;
using Prism.Navigation;

namespace MyVetNuske.Prism.ViewModels
{
    public class HistoryItemViewModel : HistoryResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectHistoryCommand;

        public DelegateCommand SelectHistoryCommand => _selectHistoryCommand ?? (_selectHistoryCommand = new DelegateCommand(SelectHistory));

        public HistoryItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        private async void SelectHistory()
        {
            var parameters = new NavigationParameters
            {
                { "history", this }
            };

            await _navigationService.NavigateAsync("HistoryPage", parameters);
        }


    }
}

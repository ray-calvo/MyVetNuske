using Acr.UserDialogs;
using MyVetNuske.Common.Models;
using MyVetNuske.Common.Services;
using Prism.Commands;
using Prism.Navigation;

namespace MyVetNuske.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _loginCommand;


        public LoginPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _apiService = apiService;
            Title = "Login";
            IsEnabled = true;

        }
        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Email { get; set; }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                // ReSharper disable once AccessToStaticMemberViaDerivedType
                await App.Current.MainPage.DisplayAlert("Error", "You must enter an email.", "Accept");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                // ReSharper disable once AccessToStaticMemberViaDerivedType
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a password.", "Accept");
                return;
            }

            UserDialogs.Instance.ShowLoading("Cargando");
            //IsRunning = true;
            IsEnabled = false;

            var request = new TokenRequest
            {
                Password = Password,
                Username = Email
            };

            // ReSharper disable once AccessToStaticMemberViaDerivedType
            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetTokenAsync(url, "/Account", "/CreateToken", request);

            if (!response.IsSuccess)
            {
                IsEnabled = true;
                //IsRunning = false;
                UserDialogs.Instance.HideLoading();
                // ReSharper disable once AccessToStaticMemberViaDerivedType
                await App.Current.MainPage.DisplayAlert("Error", "User or password incorrect.", "Accept");
                Password = string.Empty;
                return;
            }

            var token = (TokenResponse)response.Result;

            var response2 = await _apiService.GetOwnerByEmail(
                url,
                "/api",
                "/Owners/GetOwnerByEmail",
                "bearer",
                token.Token,
                Email);

            // ReSharper disable once UnusedVariable
            var owner = (OwnerResponse)response2.Result;

            IsEnabled = true;
            //IsRunning = false;
            UserDialogs.Instance.HideLoading();

            // ReSharper disable once AccessToStaticMemberViaDerivedType
            await App.Current.MainPage.DisplayAlert("Ok", "We are making progress!", "Accept");
        }
    }

}

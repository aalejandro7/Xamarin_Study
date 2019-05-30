namespace Test.ViewModels
{

    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Services;
    using Views;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.IsRemembered = true;
            this.IsEnabled = true;
            this.Email = "directo@directo.com";
            this.Password = "directo123";
        }
        #endregion

        #region Commands

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "Debes ingresar un email.", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "Debes ingresar una clave.", "Aceptar");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "Valide su conexión a internet.", "Aceptar");
                return;
            }

            var apiSecurity = Application.Current.Resources["ServiceURL"].ToString();
            var token = await this.apiService.GetToken(
                apiSecurity, 
                "/application", 
                "/login", 
                this.Email,
                this.Password);

            if (token == null || string.IsNullOrEmpty(token.AuthToken))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "Usuario o clave incorrecta.", "Aceptar");
                return;
            }

            MainViewModel.GetInstance().TokenResponse = token;

            this.IsRunning = false;
            this.IsEnabled = true;

            MainViewModel.GetInstance().Prospects = new ProspectsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProspectsPage());
            #endregion
        }
    }
}

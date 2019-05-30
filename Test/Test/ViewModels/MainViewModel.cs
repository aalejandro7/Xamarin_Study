namespace Test.ViewModels
{
    using Models;

    public class MainViewModel
    {
        #region Properties
        public LoginViewModel Login { get; set;}

        public ProspectsViewModel Prospects { get; set; }

        public TokenResponse TokenResponse { get; set; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }

            return instance;
        }
        #endregion

        #region Commands

        #endregion
    }
}
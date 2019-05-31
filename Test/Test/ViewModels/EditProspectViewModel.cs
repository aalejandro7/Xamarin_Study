using System.ComponentModel;

namespace Test.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Services;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using Test.Models;
    using Xamarin.Forms;

    public class EditProspectViewModel : BaseViewModel
    {

        #region Attributes
        private ApiService apiService;
        private ObservableCollection<Prospect> prospects;
        private bool isRefreshing;

        #endregion

        #region Properties
        public ObservableCollection<Prospect> Prospects
        {
            get { return this.prospects; }
            set { this.SetValue(ref this.prospects, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public string Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string Telephone
        {
            get;
            set;
        }


        #endregion

        #region Constructors
        public EditProspectViewModel()
        {
            this.Prospects = prospects;
            apiService = new ApiService();

        }
        #endregion

        #region Commands

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(Save);
            }
        }

        async void Save()
        {
            if (string.IsNullOrEmpty(Name))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese Nombre.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Surname))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese apellido.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Telephone))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese teléfono", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Address))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese dirección.", "Aceptar");
                return;
            }

            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();


           
            Surname = Surname;
            Name = Name;
            Address = Address;
            Telephone = Telephone;

            var urlAPI = Application.Current.Resources["ServiceURL"].ToString();

            var response = await apiService.Put(
               urlAPI,
               "/sch",
               "/prospects", mainViewModel.TokenResponse.AuthToken,
               mainViewModel.TokenResponse.AuthToken,
               prospects);

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                                    "Error",
                                    "Ingrese dirección.", "Aceptar");
                return;
            }
        }
        #endregion
    }
}

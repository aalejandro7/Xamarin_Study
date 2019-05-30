using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Test.Models;
using Test.Services;
using Xamarin.Forms;

namespace Test.ViewModels
{
    public class ProspectsViewModel : BaseViewModel
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
        #endregion

        #region Constructors
        public ProspectsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadProspects();
        }
        #endregion

        #region Methods
        private async void LoadProspects()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            var serviceUrl = Application.Current.Resources["ServiceURL"].ToString();
            var response = await this.apiService.GetList<Prospect>(
                serviceUrl,
                "/sch",
                "/prospects.json",
                MainViewModel.GetInstance().TokenResponse.AuthToken);

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            var prospects = (List<Prospect>)response.Result;
            this.Prospects = new ObservableCollection<Prospect>(prospects);
            this.IsRefreshing = false;
        }
        #endregion
    }
}

﻿namespace EmpresisAutos.ViewModels
{
    using Services;
    using Models;
    using Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System.Collections.Generic;

    public class HomeViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private string placa;
        private string cedula;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Placa
        {
            get { return this.placa; }
            set
            {
                SetValue(ref this.placa, value.ToUpper());
            }
        }

        public string Cedula
        {
            get { return this.cedula; }
            set
            {
                SetValue(ref this.cedula, value.ToUpper());
            }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public HomeViewModel()
        {
           
            this.IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand HomeCommand
        {
            get
            {
                return new RelayCommand(Home);
            }
        }

        private async void Home()
        {
            if (string.IsNullOrEmpty(this.Placa))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar una placa.",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Cedula))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar una cédula.",
                    "Aceptar");
                return;
            }

            this.apiService = new ApiService();
            this.LoadPlaques();
            // await Application.Current.MainPage.DisplayAlert("entra", "Todo nice", "ok");

            //MainViewModel.GetInstance().Plaques = new PlaquesViewModel();
            //await Application.Current.MainPage.Navigation.PushAsync(new MenuPage());

        }
        #endregion

        #region Methods
        private async void LoadPlaques()
        {
            this.IsRunning = true;
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }
            // http://200.116.0.43:8090
            var response = await this.apiService.GetList<Plaque>(
                "http://190.128.24.79:8090",
                "/WS_Empresis.asmx",
                string.Format("/GetPlacas?placa={0}&cedula={1}", this.Placa, this.Cedula));

            if (!response.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                
                return;
            }
            var placas = (List<Plaque>)response.Result;
            MainViewModel.GetInstance().PlaqueList = placas[0];
            //this.Plaques = new ObservableCollection<PlaqueItemViewModel>(
            //    this.ToPlaqueItemViewModel());
            this.IsRunning = false;
            this.IsEnabled = true;
            this.Placa = string.Empty;
            //MainViewModel.GetInstance().Plaques = new PlaquesViewModel();
            MainViewModel.GetInstance().Welcome = new WelcomeViewModel();
            MainViewModel.GetInstance().Manteinance = new ManteinanceViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new MenuPage());
        }

        #endregion
    }
}

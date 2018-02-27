namespace EmpresisAutos.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;
    using Xamarin.Forms;

    public class PlaquesViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<PlaqueItemViewModel> plaques;

        private bool isRefreshing;
        private string filter;
        //private List<Plaque> plaquesList;
        #endregion

        #region Properties
        public ObservableCollection<PlaqueItemViewModel> Plaques
        {
            get { return this.plaques; }
            set { SetValue(ref this.plaques, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion

        #region Constructors
        public PlaquesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPlaques();
        }
        #endregion

        #region Methods
        private async void LoadPlaques()
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
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            // http://200.116.0.43:8090
            var response = await this.apiService.GetList<Plaque>(
                "http://192.168.1.7:8090",
                "/WS_Empresis.asmx",
                "/GetPlacas");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            MainViewModel.GetInstance().PlaquesList = (List<Plaque>)response.Result;
            this.Plaques = new ObservableCollection<PlaqueItemViewModel>(
                this.ToPlaqueItemViewModel());
            this.IsRefreshing = false;
        }

        #endregion


        #region Methods
        private IEnumerable<PlaqueItemViewModel> ToPlaqueItemViewModel()
        {
            return MainViewModel.GetInstance().PlaquesList.Select(p => new PlaqueItemViewModel
            {
                Nombrecli = p.Nombrecli,
                Vehiculo = p.Vehiculo,
                Codigocli = p.Codigocli,
                Cilindra = p.Cilindra,
                Colorv = p.Colorv,
                Fecha = p.Fecha,
                Kilometros = p.Kilometros,
                Modelo = p.Modelo,
                MovItems = p.MovItems,
                Nchasis = p.Nchasis,
                Nmotor = p.Nmotor,
                Placa = p.Placa,
                Servicio = p.Servicio,
                Tipo = p.Tipo
            });
        }

        #endregion


        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadPlaques);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Plaques = new ObservableCollection<PlaqueItemViewModel>(
                    this.ToPlaqueItemViewModel());

            }
            else
            {
                this.Plaques = new ObservableCollection<PlaqueItemViewModel>(
                    this.ToPlaqueItemViewModel().Where(
                        p => p.Nombrecli.ToLower().Contains(this.filter.ToLower())
                        || p.Vehiculo.ToLower().Contains(this.filter.ToLower())));

            }
        }

        #endregion
    }
}

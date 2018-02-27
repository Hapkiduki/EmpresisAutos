namespace EmpresisAutos.ViewModels
{
    using EmpresisAutos.Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class HomeViewModel : BaseViewModel
    {
        #region Attributes
        private string placa;
        #endregion

        #region Properties
        public string Placa
        {
            get { return this.placa; }
            set
            {
                SetValue(ref this.placa, value);
            }
        }
        #endregion

        #region Constructors
        public HomeViewModel()
        {
            this.Placa = "123";
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

            // await Application.Current.MainPage.DisplayAlert("entra", "Todo nice", "ok");

            MainViewModel.GetInstance().Plaques = new PlaquesViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MenuPage());

        }



        #endregion
    }
}

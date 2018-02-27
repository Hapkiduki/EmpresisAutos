namespace EmpresisAutos.ViewModels
{
    using EmpresisAutos.Views;
    using GalaSoft.MvvmLight.Command;
    using ViewModels;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class HomeViewModel
    {
        #region Properties

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
            
           // await Application.Current.MainPage.DisplayAlert("entra", "Todo nice", "ok");
            
            MainViewModel.GetInstance().Plaques = new PlaquesViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MenuPage());

        }



        #endregion
    }
}

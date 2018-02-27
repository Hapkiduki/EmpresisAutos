namespace EmpresisAutos.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class PlaqueItemViewModel : Plaque
    {
        #region Commands
        public ICommand SelectPlaqueCommand
        {
            get
            {
                return new RelayCommand(SelectPlaque);
            }
        }

        private async void SelectPlaque()
        {
            await Application.Current.MainPage.DisplayAlert("Información",string.Format("Bienvenido {0}", this.Nombrecli),"ok");
            MainViewModel.GetInstance().Plaque = new PlaqueViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new PlaquesPage());
        }
        #endregion
    }
}

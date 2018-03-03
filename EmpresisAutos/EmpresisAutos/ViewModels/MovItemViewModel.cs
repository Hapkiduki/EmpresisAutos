namespace EmpresisAutos.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class MovItemViewModel : MovItem
    {
        #region Commands
        public ICommand SelectItemCommand
        {
            get { return new RelayCommand(LoadMovItem); }
        }


        #endregion

        #region Methods
        private async void LoadMovItem()
        {
            var list = MainViewModel.GetInstance().PlaqueList.
                MovItems.Where(i => i.Orden.Equals(this.Orden)).ToList();
            
            var data = new ObservableCollection<MovItem>(list);
            MainViewModel.GetInstance().Manteinance = new ManteinanceViewModel(data);
            await Application.Current.MainPage.Navigation.PushAsync(new ManteinancePage());
        }
        #endregion
    }
}

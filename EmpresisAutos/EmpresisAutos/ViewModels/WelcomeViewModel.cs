namespace EmpresisAutos.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    public class WelcomeViewModel : BaseViewModel
    {
        #region Attributes
        private Plaque plaque;
        private ObservableCollection<MovItemViewModel> items;
        private string filter;
        #endregion

        #region Properties
        public Plaque Plaque
        {
            get { return this.plaque; }
            set
            {
                SetValue(ref this.plaque, value);
            }
        }

        public ObservableCollection<MovItemViewModel> Items
        {
            get { return this.items; }
            set { this.SetValue(ref this.items, value); }
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
        public WelcomeViewModel()
        {
            this.Plaque = MainViewModel.GetInstance().PlaqueList;
            this.Items = new ObservableCollection<MovItemViewModel>(this.GetDatos());


        }


        #endregion

        #region Methods

        private IEnumerable<MovItemViewModel> GetDatos()
        {
            return MainViewModel.GetInstance().PlaqueList.MovItems
                  .GroupBy(i => i.Orden)
                  .Select(mi => new MovItemViewModel
                  {
                      Numfactu = mi.First().Numfactu,
                      FechaEnt = mi.First().FechaEnt,
                      Cantidad = mi.First().Cantidad,
                      Dcto = mi.First().Dcto,
                      Estado = mi.First().Estado,
                      Iva = mi.First().Iva,
                      Nameref = mi.First().Nameref,
                      Observa = mi.First().Observa,
                      Orden = mi.First().Orden,
                      Referencia = mi.First().Referencia,
                      Tasaiva = mi.First().Tasaiva,
                      Tdes1 = mi.First().Tdes1,
                      Total = mi.First().Total,
                      Valdes = mi.First().Valdes,
                      Valiva = mi.First().Valiva,
                      Valor = mi.First().Valor,
                      Valsubtot = mi.First().Valsubtot,
                      Valtotal = this.SumTotal(this.Plaque.MovItems.Where(x => x.Orden == mi.First().Orden))
                  })
                  .ToList();
        }

        private int SumTotal(IEnumerable<MovItem> items)
        {
            var total = 0;
            foreach (var item in items)
            {
                total += item.Total;
            }

            return total;
        }

        private async void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Items = new ObservableCollection<MovItemViewModel>(
                    this.GetDatos());

            }
            else
            {
                this.Items = new ObservableCollection<MovItemViewModel>(
                    this.GetDatos().Where(
                        i => i.Numfactu.ToLower().Contains(this.Filter.ToLower())
                        || i.FechaEnt.ToString().Contains(string.Format("{0:s}", this.Filter))));

            }
        }
        #endregion

        #region Commands
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        #endregion
    }
}

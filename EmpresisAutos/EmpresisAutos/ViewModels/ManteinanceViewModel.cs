namespace EmpresisAutos.ViewModels
{
    using Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class ManteinanceViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<MovItem> item_first;
        private double sumtotal;
        #endregion

        #region Properties

        public ObservableCollection<MovItem> Item_first
        {
            get { return this.item_first; }
            set { this.SetValue(ref this.item_first, value); }
        }

        public double Sumtotal { get; set; }
        #endregion


        #region Constructors
        public ManteinanceViewModel()
        {
            var indicador = MainViewModel.GetInstance().PlaqueList.
                MovItems.GroupBy(i => i.Orden).ToList();
            var otro = indicador[0];

            this.Item_first = new ObservableCollection<MovItem>(otro);
            SumTotalItems(this.Item_first);
        }

        public ManteinanceViewModel(ObservableCollection<MovItem> items)
        {
            this.Item_first = items;
            SumTotalItems(this.Item_first);
        }
        #endregion


        #region Methods

        private void SumTotalItems(ObservableCollection<MovItem> item_first)
        {
            foreach (var item in item_first)
            {
                this.Sumtotal += item.Total;
            }
        } 
        #endregion
    }
}

namespace EmpresisAutos.ViewModels
{
    using Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class WelcomeViewModel : BaseViewModel
    {
        #region Attributes
        private Plaque plaque;
        private ObservableCollection<MovItem> items;
        private ObservableCollection<MovItem> item_first;
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

        public ObservableCollection<MovItem> Items
        {
            get { return this.items; }
            set { this.SetValue(ref this.items, value); }
        }

        public ObservableCollection<MovItem> Item_first
        {
            get { return this.item_first; }
            set { this.SetValue(ref this.item_first, value); }
        }
        #endregion

        #region Constructors
        public WelcomeViewModel()
        {
            this.Plaque = MainViewModel.GetInstance().PlaqueList;
            
            List<MovItem> datos = this.plaque.MovItems
                 .GroupBy(i => i.Orden)
                 .Select(mi => mi.First())
                 .ToList();
            var indicador = this.plaque.MovItems.GroupBy(i => i.Orden).ToList();
            var otro = indicador[0];
        
            this.Item_first = new ObservableCollection<MovItem>(otro);
            this.Items = new ObservableCollection<MovItem>(datos);


        }
        #endregion

        #region Methods


        #endregion
    }
}

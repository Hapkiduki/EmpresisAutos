namespace EmpresisAutos.ViewModels
{
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class WelcomeViewModel : BaseViewModel
    {
        #region Attributes
        private Plaque plaque;
        private ObservableCollection<MovItem> items;
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
        #endregion

        #region Constructors
        public WelcomeViewModel()
        {
            this.Plaque = MainViewModel.GetInstance().PlaqueList;
                       
            this.Items = new ObservableCollection<MovItem>(this.Plaque.MovItems);
        }
        #endregion

        #region Methods


        #endregion
    }
}

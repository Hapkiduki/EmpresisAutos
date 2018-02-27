namespace EmpresisAutos.ViewModels
{
    using Models;
    using System.Collections.ObjectModel;

    public class PlaqueViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<MovItem> items;
        #endregion

        #region Properties
        public ObservableCollection<MovItem> Items
        {
            get { return this.items; }
            set { this.SetValue(ref this.items, value); }
        }
        #endregion

        #region Properties
        public Plaque Plaque
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public PlaqueViewModel(Plaque plaque)
        {
            this.Plaque = plaque;
            this.items = new ObservableCollection<MovItem>(this.Plaque.MovItems);
        }
        #endregion
    }
}

namespace EmpresisAutos.ViewModels
{
    using Models;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class ManteinanceViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<MovItem> item_first;
        //private ManteinanceViewModel data;
        #endregion

        #region Properties

        public ObservableCollection<MovItem> Item_first
        {
            get { return this.item_first; }
            set { this.SetValue(ref this.item_first, value); }
        }
        #endregion


        #region Constructors
        public ManteinanceViewModel()
        {
            var indicador = MainViewModel.GetInstance().PlaqueList.
                MovItems.GroupBy(i => i.Orden).ToList();
            var otro = indicador[0];

            this.Item_first = new ObservableCollection<MovItem>(otro);
        }

        public ManteinanceViewModel(ObservableCollection<MovItem> items)
        {
            this.Item_first = items;
        }
        #endregion
    }
}

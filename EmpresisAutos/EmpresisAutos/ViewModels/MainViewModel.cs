namespace EmpresisAutos.ViewModels
{
    using Models;
    using System.Collections.Generic;

    public class MainViewModel
    {
        #region Properties
        public List<Plaque> PlaquesList { get; set; }
        #endregion

        #region ViewModels
        public HomeViewModel Home
        {
            get;
            set;
        }

        public PlaquesViewModel Plaques
        {
            get;
            set;
        }

        public PlaqueViewModel Plaque
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Home = new HomeViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}

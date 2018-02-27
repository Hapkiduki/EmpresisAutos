namespace EmpresisAutos
{
    using EmpresisAutos.Views;
    using Xamarin.Forms;

    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            //NavigationPage.SetHideNavigationBar(mynavigationpage, true);
            //MainPage = new MainPage();
            MainPage = new NavigationPage( new HomePage());

        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

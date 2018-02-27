namespace EmpresisAutos.Infrastructure
{
    using EmpresisAutos.ViewModels;

    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}

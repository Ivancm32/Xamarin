namespace UIForms.Infrastructure
{
    using UIForms.ViewModel;
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }


        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}

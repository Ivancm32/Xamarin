namespace Shop.UIForms.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel Instance;
        public LoginViewModel Login { get; set; }

        public ProductViewModel Product { get; set; }

        public MainViewModel()
        {
            Instance = this;
        }

        public static MainViewModel GetInstance()
        {
            if (Instance == null)
            {
                return new MainViewModel();
            }
            return Instance;
        }

    }
}

namespace Shop.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Shop.UIForms.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand => new RelayCommand(Login);

        public LoginViewModel()
        {
            this.Email = "Icastro@tas-seguridad.com";
            this.Password = "Ivancm32";
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Usted debe de ingresar un Email", "Aceptar");
                return;

            }

            if (string.IsNullOrEmpty(this.Password))
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Usted debe de ingresar un Password", "Aceptar");
                return;

            }

            if (!this.Email.Equals("Icastro@tas-seguridad.com") || !this.Password.Equals("Ivancm32"))
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Usuario o Password Incorrecto", "Aceptar");
                return;

            }
            MainViewModel.GetInstance().Product = new ProductViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductPage());
            //await Application.Current.MainPage.DisplayAlert("OK", "Listo", "Aceptar");
            return;
        }
    }
}

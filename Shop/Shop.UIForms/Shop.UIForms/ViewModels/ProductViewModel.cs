namespace Shop.UIForms.ViewModels
{
    using Shop.Common.Models;
    using Shop.Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ProductViewModel : BaseViewModel
    {
        private readonly APIService apiService;
        private ObservableCollection<Productos> product;

        public ObservableCollection<Productos> Product
        {
            get { return this.product; }

            set { this.SetValue(ref this.product, value); }
        }

        public ProductViewModel()
        {
            this.apiService = new APIService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            var response = await this.apiService.GetListAsync<Productos>(
                "http://186.159.159.78:82/Xamarin/",
                "API/",
                "Productos");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }
            var myProducts = (List<Productos>)response.Result;
            this.Product = new ObservableCollection<Productos>(myProducts);
        }
    }
}

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
        private bool isRefreshing;
        public ObservableCollection<Productos> Product
        {
            get => this.product;

            set => this.SetValue(ref this.product, value);
        }

        public bool IsRefreshing
        {
            get => this.isRefreshing;

            set => this.SetValue(ref this.isRefreshing, value);
        }

        public ProductViewModel()
        {
            this.IsRefreshing = true;
            this.apiService = new APIService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            var response = await this.apiService.GetListAsync<Productos>(
                "http://186.159.159.78:82/Xamarin/",
                "API/",
                "Productos");

            this.IsRefreshing = false;
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

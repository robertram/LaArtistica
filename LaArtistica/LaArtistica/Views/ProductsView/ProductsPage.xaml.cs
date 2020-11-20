using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LaArtistica.Models;

namespace LaArtistica.Views.ProductsView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage()
        {
            InitializeComponent();
            List<Products> products = UserRepository.Instancia.GetAllProducts().ToList();

            var allNotes = UserRepository.Instancia.GetAllProducts();
            listView.ItemsSource = allNotes;

        }

        async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var index = e.Item as Products;
            if (index != null)
            {
                bool buy = await DisplayAlert("Producto elegido", "Producto: " + index.Nombre + "\nPrecio: " + index.Precio + "\nGarantias por mes: " + index.GarantiaMeses +
                     "\nEn stock: " + index.Stock, "Comprar", "Cancelar");

                if (buy == true)
                {
                    //((NavigationPage)this.Parent).PushAsync(new CheckOutPage());
                    Application.Current.MainPage = new CheckOutPage();
                }
                else
                {
                   await DisplayAlert("La Artística", "Compra cancelada", "Aceptar");
                }
            }
        }

        
    }
}
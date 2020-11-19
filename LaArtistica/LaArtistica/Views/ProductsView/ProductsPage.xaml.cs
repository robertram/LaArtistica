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
            //ProductsRepository.Instancia.AddNewProduct("Mueble", "4", "10.000", "2", "");
            UserRepository.Instancia.AddNewUser("robert@gmail.com", "1234");
            UserRepository.Instancia.AddNewProduct("Mueble", "4", "10.000", "2", "");
            //ProductsRepository.Instancia.AddNewProduct("Mesa", "4", "30.000", "2", "");
            //ProductsRepository.Instancia.AddNewProduct("Cama", "4", "100.000", "2", "");
            //ProductsRepository.Instancia.AddNewProduct("Escritorio", "4", "50.000", "2", "");
            List<Products> products = UserRepository.Instancia.GetAllProducts().ToList();
            //var products = UserRepository.Instancia.GetAllProducts();

            //this.BindingContext = products;
            //listView.ItemsSource = products;


            var allNotes = UserRepository.Instancia.GetAllProducts();
            listView.ItemsSource = allNotes;

        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Object product = e.Item;
            await DisplayAlert("La Artistica", "{product} ", "Aceptar");
        }
    }
}
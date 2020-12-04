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
    public partial class Wishlist : ContentPage
    {
        private User currentUser;
        private Products currentProduct;
        public Wishlist(User u)
        {
            InitializeComponent();
            currentUser = u;
            //List<Wishlist> wishlist = UserRepository.Instancia.GetAllWishes(Convert.ToInt32(clientList.Text)).ToList();
            var allNotes = UserRepository.Instancia.GetAllUsersWishes2();
            listViewWish.ItemsSource = allNotes;
        }

        async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var index = e.Item as Products;
            if (index != null)
            {
                bool buy = await DisplayAlert("Producto elegido", "Producto: " + index.Nombre + "\nPrecio: " + index.Precio + "\nGarantias por mes: " + index.GarantiaMeses +
                    "\nEn stock: " + index.Stock, "Comprar", "Eliminar");

                if (buy == true)
                {
                    //((NavigationPage)this.Parent).PushAsync(new CheckOutPage());
                    Application.Current.MainPage = new CheckOutPage(currentUser,index);
                }
                else
                {
                    UserRepository.Instancia.DeleteWish(index.Nombre);
                }
            }
        }

        //public string wish()
        //{
        //    get
        //    {
        //        return this.clientList.Text;
        //    }
        //    set
        //    {
        //        this.clientList.Text = value;
        //    }
        //}
    }
}
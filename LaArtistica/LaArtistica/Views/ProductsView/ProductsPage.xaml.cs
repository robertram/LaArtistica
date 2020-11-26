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
        int res = 0;
        public ProductsPage()
        {
            InitializeComponent();
            List<Products> products = UserRepository.Instancia.GetAllProducts().ToList();

            var allNotes = UserRepository.Instancia.GetAllProducts();
            listView.ItemsSource = allNotes;

            ToolbarItems.Add(new ToolbarItem("WishList", "wishlist.png", async () =>
            {
                await ((NavigationPage)this.Parent).PushAsync(new Wishlist());
            }));

            ToolbarItems.Add(new ToolbarItem("LogOut", "CerrarSesion.png", async () =>
            {
                await DisplayAlert("La Artística", "Cerrando sesion", "Aceptar");
                Application.Current.MainPage = new AccessView.LoginPage();
            }));

            txtUser.Text = Name;


        }

        async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var index = e.Item as Products;
            if (index != null)
            {
                bool wish = await DisplayAlert("Producto elegido", "Producto: " + index.Nombre + "\nPrecio: " + index.Precio + "\nGarantias por mes: " + index.GarantiaMeses +
                     "\nEn stock: " + index.Stock, "Wishlist", "Cancelar");
                if (wish)
                {
                    List<User> activeUser = UserRepository.Instancia.GetAllUsers().ToList();
                    foreach (User activeU in activeUser)
                    {
                        
                        if (Name.Equals(activeU.Username))
                        {
                           res = activeU.Id;
                        }
                    }
                    UserRepository.Instancia.AddtoWishlist(index.Nombre,res, index.Stock, index.Precio, index.GarantiaMeses, index.Stock);
                    await DisplayAlert("La Artística", "Producto agregado al Wishlist!", "Aceptar");
                }
                else
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

        public string Name
        {
            get
            {
                return this.txtUser.Text;
            }
            set
            {
                this.txtUser.Text = value;
            }
        }


    }
}
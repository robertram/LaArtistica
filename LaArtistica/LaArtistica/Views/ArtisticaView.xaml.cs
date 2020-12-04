using System;
using LaArtistica.Models;
using LaArtistica.ViewModel;
using Xamarin.Forms;
using LaArtistica.Views;
using LaArtistica.Views.ProductsView;

namespace LaArtistica.Views
{
    public partial class ArtisticaView : ContentPage
    {
        User currentUser;
        public ArtisticaView(User u)
        {
            InitializeComponent();
            currentUser = u;
            BindingContext = new ProductViewModel();
            ToolbarItems.Add(new ToolbarItem("WishList", "wishlist.png", async () =>
            {
                await ((NavigationPage)this.Parent).PushAsync(new ReportsPage());
            }));
            ToolbarItems.Add(new ToolbarItem("LogOut", "CerrarSesion.png", async () =>
            {
                bool x = await DisplayAlert("La Artística", "Desea cerrar sesión?", "Aceptar", "Cancelar");
                if (x)
                {
                    Application.Current.MainPage = new AccessView.LoginPage();
                }
                
            }));

            txtUser.Text = Name;
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
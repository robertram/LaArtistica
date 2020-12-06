using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaArtistica.Models;
using LaArtistica.ViewModel;
using LaArtistica.Views.AccessView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaArtistica.Views.ProductsView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        User currentUser;
        public List<MiMenu> MiMenu { get; set; }
        public Menu(User u)
        {
            InitializeComponent();
            currentUser = u;
            MiMenu = new List<MiMenu>();
            MiMenu pag1 = new MiMenu() { titulo = "Reportes", Pagina = typeof(ReportsPage), detail = "Reportes", image = "wishlist.png" };
            MiMenu.Add(pag1);
            MiMenu pag2 = new MiMenu() { titulo = "Productos", Pagina = typeof(ArtisticaView), detail = "Productos", image = "productos.png" };
            MiMenu.Add(pag2);
            MiMenu pag3 = new MiMenu() { titulo = "Logout", Pagina = typeof(LoginPage), detail = "Cerrar Session", image = "CerrarSesion.png" };
            MiMenu.Add(pag3);

            this.ListMenu.ItemsSource = MiMenu;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ArtisticaView)))
            {
                BarBackgroundColor = Color.FromHex("#CC1921")
            };
            this.ListMenu.ItemSelected += ListMenu_ItemSelected1;
        }

        private async void ListMenu_ItemSelected1(object sender, SelectedItemChangedEventArgs e)
        {
            MiMenu pagina = e.SelectedItem as MiMenu;
            if (pagina.detail.Equals("Cerrar Session"))
            {
                bool x = await DisplayAlert("La Artística", "Desea cerrar sesión?", "Aceptar", "Cancelar");
                if (x)
                {
                    IsGestureEnabled = false;
                    Application.Current.MainPage = new LoginPage();
                }
            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(pagina.Pagina)) { BarBackgroundColor = Color.Red };
                IsPresented = false;
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
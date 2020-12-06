using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LaArtistica.Views.ProductsView;
using LaArtistica.Models;
using LaArtistica.ViewModel;
using LaArtistica.Views.AccessView;

namespace LaArtistica.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailView : ContentPage
    {
        ProductViewModel pvm; 
        private Products p;
        public ProductDetailView()
        {
            InitializeComponent();
            pvm = new ProductViewModel();
            p = pvm.SelectedProduct;
            btnComprar.Clicked += BtnComprar_Clicked;
        }

        private void BtnComprar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCantidad.Text))
            {
                try
                {
                    User u = LoginPage.LogedUser;
                    ((NavigationPage)this.Parent).PushAsync(new CheckOutPage(u, p, Int32.Parse(txtCantidad.Text)));
                }
                catch
                {
                    
                }

            }
            else
            {
                cantidadAusente();
            }
            
        }

        private async Task cantidadAusente()
        {
            await DisplayAlert("La Artistica", "Indique la cantidad de productos que desea", "Aceptar");
        }
    }
}
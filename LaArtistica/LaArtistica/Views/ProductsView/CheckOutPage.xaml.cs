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
    public partial class CheckOutPage : ContentPage
    {
        public CheckOutPage()
        {
            InitializeComponent();
            btnBuy.Clicked += BtnBuy_Clicked;
            btnCancel.Clicked += BtnCancel_Clicked;
        }

        async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Message", "Your buy has been cancelled", "Ok");
            Application.Current.MainPage = new ProductsPage();
        }

        async void BtnBuy_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtCedula.Text) || !string.IsNullOrEmpty(txtEmail.Text)
            || !string.IsNullOrEmpty(txtNumeroC.Text) || !string.IsNullOrEmpty(txtDireccion.Text) || !string.IsNullOrEmpty(txtCVV.Text))
            {
                if (!string.IsNullOrEmpty(picker.ToString()))
                {
                    await DisplayAlert("Thank You", "You've bought your product!!", "Ok");
                    Application.Current.MainPage = new ProductsPage();
                }
                else
                {
                    cardSelectAlert();
                }
                    
                
            }
            else
            {
                noDataAlert();
            }
            
        }

        private async Task noDataAlert()
        {
            await DisplayAlert("La Artistica", "Por favor introduzca todos los datos", "Aceptar");
        }

        private async Task cardSelectAlert()
        {
            await DisplayAlert("La Artistica", "Por favor introduzca una tarjeta valida", "Aceptar");
        }
    }
}
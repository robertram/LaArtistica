using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LaArtistica.Models;
using Xamarin.Essentials;

namespace LaArtistica.Views.ProductsView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckOutPage : ContentPage
    {
        private User currentUser;
        private Products currentProduct;
        public CheckOutPage(User u, Products p)
        {
            InitializeComponent();
            currentUser = u;
            currentProduct = p;
            txtEmail.Text = currentUser.Email;
            btnBuy.Clicked += BtnBuy_Clicked;
            btnCancel.Clicked += BtnCancel_Clicked;
        }

        async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("La Artística", "Tu compra ha sido cancelada", "Aceptar");
            Application.Current.MainPage = new NavigationPage(new ProductsPage(currentUser));
        }

        async void BtnBuy_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtCedula.Text) || !string.IsNullOrEmpty(txtEmail.Text)
            || !string.IsNullOrEmpty(txtNumeroC.Text) || !string.IsNullOrEmpty(txtDireccion.Text) || !string.IsNullOrEmpty(txtCVV.Text))
            {
                if (!string.IsNullOrEmpty(picker.ToString()))
                {
                    await DisplayAlert("La Artística", "Has comprado el producto", "Aceptar");
                    sendEmail(currentUser, currentProduct);
                    Application.Current.MainPage = new NavigationPage(new ProductsPage(currentUser));
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

        private void sendEmail(User u, Products p)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("laartisticaulacit@gmail.com");
                mail.To.Add(u.Email);
                mail.Subject = "Confirmacion de compra La Artistica";
                mail.Body = "Gracias por comprar en La Artistica \nA continuacion los detalles de su compra: \n" +
                    "Producto: " + p.Nombre + "\nPrecio: " + p.Precio;

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("laartisticaulacit@gmail.com", "Ulacit2020");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                DisplayAlert("Faild", ex.Message, "OK");
            }
        }


        private async Task noDataAlert()
        {
            await DisplayAlert("La Artistica", "Por favor introduzca todos los datos", "Aceptar");
        }

        private async Task cardSelectAlert()
        {
            await DisplayAlert("La Artistica", "Por favor introduzca una tarjeta válida", "Aceptar");
        }
    }
}
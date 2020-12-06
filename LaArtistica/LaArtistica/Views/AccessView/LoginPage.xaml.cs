using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Linq;
using LaArtistica.Models;
using LaArtistica.Views.ProductsView;

namespace LaArtistica.Views.AccessView
{
    public partial class LoginPage : ContentPage
    {

        public static User LogedUser;
        public static Products ProductToBuy;
        public LoginPage()
        {
            InitializeComponent();
            btnLogIn.Clicked += BtnLogIn_Clicked;
            btnSingUp.Clicked += BtnSingUp_Clicked;
            forgotPass.Clicked += ForgotPass_Clicked;
        }

        private void ForgotPass_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new ForgotPassword());
        }

        private void BtnSingUp_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new RegisterPage());
        }

        private void BtnLogIn_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                bool isRegistered = false;
                bool canLogin = false;
                List<User> users = UserRepository.Instancia.GetAllUsers().ToList();
                User currentUser = null;
                foreach (User u in users)
                {
                    if (txtEmail.Text.Equals(u.Email))
                    {
                        isRegistered = true;
                        if (txtPassword.Text.Equals(u.Password))
                        {
                            canLogin = true;
                            currentUser = u;
                            LogedUser = currentUser;
                        }
                    }
                }
                if (isRegistered)
                {
                    if (canLogin)
                    {
                        //((NavigationPage)this.Parent).PushAsync(new ProductsPage());
                        ProductsView.Menu myUser = new ProductsView.Menu(currentUser);
                        List<User> activeUser = UserRepository.Instancia.GetAllUsers().ToList();
                        foreach(User activeU in activeUser)
                        {
                            if (txtEmail.Text.Equals(activeU.Email))
                            {
                                myUser.Name = activeU.Username;
                            }
                        }
                        DisplayAlert("La Artistica", "Bienvenido: " + myUser.Name, "Ok");
                        Application.Current.MainPage = new NavigationPage(new ProductsView.Menu(currentUser));

                    }
                    else
                    {
                        wrongPassword();
                    }
                }
                else
                {
                    noEmailRegistered();
                }
            }
            else{
                noDataAlert();
            }
        }

        

        private async Task noEmailRegistered()
        {
            await DisplayAlert("La Artistica", "Este correo no está registrado", "Aceptar");
        }

        private async Task wrongPassword()
        {
            await DisplayAlert("La Artistica", "Contraseña incorrecta", "Aceptar");
        }

        private async Task noDataAlert()
        {
            await DisplayAlert("La Artistica", "Por favor introduzca un correo y una contraseña", "Aceptar");
        }
    }
}

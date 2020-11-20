﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Linq;
using LaArtistica.Models;
using LaArtistica.Views.ProductsView;
using LaArtistica.Models;

namespace LaArtistica.Views.AccessView
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            btnLogIn.Clicked += BtnLogIn_Clicked;
            btnSingUp.Clicked += BtnSingUp_Clicked;
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
                foreach (User u in users)
                {
                    if (txtEmail.Text.Equals(u.Email))
                    {
                        isRegistered = true;
                        if (txtPassword.Text.Equals(u.Password))
                        {
                            canLogin = true;
                        }
                    }
                }
                if (isRegistered)
                {
                    if (canLogin)
                    {
                        //((NavigationPage)this.Parent).PushAsync(new Page());
                        Application.Current.MainPage = new ProductsPage();
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

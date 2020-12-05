﻿using System;
using LaArtistica.Views.AccessView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LaArtistica.Models;
using System.Linq;

using System.Collections.Generic;
using LaArtistica.Views;
using LaArtistica.Views.ProductsView;

namespace LaArtistica
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();
            UserRepository.Inicializador(filename);
            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new NavigationPage(new ArtisticaView());


            List<Products> products = UserRepository.Instancia.GetAllProducts().ToList();

            if (products.Count()> 0)
            {
               /* foreach (Products p in products)
                {
                    UserRepository.Instancia.DeleteProduct(p);
                } */
            }
            else
            {
                UserRepository.Instancia.AddNewProduct("Sillon Cafe", "14", "45.000", "2", "Sillon.png", "https://drive.google.com/file/d/15nSaE3VYS2IG4E82R2snKmYiVT1e7Gvk/view?usp=sharing");
                UserRepository.Instancia.AddNewProduct("Escritorio", "5", "75.000", "2", "Escritorio.png", "https://drive.google.com/file/d/1zcVH7kM_iLQBnKxYWJtxZr9K2mWoyZVZ/view?usp=sharing");
                UserRepository.Instancia.AddNewProduct("Sillon", "5", "75.000", "2", "Sillon.png", "https://drive.google.com/file/d/15nSaE3VYS2IG4E82R2snKmYiVT1e7Gvk/view?usp=sharing");
                UserRepository.Instancia.AddNewProduct("Sillon Casual", "5", "75.000", "2", "SillonCasual.png", "https://drive.google.com/file/d/1l4wlYtik1z9B9wypORq7mDjurHFgIEi1/view?usp=sharing");
                UserRepository.Instancia.AddNewProduct("Sillon Grande", "5", "75.000", "2", "SillonGrande.png", "https://drive.google.com/file/d/10z-aM-UhOfjra3m-b0SReRtdTFe4xT_f/view?usp=sharing");
                UserRepository.Instancia.AddNewProduct("Sillon Rojo", "5", "75.000", "2", "SillonRojo.png", "https://drive.google.com/file/d/1cOaO50MC4cC7Sk4NouryCnBgSwO8IZ0W/view?usp=sharing");
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

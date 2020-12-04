using System;
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
            MainPage = new NavigationPage(new ReportsPage());
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
                UserRepository.Instancia.AddNewProduct("Sillon Cafe", "14", "45.000", "2", "Sillon.png");
                UserRepository.Instancia.AddNewProduct("Escritorio", "5", "75.000", "2", "Escritorio.png");
                UserRepository.Instancia.AddNewProduct("Sillon", "5", "75.000", "2", "Sillon.png");
                UserRepository.Instancia.AddNewProduct("Sillon Casual", "5", "75.000", "2", "SillonCasual.png");
                UserRepository.Instancia.AddNewProduct("Sillon Grande", "5", "75.000", "2", "SillonGrande.png");
                UserRepository.Instancia.AddNewProduct("Sillon Rojo", "5", "75.000", "2", "SillonRojo.png");
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

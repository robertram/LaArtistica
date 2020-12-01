using System;
using System.Collections.Generic;
using System.Text;

using LaArtistica.Services;
using LaArtistica.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;


namespace LaArtistica.ViewModel
{
    public class ProductViewModel
    {
        //public ObservableCollection<Products> _products;

        public ProductViewModel()
        {
            //LoadData();
        }
        /*public ObservableCollection<Products> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        
        }*/
        private void LoadData()
        {
            //Products = new ObservableCollection<Products>(ProductoService.Instance.GetProducts());
        }

    }
}

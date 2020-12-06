using LaArtistica.Models;
using LaArtistica.Services;
using LaArtistica.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using LaArtistica.Views.AccessView;

namespace LaArtistica.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        private ObservableCollection<Products> _products;
        private Products _selectedProduct;

        public ProductViewModel()
        {
            LoadData();
        }
        public Products SelectedProduct
        {
            get {
                //este if hace que el producto estatico nunca pase de su valor real a null, permitiendo mandar el correo al hacer la compra una etapa futura del programa
                //este es un metodo de prevencion 100% efectivo, innovador y nunca antes visto
                if(_selectedProduct != null)
                {
                    LoginPage.ProductToBuy = _selectedProduct;
                }
                
                return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Products> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectCommand => new Command(NavigateToProductDetail);
        public void LoadData()
        {
            Products = new ObservableCollection<Products>(ProductService.Instance.GetProducts());
        }

        public void NavigateToProductDetail()
        {
            Console.WriteLine("Adios " + SelectedProduct);
            NavigationService.Instance.NavigateToAsync<ProductDetailViewModel>(SelectedProduct);
        }
    }
}




using LaArtistica.Models;
using LaArtistica.Services;
using LaArtistica.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;


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
            get { return _selectedProduct; }
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
            NavigationService.Instance.NavigateToAsync<ProductDetailViewModel>(SelectedProduct);
        }
    }
}




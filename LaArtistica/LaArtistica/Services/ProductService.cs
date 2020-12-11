using LaArtistica.Models;

using System.Collections.Generic;


namespace LaArtistica.Services
{
    public class ProductService
    {
        public static ProductService _instance;

        public static ProductService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProductService();
                return _instance;
            }
        }

        public List<Products> GetProducts()
        {
            UserRepository.Instancia.AddNewProduct(1,"Sofá Enderlin Ink", "100", "860", "12", "A brilliant take on urban chic styling, this loveseat in vibrant blue makes high design highly affordable. Distinctive elements include quilted channel stitching for clean-lined allure and a velvety soft fabric you'll love living with. Sculptural track arms up the wow factor. If you're looking for big style on more modest scale, you're sure to appreciate this loveseat's space-conscious 59 wide profile.", "blue.jpg", "https://mintl.rencdn.com/product/ashley/images/24403-08-ANGLE-SW-P1-KO.jpg");
            UserRepository.Instancia.AddNewProduct(2,"Maimz Loveseat", "100", "880", "12", "his designer loveseat is mid-century revival done to perfection. Linear and minimalistic, the beautifully edited profile has all the retro elements you love, like sheltering arms, bolster pillows and tapered splayed legs. So casually cool, the caramel faux leather upholstery brings the look right into the present.", "blue.jpg", "https://mintl.rencdn.com/product/ashley/images/A3000174-SW-P1-KO.jpg");
            UserRepository.Instancia.AddNewProduct(3,"Sofá RTA Macleary", "100", "750", "12", "Ponte cómodo con una estética moderna cuando agregues este sofá de dos puestos a tu casa u oficina. Un diseño limpio y lineal se adapta muy bien a cualquier espacio sofisticado. Con tapicería de terciopelo y una elegante pata metálica, esta pieza eleva tu decoración a la última moda.", "blue.jpg", "https://mintl.rencdn.com/product/ashley/images/36232-60-SW-P1-KO.jpg");
            UserRepository.Instancia.AddNewProduct(4,"Sofá Navi Smoke", "100", "730", "12", "If you love the cool look of leather but long for the warm feel of fabric, you can take comfort in this loveseat. Wrapped in a fabulous faux leather with a weathered hue and hint of pebbly texture to resemble the real deal, this decidedly modern loveseat proves less is more. Elements include angled side profiling and track armrests wrapped with a layer of pillowy softness for that little something extra. Prominent jumbo stitching and clean-lined divided back styling lend fashion-forward flair.", "blue.jpg", "https://mintl.rencdn.com/product/ashley/images/19803-35-ANGLE-SW-P1-KO.jpg");
            return new List<Products>
            {
                new Products{ Id = 1, Nombre = "Sofá Enderlin Ink", Imagen = "blue.jpg", Precio = "860", Descripcion = "A brilliant take on urban chic styling, this loveseat in vibrant blue makes high design highly affordable. Distinctive elements include quilted channel stitching for clean-lined allure and a velvety soft fabric you'll love living with. Sculptural track arms up the wow factor. If you're looking for big style on more modest scale, you're sure to appreciate this loveseat's space-conscious 59 wide profile.", ImagenUrl = "https://mintl.rencdn.com/product/ashley/images/24403-08-ANGLE-SW-P1-KO.jpg"},
                new Products{ Id = 2, Nombre = "Maimz Loveseat", Imagen = "orange.jpg", Precio = "880", Descripcion = "his designer loveseat is mid-century revival done to perfection. Linear and minimalistic, the beautifully edited profile has all the retro elements you love, like sheltering arms, bolster pillows and tapered splayed legs. So casually cool, the caramel faux leather upholstery brings the look right into the present.", ImagenUrl = "https://mintl.rencdn.com/product/ashley/images/A3000174-SW-P1-KO.jpg" },
                new Products{ Id = 3, Nombre = "Sofá RTA Macleary", Imagen = "blue.jpg", Precio = "750", Descripcion = "Ponte cómodo con una estética moderna cuando agregues este sofá de dos puestos a tu casa u oficina. Un diseño limpio y lineal se adapta muy bien a cualquier espacio sofisticado. Con tapicería de terciopelo y una elegante pata metálica, esta pieza eleva tu decoración a la última moda.", ImagenUrl = "https://mintl.rencdn.com/product/ashley/images/36232-60-SW-P1-KO.jpg" },
                new Products{ Id = 4, Nombre = "Sofá Navi Smoke", Imagen = "dark.jpg", Precio = "730", Descripcion = "If you love the cool look of leather but long for the warm feel of fabric, you can take comfort in this loveseat. Wrapped in a fabulous faux leather with a weathered hue and hint of pebbly texture to resemble the real deal, this decidedly modern loveseat proves less is more. Elements include angled side profiling and track armrests wrapped with a layer of pillowy softness for that little something extra. Prominent jumbo stitching and clean-lined divided back styling lend fashion-forward flair.", ImagenUrl = "https://mintl.rencdn.com/product/ashley/images/19803-35-ANGLE-SW-P1-KO.jpg" },

            };
        }
    }
}

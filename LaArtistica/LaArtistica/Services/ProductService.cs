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
            UserRepository.Instancia.AddNewProduct(1,"Sofá Enderlin Ink", "100", "1860", "12", "A brilliant take on urban chic styling, this loveseat in vibrant blue makes high design highly affordable. Distinctive elements include quilted channel stitching for clean-lined allure and a velvety soft fabric you'll love living with. Sculptural track arms up the wow factor. If you're looking for big style on more modest scale, you're sure to appreciate this loveseat's space-conscious 59 wide profile.", "blue.jpg", "https://mintl.rencdn.com/product/ashley/images/24403-08-ANGLE-SW-P1-KO.jpg");
            UserRepository.Instancia.AddNewProduct(2,"Maimz Loveseat", "100", "1880", "12", "his designer loveseat is mid-century revival done to perfection. Linear and minimalistic, the beautifully edited profile has all the retro elements you love, like sheltering arms, bolster pillows and tapered splayed legs. So casually cool, the caramel faux leather upholstery brings the look right into the present.", "blue.jpg", "https://mintl.rencdn.com/product/ashley/images/A3000174-SW-P1-KO.jpg");
            UserRepository.Instancia.AddNewProduct(3,"Sofá RTA Macleary", "100", "1750", "12", "Ponte cómodo con una estética moderna cuando agregues este sofá de dos puestos a tu casa u oficina. Un diseño limpio y lineal se adapta muy bien a cualquier espacio sofisticado. Con tapicería de terciopelo y una elegante pata metálica, esta pieza eleva tu decoración a la última moda.", "orange.jpg", "https://mintl.rencdn.com/product/ashley/images/36232-60-SW-P1-KO.jpg");

            UserRepository.Instancia.AddNewProduct(4, "Macleary Sofa and Loveseat", "100", "1640", "12", "Ponte cómodo con una estética moderna cuando añadas este sofá a tu casa u oficina. Un diseño limpio y lineal se adapta muy bien a cualquier espacio sofisticado. Con tapicería de terciopelo y una elegante pata metálica de acento, esta pieza eleva tu decoración a la última moda.", "macleary.jpg", "https://mintl.rencdn.com/product/ashley/images/89006-38-35-SW.jpg");
            UserRepository.Instancia.AddNewProduct(5, "Yacolt Power Reclining Sofa", "100", "1940", "12", "Discover just how much better faux leather can be in this richly styled power reclining sofa. Outfitted with our latest and greatest padded faux leather with an authentic weathered effect, this ultra-comfortable reclining sofa with power is the embodiment of everyday luxury. Sporting a 43 high  back design, built out headrest for added support and extended ottoman, it truly has you covered from head to toe. ", "yacolt.jpg", "https://mintl.rencdn.com/product/ashley/images/82001-15-OPEN-ANGLE-SW-P1-KO.jpg");
            UserRepository.Instancia.AddNewProduct(6, "Cama King Tapizada de Panel con Almacenamiento Hyndell", "100", "1740", "12", "Combinando un diseño contemporáneo con ricos elementos, la cama de paneles Hyndell king aportará sofisticación y un toque de romance a tu dormitorio. El acabado oscuro del café expreso y la suntuosa tapicería de terciopelo de la cama se han hecho aún más espectaculares con la adición de una plataforma de almacenamiento de bajo perfil que complementa el estilo lujoso. Los botones acolchados de la cabecera son amor al primer toque.", "hyndell.jpg", "https://mintl.rencdn.com/product/ashley/images/B731-58-56S-SW.jpg");
            UserRepository.Instancia.AddNewProduct(7, "Cama King de Panel Baylow", "100", "1540", "12", "Apunta más alto para una estética de granja casual y elegante con la cama tapizada Baylow king con almacenamiento. Su estilo cuadrado, stocky está ricamente realzado con detalles de efecto de tablas y un desgastado acabado negro vintage que no es ni muy ligero ni muy pesado. Las pesadas marcas de sierra añaden un interesante toque artesanal. Colchón disponible, se vende por separado.", "baylow.jpg", "https://mintl.rencdn.com/product/ashley/images/B741-58-56-50-97S-SW.jpg");
            UserRepository.Instancia.AddNewProduct(8, "Mercado Sofa and Loveseat", "100", "2540", "12", "An indulgent choice with deep seats crafted for cloud-like softness, this designer sofa and loveseat is the ideal merger of modern flair and classic staying power. If you love a touch of texture, you're sure to appreciate this sofa's gorgeous gray upholstery with subtle chevron effect. Posh toss pillows layered over the loose back cushions perfect the richly relaxed aesthetic.", "loveseat.jpg", "https://mintl.rencdn.com/product/ashley/images/84604-38-35-SW.jpg");

            return new List<Products>
            {
                new Products{ Id = 1, Nombre = "Sofá Enderlin Ink", Imagen = "blue.jpg", Precio = "1860", Descripcion = "A brilliant take on urban chic styling, this loveseat in vibrant blue makes high design highly affordable. Distinctive elements include quilted channel stitching for clean-lined allure and a velvety soft fabric you'll love living with. Sculptural track arms up the wow factor. If you're looking for big style on more modest scale, you're sure to appreciate this loveseat's space-conscious 59 wide profile.", ImagenUrl = "https://mintl.rencdn.com/product/ashley/images/24403-08-ANGLE-SW-P1-KO.jpg"},
                new Products{ Id = 2, Nombre = "Maimz Loveseat", Imagen = "orange.jpg", Precio = "1880", Descripcion = "his designer loveseat is mid-century revival done to perfection. Linear and minimalistic, the beautifully edited profile has all the retro elements you love, like sheltering arms, bolster pillows and tapered splayed legs. So casually cool, the caramel faux leather upholstery brings the look right into the present.", ImagenUrl = "https://mintl.rencdn.com/product/ashley/images/A3000174-SW-P1-KO.jpg" },
                new Products{ Id = 3, Nombre = "Sofá RTA Macleary", Imagen = "pink.jpg", Precio = "1750", Descripcion = "Ponte cómodo con una estética moderna cuando agregues este sofá de dos puestos a tu casa u oficina. Un diseño limpio y lineal se adapta muy bien a cualquier espacio sofisticado. Con tapicería de terciopelo y una elegante pata metálica, esta pieza eleva tu decoración a la última moda.", ImagenUrl = "https://mintl.rencdn.com/product/ashley/images/36232-60-SW-P1-KO.jpg" },

                new Products{ Id = 4, Nombre = "Macleary Sofa and Loveseat", Imagen = "macleary.jpg", Precio = "1640", Descripcion = "Ponte cómodo con una estética moderna cuando agregues este sofá de dos puestos a tu casa u oficina. Un diseño limpio y lineal se adapta muy bien a cualquier espacio sofisticado. Con tapicería de terciopelo y una elegante pata metálica, esta pieza eleva tu decoración a la última moda.", ImagenUrl = "https://mintl.rencdn.com/product/ashley/images/89006-38-35-SW.jpg" },
                new Products{ Id = 5, Nombre = "Yacolt Power Reclining Sofa", Imagen = "yacolt.jpg", Precio = "1940", Descripcion = "Ponte cómodo con una estética moderna cuando agregues este sofá de dos puestos a tu casa u oficina. Un diseño limpio y lineal se adapta muy bien a cualquier espacio sofisticado. Con tapicería de terciopelo y una elegante pata metálica, esta pieza eleva tu decoración a la última moda.", ImagenUrl = "https://mintl.rencdn.com/product/ashley/images/82001-15-OPEN-ANGLE-SW-P1-KO.jpg" },
                new Products{ Id = 6, Nombre = "Cama King Tapizada de Panel con Almacenamiento Hyndell", Imagen = "hyndell.jpg", Precio = "1740", Descripcion = "Ponte cómodo con una estética moderna cuando agregues este sofá de dos puestos a tu casa u oficina. Un diseño limpio y lineal se adapta muy bien a cualquier espacio sofisticado. Con tapicería de terciopelo y una elegante pata metálica, esta pieza eleva tu decoración a la última moda.", ImagenUrl = "https://mintl.rencdn.com/product/ashley/images/B731-58-56S-SW.jpg" },
                new Products{ Id = 7, Nombre = "Cama King de Panel Baylow", Imagen = "baylow.jpg", Precio = "1540", Descripcion = "Ponte cómodo con una estética moderna cuando agregues este sofá de dos puestos a tu casa u oficina. Un diseño limpio y lineal se adapta muy bien a cualquier espacio sofisticado. Con tapicería de terciopelo y una elegante pata metálica, esta pieza eleva tu decoración a la última moda.", ImagenUrl = "https://mintl.rencdn.com/product/ashley/images/B741-58-56-50-97S-SW.jpg" },
                new Products{ Id = 8, Nombre = "Mercado Sofa and Loveseat", Imagen = "loveseat.jpg", Precio = "2540", Descripcion = "Ponte cómodo con una estética moderna cuando agregues este sofá de dos puestos a tu casa u oficina. Un diseño limpio y lineal se adapta muy bien a cualquier espacio sofisticado. Con tapicería de terciopelo y una elegante pata metálica, esta pieza eleva tu decoración a la última moda.", ImagenUrl = "https://mintl.rencdn.com/product/ashley/images/84604-38-35-SW.jpg" },

            };
        }
    }
}

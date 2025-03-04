﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LaArtistica.Models;
using Xamarin.Essentials;
using LaArtistica.Views.AccessView;
using LaArtistica.Views.ProductsView;

namespace LaArtistica.Views.ProductsView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckOutPage : ContentPage
    {
        private User currentUser;
        private Products currentProduct;
        private int cantidad;
        public CheckOutPage(User u, Products p, int c)
        {
            InitializeComponent();
            currentUser = u;
            currentProduct = p;
            cantidad = c;
            abonado.CheckedChanged += Abonado_CheckedChanged;
            txtEmail.Text = currentUser.Email;
            btnBuy.Clicked += BtnBuy_Clicked;
            btnCancel.Clicked += BtnCancel_Clicked;
            lblTotal.Text = "Precio Total: $" + (Int32.Parse(LoginPage.ProductToBuy.Precio) * cantidad).ToString();
        }

        private void Abonado_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (abonado.IsChecked)
            {
                abonosPick.IsEnabled = true;
                abonosPick.IsVisible = true;
                lblCantidad.IsVisible = true;
                frameCantidad.IsVisible = true;
            }
            else 
            {
                abonosPick.IsEnabled = false;
                abonosPick.IsVisible = false;
                lblCantidad.IsVisible = false;
                frameCantidad.IsVisible = false;
            }
        }

        async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("La Artística", "Tu compra ha sido cancelada", "Aceptar");
            Application.Current.MainPage = new NavigationPage(new ProductsView.Menu(currentUser));
        }

        async void BtnBuy_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtCedula.Text) || !string.IsNullOrEmpty(txtEmail.Text)
            || !string.IsNullOrEmpty(txtNumeroC.Text) || !string.IsNullOrEmpty(txtDireccion.Text) || !string.IsNullOrEmpty(txtCVV.Text))
            {
                if (!string.IsNullOrEmpty(picker.ToString()))
                {
                    await DisplayAlert("La Artística", "Has comprado el producto", "Aceptar");
                    sendEmail(currentUser, currentProduct);

                    UserRepository.Instancia.AddNewVenta(currentUser.Id, LoginPage.ProductToBuy.Id, DateTime.Now.ToString(), abonosPick.SelectedIndex);

                    Application.Current.MainPage = new NavigationPage(new ProductsView.Menu(currentUser));

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
                mail.Subject = "Confirmacion de compra La Artistica - " + DateTime.Now.ToString("hhmmss");

                mail.IsBodyHtml = true;
                mail.Body = getEmailBody(u, LoginPage.ProductToBuy);
                //mail.Body = "Gracias por comprar en La Artistica \nA continuacion los detalles de su compra: \n" +
                //    "Producto: " + p.Nombre + "\nPrecio: " + p.Precio;

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



        private string getEmailBody(User u, Products p)
        {
            string body = 
            "<!DOCTYPE html>" +
            "<html lang = 'en' xmlns = 'http://www.w3.org/1999/xhtml'xmlns: v = 'urn:schemas-microsoft-com:vml' xmlns: o = 'urn:schemas-microsoft-com:office:office'>" +
            "<head>" +
                "<meta charset = 'utf-8'>" +
                "<meta name = 'viewport'content = 'width=device-width'>" +
                "<meta http - equiv = 'X-UA-Compatible' content = 'IE=edge'>" +
                "<meta name = 'x-apple-disable-message-reformatting'>" +
                "<title> Confimación de Orden</title>" +
                "<link href = 'https://fonts.googleapis.com/css?family=Work+Sans:200,300,400,500,600,700' rel = 'stylesheet'>" +
                "<style>" +
                    "html,body {" +
                        "margin: 0 auto!important; " +
                        "padding: 0!important; " +
                        "height: 100 % !important; " +
                        "width: 100 % !important; " +
                        "background: #ffffff;" +
                    "}" +
                    "div[style*='margin: 16px 0'] {" +
                        "margin: 0 !important;" +
                    "}" +
                    "a {text-decoration: none;}" +
                    ".a6S {display: none !important;opacity: 0.01 !important;}" +
                    //".im {color: #000000 !important;}" +
                "</style>" +
                "<style>" +
                    ".primary{background: #17bebb;}" +
                    ".bg_white{background: #ffffff;}" +
                    ".bg_light{background: #f7fafa;}" +
                    ".bg_black{background: #000000;}" +
                    ".bg_dark{background: rgba(0,0,0,.8);}" +
                    ".email - section{ padding: 2.5em; }" +
                    "/*BUTTON*/" +
                    ".btn{ padding: 10px 15px; display: inline - block; }" +
                    ".btn.btn - primary{border - radius: 5px; background: #17bebb;color: #ffffff;}" +
                    ".btn.btn-white{border-radius: 5px;background: #ffffff;color: #000000;}" +
                    ".btn.btn-white-outline{border-radius: 5px;background: transparent;border: 1px solid #fff;color: #fff;}" +
                    ".btn.btn-black-outline{border-radius: 0px;background: transparent;border: 2px solid #000;color: #000;font-weight: 700;}" +
                    ".btn-custom{color: rgba(0,0,0,.3);text-decoration: underline;}" +
                    "h1,h2,h3,h4,h5,h6{font - family: 'Work Sans', sans - serif; color: #000000;margin-top: 0;font-weight: 400;}" +
                    "body{font-family: 'Work Sans', sans-serif;font-weight: 400;font-size: 15px;line-height: 1.8;color:rgba(0,0,0,.4);}" +
                    "a{color: #17bebb;}" +
                    "table{}" +
                    "/*LOGO*/" +
                    ".logo h1{margin: 0;}" +
                    "/*HERO*/" +
                    ".hero{ position: relative; z - index: 0; }" +
                    ".hero.text{ color: rgba(0, 0, 0, .3); }" +
                    ".hero.text h2{color: #000;font-size: 26px;margin-bottom: 15px;font-weight: 100;line-height: 1.2;}" +
                    ".hero .text h3{font-size: 20px;font-weight: 200;}" +
                    ".hero .text h2 span{font-weight: 600;color: #000;}" +
                    "/*PRODUCT*/" +
                    ".product-entry{display: block;position: relative;float: left;padding-top: 20px;}" +
                    ".product-entry .text{width: calc(100% - 125px);padding-left: 20px;}" +
                    ".product-entry .text h3{margin-bottom: 0;padding-bottom: 0;}" +
                    ".product-entry .text p{margin-top: 0;}" +
                    ".product-entry img, .product-entry .text{float: left;}" +
                    "ul.social{ padding: 0; }" +
                    "ul.social li{display: inline - block;margin - right: 10px;}" +
                    "/*FOOTER*/" +
                    ".footer{ border - top: 1px solid rgba(0, 0, 0, .05); color: rgba(0, 0, 0, .5); }" +
                    ".footer.heading{color: #000;font-size: 20px;}" +
                    ".footer ul{margin: 0;padding: 0;}" +
                    ".footer ul li{list-style: none;margin-bottom: 10px;}" +
                    ".footer ul li a{color: rgba(0,0,0,1);}" +
                    ".Icenter{display: block;margin-left: auto;margin-right: auto;width: 50%;margin-bottom: 10px;}" +
                "</style>" +
            "</head>" +
            "<body width='100%' style='margin: 0; padding: 0 !important; mso-line-height-rule: exactly; background-color: #f1f1f1;'>" +
            "<center style='width: 100%; background-color: white;'>" +
            "<div style='display: none; font-size: 1px;max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden; mso-hide: all; font-family: sans-serif;'>" +
            "&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;" +
            "&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;" +
            "</div>" +
            "<div style='max-width: 600px; margin: 0 auto;' class='email-container'>" +
            "<!-- BEGIN BODY -->" +
                "<table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
                    "<tr>" +
                        "<td valign='top' class='bg_white' style='padding: 1em 2.5em 0 2.5em;'>" +
                            "<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                                "<tr>" +
                                    "<td class='logo' style='text-align: center;'>" +
                                        "<a><img src='https://www.empleos.net//rhmanager/logos/original_size/46892_20191008060521.jpg' width='120px' class='Icenter'></img></a>" +
                                    "</td>" +
                                "</tr>" +
                            "</table>" +
                        "</td>" +
                    "</tr><!-- end tr -->" +
                    "<tr>" +
                        "<td valign='middle' class='hero bg_white' style='padding: 2em 0 2em 0;'>" +
                            "<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                                "<tr>" +
                                    "<td style='padding: 0 2.5em; text-align: left;'>" +
                                        "<div class='text'>" +
                                            "<h2>Hola " + u.Username + "</h2>" +
                                            "<h4>Gracias por realizar su pedido con La Artística Este correo electrónico es para confirmar que su pedido se ha realizado correctamente y se procesará y se le enviará pronto.</h4>" +
                                        "</div>" +
                                    "</td>" +
                                "</tr>" +
                            "</table>" +
                        "</td>" +
                    "</tr><!-- end tr -->" +
                    "<tr>" +
                        "<table class='bg_white' role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                            "<tr style='border-bottom: 1px solid rgba(0,0,0,.1);'>" +
                                "<th width='80%' style='text-align:left; padding: 0 2.5em; color: #000; padding-bottom: 20px'>Item</th>" +
                                "<th width='20%' style='text-align:right; padding: 0 2.5em; color: #000; padding-bottom: 20px'>Price</th>" +
                             "</tr>" +
                             "<tr style='border-bottom: 1px solid rgba(0,0,0,.05);'>" +
                                "<td valign='middle' width='80%' style='text-align:left; padding: 0 2.5em;'>" +
                                    "<div class='product-entry'>" +
                                        "<img src='"+ p.ImagenUrl +"' alt='" + p.ImagenUrl + "' style='width: 100px; max-width: 600px; height: auto; margin-bottom: 20px; display: block;'>" +
                                        "<div class='text'>" +
                                            "<h3>" + p.Nombre + " </h3>" +
                                            "<span>ARTÍCULO# - " + p.Id + " CANTIDAD: " + cantidad + "</span>" +
                                            "<p>" + p.Descripcion + " </p>" +
                                        "</div>" +
                                    "</div>" +
                                "</td>" +
                                "<td valign='middle' width='20%' style='text-align:left; padding: 0 2.5em;'> " +
                                    "<span class='price' style='color: #000; font-size: 20px;'>$" + (Int32.Parse(p.Precio)*cantidad).ToString() + " </span> " +
                                "</td>" +
                            "</tr>" +
                        "</table>" +
                    "</tr>" +
                "</table>" +
                "<table align = 'center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin: auto;'>" +
                    "<tr>" +
                        "<td valign = 'middle' class='bg_light footer email-section'>" +
                            "<table>" +
                                "<tr>" +
                                    "<td valign = 'top' width='33.333%' style='padding-top: 20px;'>" +
                                        "<table role = 'presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                                            "<tr>" +
                                                "<td style = 'text-align: center; padding-right: 10px;'>" +
                                                    "<h3 class='heading'>Sobre Nosotros</h3>" +
                                                    "<p>Mueblería con más de 80 años en el mercado costarricense.</p>" +
                                                "</td>" +
                                            "</tr>" +
                                        "</table>" +
                                    "</td>" +
                                    "<td valign = 'top' width= '33.333%' style= 'padding-top: 20px;'>" +
                                        "<table role= 'presentation' cellspacing= '0' cellpadding= '0' border= '0' width= '100%'>" +
                                            "<tr>" +
                                                "<td style= 'text-align: center; padding-left: 5px; padding-right: 5px;'>" +
                                                    "<h3 class='heading'>Contáctenos</h3>" +
                                                    "<ul>" +
                                                        "<li><span class='text'>Diagonal al Walmart de Curridabat</span></li>" +
                                                        "<li><span class='text'>+506 2272-8787</span></a></li>" +
                                                        "<li><span class='text'>laartisticaulacit@gmail.com</span></a></li>" +
                                                    "</ul>" +
                                                "</td>" +
                                            "</tr>" +
                                        "</table>" +
                                    "</td>" +
                                "</tr>" +
                            "</table>" +
                        "</td>" +
                    "</tr>" +
                "</table>" +
            "</div>" +
            "</center>" +
            "</body>" +
            "</html>";
            return body;
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
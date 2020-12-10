using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using LaArtistica.Models;
using LaArtistica.Views.AccessView;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
//using System.Drawing;
using System.IO;
using Syncfusion.Drawing;
using LaArtistica.Services;
using System.Net.Mail;


namespace LaArtistica.Views.ProductsView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportsPage : ContentPage
    {
        public ReportsPage()
        {
            InitializeComponent();
            btnGarantias.Clicked += GarantiasBtn_Clicked;
        }

        private void GarantiasBtn_Clicked(object sender, EventArgs e)
        {
            //// Create a new PDF document
            //PdfDocument document = new PdfDocument();

            ////Add a page to the document
            //PdfPage page = document.Pages.Add();

            ////Create PDF graphics for the page
            //PdfGraphics graphics = page.Graphics;

            ////Set the standard font
            //PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            ////Draw the text
            //graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

            ////Save the document to the stream
            //MemoryStream stream = new MemoryStream();
            //document.Save(stream);

            ////Close the document
            ////document.Close(true);

            ////Save the stream as a file in the device and invoke it for viewing
            //Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("LaArtistica/Output.pdf", "application / pdf", stream);

            ////PdfLoadedDocument loadedDocument = new PdfLoadedDocument(stream,true);
            List<Venta> ventas=  UserRepository.Instancia.GetVentasReport(LoginPage.LogedUser.Id).ToList();
            List<int> ids = new List<int>();
            foreach(Venta v in ventas){
                ids.Add(v.ProductoID);
            }
            List<Products> products = UserRepository.Instancia.GetProductsForReport(ids).ToList();
            Console.WriteLine("COUNT" + products.Count());
            foreach (Products p in products)
            {
                Console.WriteLine(p.Nombre);
            }
            //sendPDFEmail();


        }
        private void sendPDFEmail()
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("laartisticaulacit@gmail.com");
                mail.To.Add("rsft6000@gmail.com");
                mail.Subject = "Reporte La Artistica";

                mail.Body = "Reporte PDF prueba";
                //Attachment data = new Attachment(p, "Reports.pdf", System.Net.Mime.MediaTypeNames.Application.Pdf);
                Attachment data = new Attachment("Report.pdf");
                mail.Attachments.Add(data);
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
    }
}
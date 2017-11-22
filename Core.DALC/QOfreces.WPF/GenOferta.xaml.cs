using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Core.Negocio;
using System.Collections.ObjectModel;
using System.Collections;
using System.Data;
using System.ComponentModel;
using Microsoft.Win32;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using iTextSharp.text.pdf;
using System.Windows.Controls.Primitives;
using iTextSharp.text;
using System.IO;
using System.Net;

namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para GenOferta.xaml
    /// </summary>
    public partial class GenOferta : MetroWindow
    {
        private string rutaNombreImagenOferta;
        Validaciones validador = new Validaciones();

        string nombreCompleto = string.Format("{0} {1}", mainwindow.UsuarioACtual.Nombre, mainwindow.UsuarioACtual.Apellido);

        public GenOferta()
        {

            InitializeComponent();
            CargarCombobox();
            ocultarLbl();
        }

        private void CargarCombobox()
        {

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllSucursal(mainwindow.RetailActual.IdRetail);
            SucursalCollections sucCol = new SucursalCollections(json);
            cbSucursal.DisplayMemberPath = "Nombre";
            cbSucursal.SelectedValuePath = "IdSucursal";
            cbSucursal.ItemsSource = sucCol.ToList();

            string jerson = proxy.ReadAllCategoria();
            CategoriaCollections catColl = new CategoriaCollections(jerson);
            cbCatOf.DisplayMemberPath = "Nombre";
            cbCatOf.SelectedValuePath = "IdCategoria";
            cbCatOf.ItemsSource = catColl.ToList();

            // Carga Nombre y Apellido del usuario actual
            lblUserAct.Content = "Bienvenido " + nombreCompleto;


        }

        private void ocultarLbl()
        {

            lblCategoriaOferta.Visibility = Visibility.Hidden;
            lblFechaOferta.Visibility = Visibility.Hidden;
            lblImagen.Visibility = Visibility.Hidden;
            lblMaxProductos.Visibility = Visibility.Hidden;
            lblMinProductos.Visibility = Visibility.Hidden;
            lblNombre.Visibility = Visibility.Hidden;
            lblPrecioAnterior.Visibility = Visibility.Hidden;
            lblPrecioOferta.Visibility = Visibility.Hidden;
            lblSucursal.Visibility = Visibility.Hidden;
        }

        private void btnGenOferta_Click(object sender, RoutedEventArgs e)
        {
            lblFechaOferta.Content = validador.validarFecha(dpFecha.Text);
            lblMaxProductos.Content = validador.validarMaxCantidad(txtMaxProd.Text);
            lblMinProductos.Content = validador.validarMinCantidad(txtMinProd.Text);
            lblNombre.Content = validador.validarNombre(txtNombre.Text);
            lblPrecioAnterior.Content = validador.validarPrecio(txtPrecioAntes.Text);
            lblPrecioOferta.Content = validador.validarPrecio(txtPrecio.Text);
           

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            Oferta of = new Oferta();

            string nombreImagen = txtNombre.Text + "_" + DateTime.Now.ToString();

            var listaSuc = dgSuc.Items.OfType<Sucursal>();
            OfertaHasSucursal ohs = new OfertaHasSucursal();
            int contOK = 0;


            of.ImagenOferta = nombreImagen;
            of.MinProductos = int.Parse(txtMinProd.Text);
            of.MaxProductos = int.Parse(txtMaxProd.Text);
            of.PrecioAntes = int.Parse(txtPrecioAntes.Text);
            of.PrecioOferta = int.Parse(txtPrecio.Text);
            if (chPubOf.IsChecked == true)
            {
                of.EstadoOferta = char.Parse(1.ToString());
            }
            else
            {
                of.EstadoOferta = char.Parse(0.ToString());
            }
            of.FechaOferta = dpFecha.SelectedDate;
            of.IdSucursal = 1;

            of.CategoriaIdOferta = (int)cbCatOf.SelectedValue;
            of.Nombre = txtNombre.Text;
            of.Descripcion = txtDescOf.Text;
            of.OfertaDia = char.Parse("s");

            string json = of.Serializar();

            if (lblFechaOferta.Content.Equals("OK") && lblMaxProductos.Content.Equals("OK") && lblMinProductos.Content.Equals("OK") && lblNombre.Content.Equals("OK") && lblPrecioAnterior.Content.Equals("OK") && lblPrecioOferta.Content.Equals("OK"))
            {

            }
            else
            {
                if (lblFechaOferta.Content.Equals("OK"))
                {
                    lblFechaOferta.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblFechaOferta.Visibility = Visibility.Visible;
                }

                if (lblMaxProductos.Content.Equals("OK"))
                {
                    lblMaxProductos.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblMaxProductos.Visibility = Visibility.Visible;
                }

                if (lblMinProductos.Content.Equals("OK"))
                {
                    lblMinProductos.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblMinProductos.Visibility = Visibility.Visible;
                }

                if (lblNombre.Content.Equals("OK"))
                {
                    lblNombre.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblNombre.Visibility = Visibility.Visible;
                }

                if (lblPrecioAnterior.Content.Equals("OK"))
                {
                    lblPrecioAnterior.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblPrecioAnterior.Visibility = Visibility.Visible;
                }

                if (lblPrecioOferta.Content.Equals("OK"))
                {
                    lblPrecioOferta.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblPrecioOferta.Visibility = Visibility.Visible;
                }

            }

            if (proxy.CrearOferta(json))
            {
                // inserta tablaaproducto has ofertas
                var list = dgProd.Items.OfType<Producto>();
                ProductoHasOferta pho = new ProductoHasOferta();
                foreach (var item in list)
                {
                    if (item.Selec == true)
                    {
                        pho.OfertaId = of.IdOferta;
                        pho.ProductoId = item.IdProducto;
                        string jerson = pho.Serializar();
                        proxy.CrearProductoHasOferta(jerson);
                    }
                }
                // inserta tabla Oferta Has sucursal
                foreach (var itemSuc in listaSuc)
                {
                    if (itemSuc.Selec == true)
                    {
                        ohs.OfertaId = of.IdOferta;
                        ohs.SucursalId = itemSuc.IdSucursal;
                        string jeson = ohs.Serializar();
                        proxy.CrearOfertaHasSucursal(jeson);
                        contOK++;
                    }
                }



                /*Envia por ftp imagen adjuntada*/

                string user = "misofertas@adonisweb.cl";
                string pw = "789456123";
                string FTP = "ftp://adonisweb.cl/" + nombreImagen;

                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FTP);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(user, pw);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;
                FileStream stream = File.OpenRead(rutaNombreImagenOferta);
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Flush();
                reqStream.Close();


                if (contOK > 0)
                {
                    MessageBox.Show("OFERTA CREADA PARA " + contOK + "SUCURSALES!");
                }
                else
                {
                    MessageBox.Show("ERROR AL CREAR OFERTA!");
                }
                contOK = 0;
            } 

           
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllProductos();
            Core.Negocio.ProductoCollections collprod = new Core.Negocio.ProductoCollections(json);
            collprod.ToList();
            dgProd.ItemsSource = collprod;


            string JSON = proxy.ReadAllSucursal(mainwindow.RetailActual.IdRetail);
            SucursalCollections sucCol = new SucursalCollections(JSON);
            dgSuc.ItemsSource = sucCol.ToList();


        }

        private void btnAdjuntar_Click(object sender, RoutedEventArgs e)
        {
            if (imgFoto.Source == null)
            {
                OpenFileDialog openFile = new OpenFileDialog();
                BitmapImage b = new BitmapImage();
                openFile.Title = "Seleccione la Imagen a Mostrar";
                openFile.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp";
                if (openFile.ShowDialog() == true)
                {
                    b.BeginInit();
                    b.UriSource = new Uri(openFile.FileName);
                    b.EndInit();
                    imgFoto.Stretch = Stretch.Fill;
                    imgFoto.Source = b;

                    btnAdjuntar.Content = "Quitar Foto";
                    rutaNombreImagenOferta = openFile.FileName;

                    /*copia imagen a carpeta imgOferta*/
                    // string ruta = string.Format("{0}{1}", "C:/temp/Repositorio/Portafolio-de-titulo/Core.DALC/Core.Servicios/imgOferta/", openFile.SafeFileName);
                    //File.Copy(openFile.FileName, ruta);                    
                }
            }
            else
            {
                imgFoto.Source = null;
                btnAdjuntar.Content = "Cambiar Foto";
            }

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            EncargadoTienda en = new EncargadoTienda();
            this.Close();
            en.Show();
        }

        private void txtPrecio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57)
            {
                lblPrecioOferta.Visibility = Visibility.Hidden;
            }
            else
            {
                lblPrecioOferta.Content = "Precio no puede contener letras";
                lblPrecioOferta.Visibility = Visibility.Visible;
            }
        }

        private void txtPrecioAntes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57)
            {
                lblPrecioAnterior.Visibility = Visibility.Hidden;
            }
            else
            {
                lblPrecioAnterior.Content = "Precio no puede contener letras";
                lblPrecioAnterior.Visibility = Visibility.Visible;
            }
        }

        private void txtMinProd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57)
            {
                lblMinProductos.Visibility = Visibility.Hidden;
            }
            else
            {
                lblMinProductos.Content = "Minimo Producto no puede contener letras";
                lblMinProductos.Visibility = Visibility.Visible;
            }
        }

        private void txtMaxProd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57)
            {
                lblMaxProductos.Visibility = Visibility.Hidden;
            }
            else
            {
                lblMaxProductos.Content = "Maximo Producto no puede contener letras";
                lblMaxProductos.Visibility = Visibility.Visible;
            }
        }

        /* 
private void Button_Click(object sender, RoutedEventArgs e)
{
   ExportToPdf(dgProd);
}

private T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
{
   for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
   {
       DependencyObject child = VisualTreeHelper.GetChild(obj, i);
       if (child != null && child is T)
           return (T)child;
       else
       {
           T childOfChild = FindVisualChild<T>(child);
           if (childOfChild != null)
               return childOfChild;
       }
   }
   return null;
}

public void ExportToPdf(DataGrid grid)
{
   PdfPTable table = new PdfPTable(grid.Columns.Count);
   Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
   PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream("Test.pdf", System.IO.FileMode.Create));
   doc.Open();

   for (int j = 0; j < grid.Columns.Count; j++)
   {
       table.AddCell(new Phrase(grid.Columns[j].Header.ToString()));
   }
   table.HeaderRows = 1;
   IEnumerable itemsSource = grid.ItemsSource as IEnumerable;
   if (itemsSource != null)
   {
       foreach (var item in itemsSource)
       {
           DataGridRow row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
           if (row != null)
           {
               DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
               for (int i = 0; i < grid.Columns.Count; ++i)
               {
                   DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                   TextBlock txt = cell.Content as TextBlock;
                   if (txt != null)
                   {
                       table.AddCell(new Phrase(txt.Text));
                   }
               }
           }
       }

       doc.Add(table);
       doc.Close();
   }
}
*/
    }

}


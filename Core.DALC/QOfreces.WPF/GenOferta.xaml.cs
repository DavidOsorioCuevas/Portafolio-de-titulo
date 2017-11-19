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
        Validaciones validador = new Validaciones();

        public GenOferta()
        {

            InitializeComponent();
            CargarCombobox();
            lblNombre.Visibility = Visibility.Hidden;
            lblCategoria.Visibility = Visibility.Hidden;
            lblDescripcion.Visibility = Visibility.Hidden;
            lblFecha.Visibility = Visibility.Hidden;
            lblImagen.Visibility = Visibility.Hidden;
            lblMaxProductos.Visibility = Visibility.Hidden;
            lblMinProductos.Visibility = Visibility.Hidden;
            lblPrecioAntiguo.Visibility = Visibility.Hidden;
            lblPrecioNew.Visibility = Visibility.Hidden;
            lblSucursal.Visibility = Visibility.Hidden;

        }

        private void CargarCombobox()
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllSucursal();
            SucursalCollections sucCol = new SucursalCollections(json);
            cbSucursal.DisplayMemberPath = "Nombre";
            cbSucursal.SelectedValuePath = "IdSucursal";
            cbSucursal.ItemsSource = sucCol.ToList();

            string jerson = proxy.ReadAllCategoria();
            CategoriaCollections catColl = new CategoriaCollections(jerson);
            cbCatOf.DisplayMemberPath = "Nombre";
            cbCatOf.SelectedValuePath = "IdCategoria";
            cbCatOf.ItemsSource = catColl.ToList();


        }

        private void btnGenOferta_Click(object sender, RoutedEventArgs e)
        {

            lblNombre.Content = validador.validarNombre(txtNombre.Text);
            lblPrecioAntiguo.Content = validador.validarPrecio(txtPrecioAntes.Text);
            lblPrecioNew.Content = validador.validarPrecio(txtPrecioAntes.Text);
            lblMaxProductos.Content = validador.validarMaxCantidad(txtMaxProd.Text);
            lblMinProductos.Content = validador.validarMinCantidad(txtMinProd.Text);


            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            Oferta of = new Oferta();
            of.ImagenOferta = imgFoto.Source.ToString();
            if (imgFoto.Source == null)
            {
                lblImagen.Content = "Ingrese Imagen";
            }

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
            of.IdSucursal = (int)cbSucursal.SelectedValue;

            of.CategoriaIdOferta = (int)cbCatOf.SelectedValue;
            of.Nombre = txtNombre.Text;
            of.Descripcion = txtDescOf.Text;
            of.OfertaDia = char.Parse("s");

            string json = of.Serializar();

            //if (imgFoto.Source.ToString() == null)
            //{
            //    lblImagen.Content = "Adjunte Imagen";
            //}
            //if (dpFecha == null)
            //{
            //    lblFecha.Content = "Indique Fecha";
            //}
            //else
            if (cbCatOf.SelectedIndex == -1)
            {
                lblCategoria.Content = "Seleccione una opcion";
                lblCategoria.Visibility = Visibility.Visible;

                if (cbSucursal.SelectedIndex == -1)
                {
                    lblSucursal.Content = "Seleccione una opcion";
                    lblSucursal.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if ((lblNombre.Content.Equals("OK")))
                {
                    if (lblMaxProductos.Content.Equals("OK"))
                    {
                        if (lblMinProductos.Content.Equals("OK"))
                        {
                            if (lblPrecioAntiguo.Content.Equals("OK"))
                            {
                                if (lblPrecioNew.Content.Equals("OK"))
                                {
                                    if (proxy.CrearOferta(json))
                                    {
                                        List<Producto> lstprod = new List<Producto>();
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


                                        MessageBox.Show("OFERTA CREADA!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("ERROR AL CREAR OFERTA!");
                                    }
                                }
                                else
                                {
                                    lblPrecioNew.Visibility = Visibility.Visible;
                                }
                            }
                            else
                            {
                                lblPrecioAntiguo.Visibility = Visibility.Visible;
                            }
                        }
                        else
                        {
                            lblMinProductos.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        lblMaxProductos.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    lblNombre.Visibility = Visibility.Visible;
                }
            }

        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllProductos();
            Core.Negocio.ProductoCollections collprod = new Core.Negocio.ProductoCollections(json);
            collprod.ToList();
            dgProd.ItemsSource = collprod;
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
                    /*copia imagen a carpeta imgOferta*/
                    // string ruta = string.Format("{0}{1}", "C:/temp/Repositorio/Portafolio-de-titulo/Core.DALC/Core.Servicios/imgOferta/", openFile.SafeFileName);
                    //File.Copy(openFile.FileName, ruta);

                    /*Envia por ftp imagen adjuntada*/
                    string user = "misofertas@adonisweb.cl";
                    string pw = "789456123";
                    string FTP = "ftp://adonisweb.cl/" + openFile.SafeFileName;


                    FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(FTP);
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(user, pw);
                    request.UsePassive = true;
                    request.UseBinary = true;
                    request.KeepAlive = true;
                    FileStream stream = File.OpenRead(openFile.FileName);
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    stream.Close();
                    Stream reqStream = request.GetRequestStream();
                    reqStream.Write(buffer, 0, buffer.Length);
                    reqStream.Flush();
                    reqStream.Close();
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

        private void txtNombre_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {

            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
            {
                lblNombre.Visibility = Visibility.Hidden;

                if (string.IsNullOrEmpty(e.Text))
                {
                    lblNombre.Content = "Nombre no puede estar vacio";
                    lblNombre.Visibility = Visibility.Visible;
                }
            }
            else
            {

                lblNombre.Content = "Nombre no puede contener numeros";
                lblNombre.Visibility = Visibility.Visible;

            }

        }

        private void txtPrecioAntes_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57)
            {
                lblPrecioAntiguo.Visibility = Visibility.Hidden;
            }
            else
            {
                lblPrecioAntiguo.Content = "Precio no puede contener letras";
                lblPrecioAntiguo.Visibility = Visibility.Visible;
            }
        }

        private void txtPrecio_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57)
            {
                lblPrecioNew.Visibility = Visibility.Hidden;
            }
            else
            {
                lblPrecioNew.Content = "Precio no puede contener letras";
                lblPrecioNew.Visibility = Visibility.Visible;
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
                lblMaxProductos.Content = "Cantidad no puede contener letras";
                lblMaxProductos.Visibility = Visibility.Visible;
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
                lblMinProductos.Content = "Cantidad no puede contener letras";
                lblMinProductos.Visibility = Visibility.Visible;
            }
        }

        private void txtMinProd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}


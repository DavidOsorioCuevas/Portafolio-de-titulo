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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using Core.Negocio;
using System.Net;
using System.IO;
using Microsoft.Win32;

namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para MenuEncargado.xaml
    /// </summary>
    public partial class MenuEncargado : MetroWindow
    {
        private string rutaNombreImagenOferta;
        public MenuEncargado()
        {
            this.Title = string.Format("Encargado {0}     Sucursal: {1}", mainwindow.RetailActual.NombreRetail, mainwindow.SucursalActual.Nombre);
            InitializeComponent();
            lblUsuarioActual.Content = string.Format("{0} {1}", mainwindow.UsuarioACtual.Nombre, mainwindow.UsuarioACtual.Apellido); ;
            LimpiarControles();
            _reportViewer.Load += ReportViewer_Load;
        }

       

        private bool _isReportViewerLoaded;


        private void tiGenerarOferta_Click(object sender, RoutedEventArgs e)
        {
            if (flyConsultar.IsOpen == true || flyReportes.IsOpen == true || flyProductos.IsOpen == true || flyPublicar.IsOpen == true)
            {
                flyConsultar.IsOpen = false;
                flyReportes.IsOpen = false;
                flyProductos.IsOpen = false;
                flyPublicar.IsOpen = false;
            }
            flyGenerar.IsOpen = true;
        }

        private void tiPublicarOferta_Click(object sender, RoutedEventArgs e)
        {
            if (flyConsultar.IsOpen == true || flyReportes.IsOpen == true || flyProductos.IsOpen == true || flyGenerar.IsOpen == true)
            {
                flyConsultar.IsOpen = false;
                flyReportes.IsOpen = false;
                flyProductos.IsOpen = false;
                flyGenerar.IsOpen = false;
            }
            flyPublicar.IsOpen = true;
        }

        private void tiProducto_Click(object sender, RoutedEventArgs e)
        {
            if (flyConsultar.IsOpen == true || flyReportes.IsOpen == true || flyGenerar.IsOpen == true || flyPublicar.IsOpen == true)
            {
                flyConsultar.IsOpen = false;
                flyReportes.IsOpen = false;
                flyGenerar.IsOpen = false;
                flyPublicar.IsOpen = false;
            }
            flyProductos.IsOpen = true;
        }

        private void tiConsultarOferta_Click(object sender, RoutedEventArgs e)
        {
            if (flyGenerar.IsOpen == true || flyReportes.IsOpen == true || flyProductos.IsOpen == true || flyPublicar.IsOpen == true)
            {
                flyGenerar.IsOpen = false;
                flyReportes.IsOpen = false;
                flyProductos.IsOpen = false;
                flyPublicar.IsOpen = false;
            }
            flyConsultar.IsOpen = true;
        }

        private void tiReportes_Click(object sender, RoutedEventArgs e)
        {
            if (flyConsultar.IsOpen == true || flyGenerar.IsOpen == true || flyProductos.IsOpen == true || flyPublicar.IsOpen == true)
            {
                flyConsultar.IsOpen = false;
                flyGenerar.IsOpen = false;
                flyProductos.IsOpen = false;
                flyPublicar.IsOpen = false;
            }
            flyReportes.IsOpen = true;
        }

        private async void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllProductos();
            Core.Negocio.ProductoCollections collprod = new Core.Negocio.ProductoCollections(json);
            var collprodu = new ProductoCollections();

            if (txtBuscarProducto.Text.Length > 0)
            {
                foreach (var item in collprod)
                {
                    if (item.Nombre.Contains(txtBuscarProducto.Text))
                    {
                        collprodu.Add(item);
                    }
                }

                if (collprodu.Count>0)
                {
                    collprodu.ToList();
                    dgProd.ItemsSource = collprodu;
                }
                else
                {
                    await this.ShowMessageAsync("Vaya...", "No hay registros que coincidan");
                }
            }
            else
            {
                if (collprod.Count>0)
                {
                    collprod.ToList();
                    dgProd.ItemsSource = collprod;
                }
                else
                {
                    await this.ShowMessageAsync("Error", "No existen registros para mostrar");
                }
            }

            //string JSON = proxy.ReadAllSucursal(mainwindow.RetailActual.IdRetail);
            //SucursalCollections sucCol = new SucursalCollections(JSON);
            //dgSuc.ItemsSource = sucCol.ToList();
            
        }

        private async void btnGenOferta_Click(object sender, RoutedEventArgs e)
        {

            var list = dgProd.Items.OfType<Producto>();
            Boolean pass = false;
            if (list.Count() > 0)
            {
                foreach (var item in list)
                {
                    if (item.Selec == true)
                    {
                        pass = true;
                    }
                }

                if (pass)
                {
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

                    if (proxy.CrearOferta(json))
                    {
                        // inserta tablaaproducto has ofertas

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
                            await this.ShowMessageAsync("Exito", "Oferta creada para " + contOK + " sucursales!");

                        }
                        else
                        {
                            await this.ShowMessageAsync("Error", "No se pudo crear la oferta");
                        }

                        LimpiarControles();

                        contOK = 0;
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Debe seleccionar uno o mas productos de la lista");
                }
            }
            else
            {
                await this.ShowMessageAsync("Error", "Debe buscar almenos un producto en la lista");
            }
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

        private async void btnBusquedaPu_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllOfertas(mainwindow.UsuarioACtual.IdSucursal);
            Core.Negocio.OfertaCollections collof = new Core.Negocio.OfertaCollections(json);
            var colloff = new OfertaCollections();

            if (txtBusquedaPu.Text.Length>0)
            {
                if (cbPublicadas.IsChecked == true)
                {
                    foreach (var item in collof)
                    {
                        if (item.Nombre.ToUpper().Contains(txtBusquedaPu.Text.ToUpper()) && item.EstadoOferta.Equals('1'))
                        {
                            colloff.Add(item);
                        }
                    }

                    if (colloff.Count>0)
                    {
                        colloff.ToList();
                        dgOfertas.ItemsSource = colloff;
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "No hay ofertas publicadas para mostrar");
                    }
                }
                else
                {
                    foreach (var item in collof)
                    {
                        if (item.EstadoOferta.Equals('0') && item.Nombre.ToUpper().Contains(txtBusquedaPu.Text.ToUpper()))
                        {
                            colloff.Add(item);
                        }
                    }

                    if (colloff.Count > 0)
                    {
                        colloff.ToList();
                        dgOfertas.ItemsSource = colloff;
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "No hay ofertas no publicadas para mostrar");
                    }
                }

            }
            else
            {
                if (cbPublicadas.IsChecked == true)
                {
                    foreach (var item in collof)
                    {
                        if (item.EstadoOferta.Equals('1'))
                        {
                            colloff.Add(item);
                        }
                    }

                    if (colloff.Count>0)
                    {
                        colloff.ToList();
                        dgOfertas.ItemsSource = colloff;
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "No hay ofertas publicadas para mostrar");
                    }
                }
                else
                {
                    foreach (var item in collof)
                    {
                        if (item.EstadoOferta.Equals('0'))
                        {
                            colloff.Add(item);
                        }
                    }

                    if (colloff.Count > 0)
                    {
                        colloff.ToList();
                        dgOfertas.ItemsSource = colloff;
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "No hay ofertas no publicadas para mostrar");
                    }
                }
            }
        }

        private async void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            var list = dgOfertas.Items.OfType<Oferta>();
            int countpu = 0;
            int contdes = 0;
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            Oferta of = new Oferta();
            foreach (var item in list)
            {

                of.IdOferta = item.IdOferta;
                string json = of.Serializar();
                json = proxy.LeerOfertaId(json);
                Oferta ofer = new Oferta(json);
                if (item.Selec == false && ofer.EstadoOferta == '1')
                {
                    // desactivar publicacion;
                    proxy.DesPublicarOferta(json);
                    contdes++;

                }
                else if (item.Selec == true && ofer.EstadoOferta == '0')
                {
                    //activar publicacion;
                    proxy.PublicarOferta(json);
                    countpu++;
                }
            }

            await this.ShowMessageAsync("Actualizando...", "SE ACTIVARON " + countpu.ToString() + " PUBLICACIONES");
            await this.ShowMessageAsync("Actualizando...", "SE DESACTIVARON " + contdes.ToString() + " PUBLICACIONES");
            dgOfertas.ItemsSource = null;
        }

        private void LimpiarControles()
        {
            txtBuscarProducto.Text = "";
            txtBusquedaCO.Text = "";
            txtBusquedaPu.Text = "";
            txtCodigoPA.Text = "";
            txtCodigoPE.Text = "";
            txtCodigoPM.Text = "";
            txtDescOf.Text = "";
            txtDescripcionPA.Text = "";
            txtDescripcionPA.Text = "";
            txtDescripcionPE.Text = "";
            txtDescripcionPM.Text = "";
            txtMaxProd.Text = "";
            txtMinProd.Text = "";
            txtNombre.Text = "";
            txtNombrePA.Text = "";
            txtNombrePE.Text = "";
            txtNombrePEL.Text = "";
            txtNombrePM.Text = "";
            txtNombrePMO.Text = "";
            txtPrecio.Text = "";
            txtPrecioAntes.Text = "";
            txtPrecioPA.Text = "";
            txtPrecioPE.Text = "";
            txtPrecioPM.Text = "";
            dgProd.ItemsSource = null;
            chPubOf.IsChecked = false;
            dpFecha.SelectedDate = DateTime.Now;
            imgFoto.Source = null;
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string JSON = proxy.ReadAllSucursal(mainwindow.RetailActual.IdRetail);
            SucursalCollections sucCol = new SucursalCollections(JSON);
            dgSuc.ItemsSource = sucCol.ToList();
            dgSucCO.ItemsSource = sucCol.ToList();
            JSON = proxy.ReadAllCategoria();
            CategoriaCollections catCol = new CategoriaCollections(JSON);
            dgCat.ItemsSource = catCol.ToList();
            JSON = proxy.ReadAllCategoria();
            CategoriaCollections catColl = new CategoriaCollections(JSON);
            cbCatOf.DisplayMemberPath = "Nombre";
            cbCatOf.SelectedValuePath = "IdCategoria";
            cbCatOf.ItemsSource = catColl.ToList();
            cbCatOf.SelectedIndex = 0;
            cbPublicadasCO.IsChecked = false;
            dgOfertasCO.ItemsSource = null;
        }

        private async void btnBusquedaCO_Click(object sender, RoutedEventArgs e)
        {
            var listasu = dgSucCO.Items.OfType<Sucursal>();
            var listaCa = dgCat.Items.OfType<CategoriaOferta>();
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllOfertas(mainwindow.UsuarioACtual.IdSucursal);
            Core.Negocio.OfertaCollections collof = new Core.Negocio.OfertaCollections(json);
            var colloff = new OfertaCollections();
            var colmost = new OfertaCollections();
            bool pas = false;

            //primer filtro

            if (txtBusquedaCO.Text.Length > 0)
            {
                foreach (var item in collof)
                {
                    if (item.Nombre.ToUpper().Contains(txtBusquedaCO.Text))
                    {
                        colloff.Add(item);
                    }
                }
                colmost = colloff;

            }
            else
            {
                colloff = collof;
                colmost = colloff;
            }
            // segundo filtro

            collof = colmost;
            colloff = new OfertaCollections();
            if (cbPublicadasCO.IsChecked == true)
            {
                foreach (var item in collof)
                {
                    if (item.EstadoOferta.Equals('1'))
                    {
                        colloff.Add(item);
                    }
                }
                colmost = colloff;
            }
            else
            {
                foreach (var item in collof)
                {
                    if (item.EstadoOferta.Equals('0'))
                    {
                        colloff.Add(item);
                    }
                }
                colmost = colloff;
            }
            collof = colmost;
            colloff = new OfertaCollections();
            //tercer filtro
            foreach (var item in listasu)
            {
                if (item.Selec == true)
                {
                    pas = true;
                }
            }

            if (pas)
            {
                foreach (var item in listasu)
                {
                    if (item.Selec == true)
                    {
                        foreach (var item2 in collof)
                        {
                            if (item.IdSucursal == item2.IdSucursal)
                            {
                                colloff.Add(item2);
                            }
                        }
                    }
                }
                colmost = colloff;
            }
            else
            {
                collof = colmost;
            }

            pas = false;

            //Cuarto filtro
            foreach (var item in listaCa)
            {
                if (item.Selec == true)
                {
                    pas = true;
                }
            }

            if (pas)
            {
                foreach (var item in listaCa)
                {
                    if (item.Selec == true)
                    {
                        foreach (var item2 in collof)
                        {
                            if (item.IdCategoria == item2.CategoriaIdOferta)
                            {
                                colloff.Add(item2);
                            }
                        }
                    }
                }
                colmost = colloff;
            }
            else
            {
                collof = colmost;
            }

            if (colmost.Count()>0)
            {
                colmost.ToList();
                dgOfertasCO.ItemsSource = colmost;
            }
            else
            {
                await this.ShowMessageAsync("Error", "No hay coincidencias para mostrar");
                LimpiarControles();
            }
        }

        
        private void ReportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                Microsoft.Reporting.WinForms.ReportDataSource BDMISOFERTAS = new Microsoft.Reporting.WinForms.ReportDataSource();
                ValoracionesDataSet dataset = new ValoracionesDataSet();

                dataset.BeginInit();

                BDMISOFERTAS.Name = "Valoraciones"; //Name of the report dataset in our .RDLC file
                BDMISOFERTAS.Value = dataset.Valoraciones;
                this._reportViewer.LocalReport.DataSources.Add(BDMISOFERTAS);
                this._reportViewer.LocalReport.ReportEmbeddedResource = "QOfreces.WPF.Reporte Valoraciones.rdlc";

                dataset.EndInit();

                //fill data into adventureWorksDataSet
                ValoracionesDataSetTableAdapters.ValoracionesTableAdapter valoracionesTableAdapter = new ValoracionesDataSetTableAdapters.ValoracionesTableAdapter();
                valoracionesTableAdapter.ClearBeforeFill = true;
                valoracionesTableAdapter.Fill(dataset.Valoraciones);

                _reportViewer.RefreshReport();

                _isReportViewerLoaded = true;
            }
        }
    }
}

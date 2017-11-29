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

namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para MenuAdministrador.xaml
    /// </summary>
    public partial class MenuAdministrador : MetroWindow
    {

        public MenuAdministrador()
        {
            this.Title = string.Format("Administrador {0}     Sucursal: {1}", mainwindow.RetailActual.NombreRetail, mainwindow.SucursalActual.Nombre);
            InitializeComponent();
            lblUsuarioActual.Content = string.Format("{0} {1}", mainwindow.UsuarioACtual.Nombre, mainwindow.UsuarioACtual.Apellido);
            _reportViewer.Load += ReportViewer_Load;
            CargarCombobox();

        }

        private void CargarCombobox()
        {
            // Productos
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllRubros();
            RubroCollections reCol = new RubroCollections(json);
            cbRubroPA.DisplayMemberPath = "TipoRubro";
            cbRubroPA.SelectedValuePath = "IdRubro";
            cbRubroPA.ItemsSource = reCol.ToList();

            cbRubroPE.DisplayMemberPath = "TipoRubro";
            cbRubroPE.SelectedValuePath = "IdRubro";
            cbRubroPE.ItemsSource = reCol.ToList();

            cbRubroPEL.DisplayMemberPath = "TipoRubro";
            cbRubroPEL.SelectedValuePath = "IdRubro";
            cbRubroPEL.ItemsSource = reCol.ToList();

            cbRubroPM.DisplayMemberPath = "TipoRubro";
            cbRubroPM.SelectedValuePath = "IdRubro";
            cbRubroPM.ItemsSource = reCol.ToList();

            cbRubroPMO.DisplayMemberPath = "TipoRubro";
            cbRubroPMO.SelectedValuePath = "IdRubro";
            cbRubroPMO.ItemsSource = reCol.ToList();

            //usuarios

            //Perfiles
            string jsonP = proxy.ReadAllPerfil();
            PerfilCollections perCol = new PerfilCollections(jsonP);
            cbPerfilUA.DisplayMemberPath = "Tipo";
            cbPerfilUA.SelectedValuePath = "IdPerfil";
            cbPerfilUA.ItemsSource = perCol.ToList();

            cbPerfilUE.DisplayMemberPath = "Tipo";
            cbPerfilUE.SelectedValuePath = "IdPerfil";
            cbPerfilUE.ItemsSource = perCol.ToList();

            cbPerfilUEB.DisplayMemberPath = "Tipo";
            cbPerfilUEB.SelectedValuePath = "IdPerfil";
            cbPerfilUEB.ItemsSource = perCol.ToList();

            cbPerfilUM.DisplayMemberPath = "Tipo";
            cbPerfilUM.SelectedValuePath = "IdPerfil";
            cbPerfilUM.ItemsSource = perCol.ToList();

            cbPerfilUMB.DisplayMemberPath = "Tipo";
            cbPerfilUMB.SelectedValuePath = "IdPerfil";
            cbPerfilUMB.ItemsSource = perCol.ToList();





            //Sucursales
            string jsonS = proxy.ReadAllSucursal(mainwindow.RetailActual.IdRetail);
            SucursalCollections suCol = new SucursalCollections(jsonS);
            Sucursal s = new Sucursal();
            cbSucursalUA.DisplayMemberPath = "Nombre";
            cbSucursalUA.SelectedValuePath = "IdSucursal";
            cbSucursalUA.ItemsSource = suCol.ToList();
            
            cbSucursalUE.DisplayMemberPath = "Nombre";
            cbSucursalUE.SelectedValuePath = "IdSucursal";
            cbSucursalUE.ItemsSource = suCol.ToList();

            cbSucursalUM.DisplayMemberPath = "Nombre";
            cbSucursalUM.SelectedValuePath = "IdSucursal";
            cbSucursalUM.ItemsSource = suCol.ToList();

            cbRetailUEB.DisplayMemberPath = "Nombre";
            cbRetailUEB.SelectedValuePath = "IdSucursal";
            cbRetailUEB.ItemsSource = suCol.ToList();

            cbRetailUMB.DisplayMemberPath = "Nombre";
            cbRetailUMB.SelectedValuePath = "IdSucursal";
            cbRetailUMB.ItemsSource = suCol.ToList();


        }

        private void tiProducto_Click(object sender, RoutedEventArgs e)
        {
            if (FlyPerfil.IsOpen == true || flyUsuarios.IsOpen == true || FlyRetail.IsOpen == true || FlyRubro.IsOpen == true || FlyBI.IsOpen == true)
            {
                FlyPerfil.IsOpen = false;
                btnPerfil.Background = Brushes.Orange;
                flyUsuarios.IsOpen = false;
                tiUsuario.Background = Brushes.Orange;
                FlyRetail.IsOpen = false;
                tiEmpresa.Background = Brushes.Orange;
                FlyRubro.IsOpen = false;
                tiRubro.Background = Brushes.Orange;
                FlyBI.IsOpen = false;
                tiReportes.Background = Brushes.Orange;
            }
            flyProductos.IsOpen = true;
            tiProducto.Background = Brushes.Gray;

        }

        private void tiUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (FlyPerfil.IsOpen == true || flyProductos.IsOpen == true || FlyRetail.IsOpen == true || FlyRubro.IsOpen == true || FlyBI.IsOpen == true)
            {
                FlyPerfil.IsOpen = false;
                btnPerfil.Background = Brushes.Orange;
                flyProductos.IsOpen = false;
                tiProducto.Background = Brushes.Orange;
                FlyRetail.IsOpen = false;
                tiEmpresa.Background = Brushes.Orange;
                FlyRubro.IsOpen = false;
                tiRubro.Background = Brushes.Orange;
                FlyBI.IsOpen = false;
                tiReportes.Background = Brushes.Orange;
            }
            flyUsuarios.IsOpen = true;
            tiUsuario.Background = Brushes.Gray;
        }

        private void tiEmpresa_Click(object sender, RoutedEventArgs e)
        {
            if (FlyPerfil.IsOpen == true || flyProductos.IsOpen == true || flyUsuarios.IsOpen == true || FlyRubro.IsOpen == true || FlyBI.IsOpen == true)
            {
                FlyPerfil.IsOpen = false;
                btnPerfil.Background = Brushes.Orange;
                flyProductos.IsOpen = false;
                tiProducto.Background = Brushes.Orange;
                flyUsuarios.IsOpen = false;
                tiUsuario.Background = Brushes.Orange;
                FlyRubro.IsOpen = false;
                tiRubro.Background = Brushes.Orange;
                FlyBI.IsOpen = false;
                tiReportes.Background = Brushes.Orange;
            }
            tiEmpresa.Background = Brushes.Gray;
            FlyRetail.IsOpen = true;
        }

        private void tiRubro_Click(object sender, RoutedEventArgs e)
        {
            if (FlyPerfil.IsOpen == true || flyProductos.IsOpen == true || flyUsuarios.IsOpen == true || FlyRetail.IsOpen == true || FlyBI.IsOpen == true)
            {
                FlyPerfil.IsOpen = false;
                btnPerfil.Background = Brushes.Orange;
                flyProductos.IsOpen = false;
                tiProducto.Background = Brushes.Orange;
                flyUsuarios.IsOpen = false;
                tiUsuario.Background = Brushes.Orange;
                FlyRetail.IsOpen = false;
                tiEmpresa.Background = Brushes.Orange;
                FlyBI.IsOpen = false;
                tiReportes.Background = Brushes.Orange;
            }
            tiRubro.Background = Brushes.Gray; 
            FlyRubro.IsOpen = true;

        }

        private void tiReportes_Click(object sender, RoutedEventArgs e)
        {
            if (FlyPerfil.IsOpen == true || flyProductos.IsOpen == true || flyUsuarios.IsOpen == true || FlyRetail.IsOpen == true || FlyRubro.IsOpen == true)
            {
                FlyPerfil.IsOpen = false;
                btnPerfil.Background = Brushes.Orange;
                flyProductos.IsOpen = false;
                tiProducto.Background = Brushes.Orange;
                flyUsuarios.IsOpen = false;
                tiUsuario.Background = Brushes.Orange;
                FlyRetail.IsOpen = false;
                tiEmpresa.Background = Brushes.Orange;
                FlyRubro.IsOpen = false;
                tiRubro.Background = Brushes.Orange;
            }
            tiReportes.Background = Brushes.Gray;
            FlyBI.IsOpen = true;

        }

        private bool _isReportViewerLoaded;

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                Microsoft.Reporting.WinForms.ReportDataSource BDMISOFERTAS = new Microsoft.Reporting.WinForms.ReportDataSource();
                MovimientosPorFecha dataset = new MovimientosPorFecha();

                dataset.BeginInit();

                BDMISOFERTAS.Name = "Movimientos"; //Name of the report dataset in our .RDLC file
                BDMISOFERTAS.Value = dataset.MovimientosDataTable;
                this._reportViewer.LocalReport.DataSources.Add(BDMISOFERTAS);
                this._reportViewer.LocalReport.ReportEmbeddedResource = "QOfreces.WPF.ReportPreferencias.rdlc";

                dataset.EndInit();

                //fill data into adventureWorksDataSet

                MovimientosPorFechaTableAdapters.MovimientosDataTableTableAdapter movimientosTableAdapter = new MovimientosPorFechaTableAdapters.MovimientosDataTableTableAdapter();
                movimientosTableAdapter.ClearBeforeFill = true;
                movimientosTableAdapter.Fill(dataset.MovimientosDataTable);

                //AdventureWorks2008R2DataSetTableAdapters.SalesOrderDetailTableAdapter salesOrderDetailTableAdapter = new AdventureWorks2008R2DataSetTableAdapters.SalesOrderDetailTableAdapter();
                //salesOrderDetailTableAdapter.ClearBeforeFill = true;
                //salesOrderDetailTableAdapter.Fill(dataset.SalesOrderDetail);

                _reportViewer.RefreshReport();

                _isReportViewerLoaded = true;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mainwindow login = new mainwindow();
            this.Close();
            login.Show();
            
           
        }

        private void btnPerfil_Click(object sender, RoutedEventArgs e)
        {
            if (flyProductos.IsOpen == true || flyUsuarios.IsOpen == true || FlyRetail.IsOpen == true || FlyRubro.IsOpen == true || FlyBI.IsOpen == true)
            {
                btnPerfil.Background = Brushes.Orange;
                flyUsuarios.IsOpen = false;
                tiUsuario.Background = Brushes.Orange;
                FlyRetail.IsOpen = false;
                tiEmpresa.Background = Brushes.Orange;
                FlyRubro.IsOpen = false;
                tiRubro.Background = Brushes.Orange;
                FlyBI.IsOpen = false;
                tiReportes.Background = Brushes.Orange;
                flyProductos.IsOpen = false;
                tiProducto.Background = Brushes.Orange;
            }

            lblNombre.Content = mainwindow.UsuarioACtual.Nombre;
            lblApellido.Content = mainwindow.UsuarioACtual.Apellido;
            lblEmail.Content = mainwindow.UsuarioACtual.Email;
            lblTelefono.Content = mainwindow.UsuarioACtual.NumeroCelular;
            lblFecha.Content = mainwindow.UsuarioACtual.FechaNacimiento;
            if (mainwindow.UsuarioACtual.Sexo.Equals('m'))
            {
                lblGenero.Content = "Masculino";
            }
            else
            {
                lblGenero.Content = "Femenino";
            }


            btnPerfil.Background = Brushes.Gray;
            FlyPerfil.IsOpen = true;
        }

        private async void btnAgregarPA_Click(object sender, RoutedEventArgs e)
        {
            Producto p = new Producto();
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();

            string json;

            json = proxy.ReadAllRubros();
            RubroCollections reCol = new RubroCollections(json);
            string aux = string.Empty;

            p.IdRubro = (int)cbRubroPA.SelectedValue;
            foreach (var item in reCol)
            {
                if (p.IdRubro == item.IdRubro)
                {
                    aux = item.TipoRubro;
                }
            }

            int precio;
            int.TryParse(txtPrecioPA.Text, out precio);
            p.Precio = precio;
            p.CodigoInterno = txtCodigoPA.Text;
            p.Nombre = txtNombrePA.Text;
            p.Sku = txtNombrePA.Text.Substring(0, 4) + aux.Substring(0, 4);
            p.Descripcion = txtDescripcionPA.Text;



            string jsons = p.Serializar();

            if (proxy.CrearProducto(jsons))
            {
                await this.ShowMessageAsync("Exito", "Producto agregado!");
                LimpiarControles();

            }
            else
            {
                await this.ShowMessageAsync("Error", "No se pudo agregar el producto");

            };
        }

        private void LimpiarControles()
        {
            // producto
            txtCodigoPA.Text = "";
            txtCodigoPE.Text = "";
            txtCodigoPM.Text = "";
            txtDescripcionPA.Text = "";
            txtDescripcionPE.Text = "";
            txtDescripcionPM.Text = "";
            txtNombrePA.Text = "";
            txtNombrePE.Text = "";
            txtNombrePEL.Text = "";
            txtNombrePM.Text = "";
            txtNombrePMO.Text = "";
            txtPrecioPA.Text = "";
            txtPrecioPE.Text = "";
            txtPrecioPM.Text = "";
            cbRubroPA.SelectedIndex = 0;
            cbRubroPE.SelectedIndex = 0;
            cbRubroPEL.SelectedIndex = 0;
            cbRubroPM.SelectedIndex = 0;
            cbRubroPMO.SelectedIndex = 0;
            dgProdPM.ItemsSource = null;
            dgProdPE.ItemsSource = null;

        }

        private async void btnAgregarUsuarioUA_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = new Usuario();
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json;

            if (pbContraseñaUA.Password == pbContraseña2UA.Password)
            {

                user.IdSucursal = (int)cbSucursalUA.SelectedValue;
                user.IdPerfil = (int)cbPerfilUA.SelectedValue;
                user.NombreUsuario = txtUsuarioUA.Text;
                user.Password = pbContraseñaUA.Password;
                user.Nombre = txtNombreUA.Text;
                user.Apellido = txtApellidoUA.Text;
                user.Rut = txtRutUA.Text;
                user.FechaNacimiento = dpFechaUA.SelectedDate.Value;
                if (rbFemUA.IsChecked == true)
                {
                    user.Sexo = 'F';
                }
                else
                {
                    user.Sexo = 'M';
                }
                user.Email = txtEmailUA.Text;
                user.NumeroCelular = int.Parse(txtCelularUA.Text);
                if (chActivarUA.IsChecked == true)
                {
                    user.Activo = '1';
                }
                else
                {
                    user.Activo = '0';
                }

                if (user.IdPerfil != 1)
                {
                    user.Puntos = 0;
                }

                json = user.Serializar();

                if (proxy.CrearUsuario(json))
                {
                    await this.ShowMessageAsync("Exito", "Usuario creado");
                    LimpiarControles();
                    
                }
                else
                {
                    await this.ShowMessageAsync("Error", "No se a creado al usuario");
                }
            }
            else
            {
                await this.ShowMessageAsync("Error", "Las contraseñas no coinciden");
                LimpiarControles();
                
            }
        }
    }
}

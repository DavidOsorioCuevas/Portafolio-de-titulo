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
    }
}

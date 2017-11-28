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
            lblUsuarioActual.Content = mainwindow.UsuarioACtual.NombreUsuario;
            _reportViewer.Load += ReportViewer_Load;

        }

        private void tiProducto_Click(object sender, RoutedEventArgs e)
        {
            if (flyUsuarios.IsOpen == true || FlyRetail.IsOpen == true || FlyRubro.IsOpen == true || FlyBI.IsOpen == true)
            {
                flyUsuarios.IsOpen = false;
                FlyRetail.IsOpen = false;
                FlyRubro.IsOpen = false;
                FlyBI.IsOpen = false;
            }
            flyProductos.IsOpen = true;
        }

        private void tiUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (flyProductos.IsOpen == true || FlyRetail.IsOpen == true || FlyRubro.IsOpen == true || FlyBI.IsOpen == true)
            {
                flyProductos.IsOpen = false;
                FlyRetail.IsOpen = false;
                FlyRubro.IsOpen = false;
                FlyBI.IsOpen = false;
            }
            flyUsuarios.IsOpen = true;
        }

        private void tiEmpresa_Click(object sender, RoutedEventArgs e)
        {
            if (flyProductos.IsOpen == true || flyUsuarios.IsOpen == true || FlyRubro.IsOpen == true || FlyBI.IsOpen == true)
            {
                flyProductos.IsOpen = false;
                flyUsuarios.IsOpen = false;
                FlyRubro.IsOpen = false;
                FlyBI.IsOpen = false;
            }
            FlyRetail.IsOpen = true;
        }

        private void tiRubro_Click(object sender, RoutedEventArgs e)
        {
            if (flyProductos.IsOpen == true || flyUsuarios.IsOpen == true || FlyRetail.IsOpen == true || FlyBI.IsOpen == true)
            {
                flyProductos.IsOpen = false;
                flyUsuarios.IsOpen = false;
                FlyRetail.IsOpen = false;
                FlyBI.IsOpen = false;
            }
            FlyRubro.IsOpen = true;

        }

        private void tiReportes_Click(object sender, RoutedEventArgs e)
        {
            if (flyProductos.IsOpen == true || flyUsuarios.IsOpen == true || FlyRetail.IsOpen == true || FlyRubro.IsOpen == true)
            {
                flyProductos.IsOpen = false;
                flyUsuarios.IsOpen = false;
                FlyRetail.IsOpen = false;
                FlyRubro.IsOpen = false;
            }
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
    }
}

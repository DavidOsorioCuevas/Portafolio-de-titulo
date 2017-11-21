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
    /// Lógica de interacción para MenuEncargado.xaml
    /// </summary>
    public partial class MenuEncargado : MetroWindow
    {
        public MenuEncargado()
        {
            InitializeComponent();
            lblUsuarioActual.Content = mainwindow.UsuarioACtual.NombreUsuario;
        }

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
    }
}

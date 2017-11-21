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
            InitializeComponent();
            lblUsuarioActual.Content = mainwindow.UsuarioACtual.NombreUsuario;
            
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
    }
}

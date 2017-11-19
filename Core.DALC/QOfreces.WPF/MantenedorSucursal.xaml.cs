
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
    /// Lógica de interacción para MantenedorSucursal.xaml
    /// </summary>
    public partial class MantenedorSucursal : MetroWindow
    {
        public MantenedorSucursal()
        {
            InitializeComponent();
            Deshabilitar();
        }

        private void Deshabilitar()
        {
            tiAgregar.IsEnabled = false;
        }

        private void tiAgregar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = false;
            tiModificar.IsEnabled = true;
            tiEliminar.IsEnabled = true;
            dgRetail.Visibility = Visibility.Hidden;
            txtListar.Visibility = Visibility.Hidden;
            btnListar.Visibility = Visibility.Hidden;
            btnEjecutar.Content = "Agregar";
        }

        private void tiModificar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = true;
            tiModificar.IsEnabled = false;
            tiEliminar.IsEnabled = true;
            dgRetail.Visibility = Visibility.Visible;
            txtListar.Visibility = Visibility.Visible;
            btnListar.Visibility = Visibility.Visible;
            btnEjecutar.Content = "Modificar";
        }

        private void tiEliminar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = true;
            tiModificar.IsEnabled = true;
            tiEliminar.IsEnabled = false;
            dgRetail.Visibility = Visibility.Visible;
            txtListar.Visibility = Visibility.Visible;
            btnListar.Visibility = Visibility.Visible;
            btnEjecutar.Content = "Eliminar";
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEjecutar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

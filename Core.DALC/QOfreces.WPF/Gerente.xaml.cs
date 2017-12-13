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
    /// Lógica de interacción para Gerente.xaml
    /// </summary>
    public partial class Gerente : MetroWindow
    {
        Validaciones validador = new Validaciones();
        public Gerente()
        {
            this.Title = string.Format("Encargado {0}     Sucursal: {1}", mainwindow.RetailActual.NombreRetail, mainwindow.SucursalActual.Nombre);
            InitializeComponent();
            lblNombre.Visibility = Visibility.Hidden;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            if (cbTiendas.SelectedIndex.Equals(-1))
            {
                lblNombre.Content = "Seleccione una opcion";
                lblNombre.Visibility = Visibility.Visible;
            }
            this.Close();
        }
    }
}

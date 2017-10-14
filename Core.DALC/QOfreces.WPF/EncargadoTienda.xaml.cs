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
    /// Lógica de interacción para EncargadoTienda.xaml
    /// </summary>
    public partial class EncargadoTienda : MetroWindow
    {
        public EncargadoTienda()
        {
            InitializeComponent();
                     
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllOfertas();
            Core.Negocio.OfertaCollections collOf = new Core.Negocio.OfertaCollections(json);
            dataGridOfertas.ItemsSource = collOf;
            
        }

        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {
            GenOferta genOf = new GenOferta();
            genOf.Owner = this;
            genOf.Show();
        }

        private async void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("Alerta!", "Este evento aun no se implementa.");
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            mainwindow mai = new mainwindow();
            this.Close();
            mai.Show();
        }
    }
}

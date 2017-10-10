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

namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para EncargadoTienda.xaml
    /// </summary>
    public partial class EncargadoTienda : Window
    {
        public EncargadoTienda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllOfertas();
            Core.Negocio.OfertaCollections collOf = new Core.Negocio.OfertaCollections(json);
            dataGridOfertas.ItemsSource = collOf;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GenerarOferta genOf = new GenerarOferta();
            genOf.Owner = this;
            genOf.Show();
        }
    }
}

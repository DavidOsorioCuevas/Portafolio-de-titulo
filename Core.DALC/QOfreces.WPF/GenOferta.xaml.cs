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
    /// Lógica de interacción para GenOferta.xaml
    /// </summary>
    public partial class GenOferta : Window
    {

        public GenOferta()
        {
            InitializeComponent();

        }

        private void btnListarProd_Click(object sender, RoutedEventArgs e)
        {

            dgProd.Visibility = Visibility.Visible;
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllProductos();
            Core.Negocio.ProductoCollections collprod = new Core.Negocio.ProductoCollections(json);
            dgProd.ItemsSource = collprod;
        }

        private void btnGenOferta_Click(object sender, RoutedEventArgs e)
        {


            List<Core.Negocio.Producto> listProd = new List<Core.Negocio.Producto>();
            Core.Negocio.Producto pro = new Core.Negocio.Producto();
            //instancia de checkbox de datagrid
            CheckBox chk = (CheckBox)sender;

            //recorre items de datagrid
            for (int i = 0; i < dgProd.Items.Count; i++)
            {
                if (chk.IsChecked.Value)
                {
                    //obtener valores de chequeados
                    
                }
            }
            

        }
    }
}

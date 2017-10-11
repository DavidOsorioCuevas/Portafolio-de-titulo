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
using Core.Negocio;
using System.Collections.ObjectModel;
using System.Collections;

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
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllProductos();
            Core.Negocio.ProductoCollections collprod = new Core.Negocio.ProductoCollections(json);
            collprod.ToList();
            dgProd.ItemsSource = collprod;

        }



        private void btnGenOferta_Click(object sender, RoutedEventArgs e)
        {
            var itemsSource = dgProd.ItemsSource as IEnumerable;

            if (itemsSource != null)
            {
                foreach (var item in itemsSource)
                {
                    var row = dgProd.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null)
                    {
                        MessageBox.Show(row.ToString());
                    }

                }
            }
        }
    }




}

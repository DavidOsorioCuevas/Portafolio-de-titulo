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
using System.Data;

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
            var rows = GetDataGridRows(dgProd);

            foreach (DataGridRow r in rows)
            {
                DataRowView rv = (DataRowView)r.Item;
                MessageBox.Show( rv.DataView.ToString());
            }

        }

        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid dgProd)
        {
            var itemsSource = dgProd.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = dgProd.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }
    }

}


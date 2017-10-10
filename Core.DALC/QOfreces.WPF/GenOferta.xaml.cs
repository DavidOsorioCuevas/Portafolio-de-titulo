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

            //dgProd.Columns.Add("ID");
            foreach (var item in collprod)
            {
                dgProd.Items.Add(item.IdProducto);
                dgProd.Items.Add(item.IdRubro);
                dgProd.Items.Add(item.Precio);
                dgProd.Items.Add(item.CodigoInterno);
                dgProd.Items.Add(item.Nombre);
                dgProd.Items.Add(item.Sku);
                dgProd.Items.Add(item.Descripcion);

            }


        }
    }
}

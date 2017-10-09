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
    /// Lógica de interacción para MantenedorProducto.xaml
    /// </summary>
    public partial class MantenedorProducto : Window
    {
        public MantenedorProducto()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            Core.Negocio.Producto p = new Core.Negocio.Producto();
            
            p.IdRubro = 2;
            p.Precio = 100;
            p.CodigoInterno = "cod";            
            p.Nombre = "doritos";
            p.Sku = "SKU";
            p.Descripcion = "doritos de queso";


            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = p.Serializar();

            if (proxy.CrearProducto(json))
            {
                MessageBox.Show("HELL YEAH!");
            } ;

           
            




        }

        private void btnListarProd_Click(object sender, RoutedEventArgs e)
        {
            dGridProd.Visibility = Visibility.Visible;
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllProductos();
            Core.Negocio.ProductoCollections collprod = new Core.Negocio.ProductoCollections(json);
            dGridProd.ItemsSource = collprod;

            List<CheckBox> checkBoxlist = new List<CheckBox>();



            foreach (CheckBox c in checkBoxlist)
            {
                MessageBox.Show("check!");
            }

        }
    }
}

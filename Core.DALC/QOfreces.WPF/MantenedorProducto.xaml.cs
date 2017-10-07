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

            p.IdProducto = 1;
            p.IdRubro = 2;
            p.Precio = 100;
            p.CodigoInterno = "cod";
            p.Nombre = "doritos";
            p.Descripcion = "doritos de queso";
            string json = p.Serializar();

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();

            if (proxy.CrearProducto(json))
            {
                MessageBox.Show("HELL YEAH!");
            } ;

           
            




        }
    }
}

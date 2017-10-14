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
using System.ComponentModel;

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




        
        private void btnGenOferta_Click(object sender, RoutedEventArgs e)
        {

            List<Producto> lstprod = new List<Producto>();
           var list = dgProd.Items.OfType<Producto>();
                    
            foreach (var item in list)
            {
                if (item.Selec == true)
                {
                    Producto prod = new Producto();
                    prod.IdProducto = item.IdProducto;
                    lstprod.Add(prod);
                }
                
                
            }

          

        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllProductos();
            Core.Negocio.ProductoCollections collprod = new Core.Negocio.ProductoCollections(json);
            collprod.ToList();
            dgProd.ItemsSource = collprod;
        }

        private void dgProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}


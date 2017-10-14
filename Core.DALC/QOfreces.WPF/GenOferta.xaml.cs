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
                    prod.Sku = item.Sku;
                    prod.Nombre = item.Nombre;
                    prod.Precio = item.Precio;
                    lstprod.Add(prod);
                }                              
            }

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            Oferta of = new Oferta();
            of.ImagenOferta = "";
            of.MinProductos = int.Parse(txtMinProd.Text);
            of.MaxProductos = int.Parse(txtMaxProd.Text);
            of.PrecioAntes = 1200;
            of.PrecioOferta = 400;
            of.EstadoOferta = Convert.ToChar("n");
            of.FechaOferta = dpFecha.SelectedDate;
            of.IdSucursal = 1;
            of.CategoriaIdOferta = 1;
            of.IdRegion = 1;
            of.IdComuna = 1;
            of.Nombre = txtNombre.Text;
            of.Descripcion = txtDescOf.Text;
            of.OfertaDia = "";
            string json = of.Serializar();
            if (proxy.CrearOferta(json))
            {
                MessageBox.Show("YEAH!");
            }
            else
            {
                MessageBox.Show("OUSH!");
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

    }

}


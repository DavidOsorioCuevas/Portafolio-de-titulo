using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para MantenedorProducto.xaml
    /// </summary>
    public partial class MantenedorProducto : MetroWindow
    {
        public MantenedorProducto()
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

        private async void btnAgregar_Click(object sender, RoutedEventArgs e)
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
                await this.ShowMessageAsync("Exito", "Producto agregado!");
                txtNombre.Clear();
                txtDescripcion.Clear();
                txtPrecio.Clear();
                cbRubro.SelectedIndex = 0;
                cbSucursal.SelectedIndex = 0;
            }
            else
            {
                await this.ShowMessageAsync("Error", "No se pudo agregar el producto");

            };
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("Alerta!", "Este evento aun no esta implementado");
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("Alerta!", "Este evento aun no esta implementado");
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

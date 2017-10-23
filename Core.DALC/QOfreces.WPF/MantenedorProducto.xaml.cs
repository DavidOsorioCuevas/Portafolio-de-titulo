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
            CargarCombobox();

        }

        private void CargarCombobox()
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllRubros();
            RubroCollections reCol = new RubroCollections(json);
            cbRubro.DisplayMemberPath = "TipoRubro";
            cbRubro.SelectedValuePath = "IdRubro";
            cbRubro.ItemsSource = reCol.ToList();

            json = proxy.ReadAllSucursal();
            SucursalCollections suc = new SucursalCollections(json);
            cbSucursal.DisplayMemberPath = "Nombre";
            cbSucursal.SelectedValuePath = "IdSucursal";
            cbSucursal.ItemsSource = suc.ToList();
            
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

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllRubros();
            RubroCollections reCol = new RubroCollections(json);
            string aux = string.Empty;

            p.IdRubro = (int)cbRubro.SelectedValue;
            foreach (var item in reCol)
            {
                if (p.IdRubro == item.IdRubro)
                {
                    aux = item.TipoRubro;
                }
            }
            int precio;
            int.TryParse(txtPrecio.Text, out precio);
            p.Precio = precio;
            p.CodigoInterno = txtCod.Text;
            p.Nombre = txtNombre.Text;
            p.Sku = txtNombre.Text.Substring(0, 4) + aux.Substring(0,4);
            p.Descripcion = txtDescripcion.Text;


           
            string jsons = p.Serializar();

            if (proxy.CrearProducto(jsons))
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

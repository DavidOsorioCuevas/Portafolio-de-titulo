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

        private void tiAgregar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = false;
            tiModificar.IsEnabled = true;
            tiEliminar.IsEnabled = true;
            dgProd.Visibility = Visibility.Hidden;
            txtBuscar.Visibility = Visibility.Hidden;
            btnListarProd.Visibility = Visibility.Hidden;
            btnEjecutar.Content = "Agregar";
            HabilitarControles();
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

        private void tiModificar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = true;
            tiModificar.IsEnabled = false;
            tiEliminar.IsEnabled = true;
            dgProd.Visibility = Visibility.Visible;
            txtBuscar.Visibility = Visibility.Visible;
            btnListarProd.Visibility = Visibility.Visible;
            btnEjecutar.Content = "Modificar";
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            txtCod.IsEnabled = true;
            txtDescripcion.IsEnabled = true;
            txtNombre.IsEnabled = true;
            txtPrecio.IsEnabled = true;
            cbRubro.IsEnabled = true;
            cbSucursal.IsEnabled = true;
        }

        private void tiEliminar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = true;
            tiModificar.IsEnabled = true;
            tiEliminar.IsEnabled = false;
            dgProd.Visibility = Visibility.Visible;
            txtBuscar.Visibility = Visibility.Visible;
            btnListarProd.Visibility = Visibility.Visible;
            btnEjecutar.Content = "Eliminar";
            DeshabilitarControles();
        }

        private void DeshabilitarControles()
        {
            txtCod.IsEnabled = false;
            txtDescripcion.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtPrecio.IsEnabled = false;
            cbRubro.IsEnabled = false;
            cbSucursal.IsEnabled = false;
        }

        private async void btnEjecutar_Click(object sender, RoutedEventArgs e)
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
                LimpiarControles();
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

        private void LimpiarControles()
        {
            txtCod.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            cbRubro.SelectedIndex = 0;
            cbSucursal.SelectedIndex = 0;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}

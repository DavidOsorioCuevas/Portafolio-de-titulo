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
        Validaciones validador = new Validaciones();

        public MantenedorProducto()
        {
            InitializeComponent();
            CargarCombobox();
            lblNombre.Visibility = Visibility.Hidden;
            lblCodigo.Visibility = Visibility.Hidden;
            lblDescripcion.Visibility = Visibility.Hidden;
            lblPrecio.Visibility = Visibility.Hidden;
            lblRubro.Visibility = Visibility.Hidden;

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

        }



        private async void btnEjecutar_Click(object sender, RoutedEventArgs e)
        {
            lblNombre.Content = validador.validarNombre(txtNombre.Text);
            lblPrecio.Content = validador.validarPrecio(txtPrecio.Text);
            lblCodigo.Content = validador.validarCodigoInterno(txtCod.Text);

            Producto p = new Producto();
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();

            if (cbRubro.SelectedIndex.Equals(-1))
            {
                lblRubro.Content = "Seleccione una opcion";
                lblRubro.Visibility = Visibility.Visible;
            }
            else
            {
                if (lblNombre.Content.Equals("OK"))
                {
                    if (lblPrecio.Content.Equals("OK"))
                    {
                        if (lblCodigo.Content.Equals("OK"))
                        {

                            string json;
                            switch (btnEjecutar.Content.ToString())
                            {
                                case "Agregar":

                                    json = proxy.ReadAllRubros();
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
                                    p.Sku = txtNombre.Text.Substring(0, 4) + aux.Substring(0, 4);
                                    p.Descripcion = txtDescripcion.Text;



                                    string jsons = p.Serializar();

                                    if (proxy.CrearProducto(jsons))
                                    {
                                        await this.ShowMessageAsync("Exito", "Producto agregado!");
                                        LimpiarControles();

                                    }
                                    else
                                    {
                                        await this.ShowMessageAsync("Error", "No se pudo agregar el producto");

                                    };

                                    break;

                                case "Modificar":

                                    json = proxy.ReadAllRubros();
                                    RubroCollections ruCol = new RubroCollections(json);
                                    string au = string.Empty;

                                    p.IdRubro = (int)cbRubro.SelectedValue;
                                    foreach (var item in ruCol)
                                    {
                                        if (p.IdRubro == item.IdRubro)
                                        {
                                            au = item.TipoRubro;
                                        }
                                    }
                                    int preci;
                                    int.TryParse(txtPrecio.Text, out preci);
                                    p.Precio = preci;
                                    p.CodigoInterno = txtCod.Text;
                                    p.Nombre = txtNombre.Text;
                                    p.Sku = txtNombre.Text.Substring(0, 4) + au.Substring(0, 4);
                                    p.Descripcion = txtDescripcion.Text;


                                    Producto pr = (Producto)dgProd.SelectedValue;
                                    p.IdProducto = pr.IdProducto;
                                    jsons = p.Serializar();

                                    if (proxy.ActualizarProducto(jsons))
                                    {
                                        await this.ShowMessageAsync("Exito", "Producto Modificado!");
                                        LimpiarControles();

                                    }
                                    else
                                    {
                                        await this.ShowMessageAsync("Error", "No se pudo agregar el producto");

                                    };

                                    break;

                                case "Eliminar":

                                    Producto pro = (Producto)dgProd.SelectedValue;
                                    json = pro.Serializar();
                                    if (proxy.EliminarProducto(json))
                                    {
                                        await this.ShowMessageAsync("Exito", "Producto eliminado");
                                        LimpiarControles();
                                    }
                                    else
                                    {
                                        await this.ShowMessageAsync("Error", "No se a podido eliminar");
                                        LimpiarControles();
                                    }

                                    break;

                                default:
                                    break;
                            }
                        }
                        else
                        {
                            lblCodigo.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        lblPrecio.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    lblNombre.Visibility = Visibility.Visible;
                }
            }
        }

        private void LimpiarControles()
        {
            txtCod.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            cbRubro.SelectedIndex = 0;
            dgProd.ItemsSource = null;

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgProd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();


            if (dgProd.SelectedItem != null)
            {

                cbRubro.ItemsSource = null;

                Producto p = (Producto)dgProd.SelectedItem;
                txtCod.Text = p.CodigoInterno;
                txtDescripcion.Text = p.Descripcion;
                txtNombre.Text = p.Nombre;
                txtPrecio.Text = p.Precio.ToString();

                string json = proxy.ReadAllRubros();
                RubroCollections ruCol = new RubroCollections(json);
                cbRubro.DisplayMemberPath = "TipoRubro";
                cbRubro.SelectedValuePath = "IdRubro";
                cbRubro.ItemsSource = ruCol.ToList();
                for (int i = 0; i < cbRubro.Items.Count; i++)
                {
                    Rubro rubro = (Rubro)cbRubro.Items[i];
                    if (rubro.IdRubro == p.IdRubro)
                    {
                        cbRubro.SelectedIndex = i;
                    }
                }



            }
        }

        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
            {
                lblNombre.Visibility = Visibility.Hidden;
            }
            else
            {

                lblNombre.Content = "Nombre no puede contener numeros";
                lblNombre.Visibility = Visibility.Visible;

            }

        }

        private void txtPrecio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57)
            {
                lblPrecio.Visibility = Visibility.Hidden;
            }
            else
            {
                lblPrecio.Content = "Precio no puede contener letras";
                lblPrecio.Visibility = Visibility.Visible;
            }
        }
    }
}


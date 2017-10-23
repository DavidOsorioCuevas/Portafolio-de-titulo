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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using Core.Negocio;

namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para MantenedorRetail.xaml
    /// </summary>
    public partial class MantenedorRetail : MetroWindow
    {
        public MantenedorRetail()
        {
            InitializeComponent();
            Deshabilitar();
            CargarCombobox();
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            txtRut.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtListar.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            cbComuna.SelectedIndex = 0;
            cbRegion.SelectedIndex = 0;
            dgRetail.ItemsSource = null;
        }

        private void CargarCombobox()
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string jsonS = proxy.ReadAllRegiones();
            RegionCollections reCol = new RegionCollections(jsonS);
            cbRegion.DisplayMemberPath = "Nombre";
            cbRegion.SelectedValuePath = "IdRegion";
            cbRegion.ItemsSource = reCol.ToList();

            cbComuna.IsEnabled = false;
            
        }

        private void Deshabilitar()
        {
            tiAgregar.IsEnabled = false;
        }

        private void tiModificar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = true;
            tiModificar.IsEnabled = false;
            tiEliminar.IsEnabled = true;
            dgRetail.Visibility = Visibility.Visible;
            txtListar.Visibility = Visibility.Visible;
            btnListar.Visibility = Visibility.Visible;
            btnEjecutar.Content = "Modificar";
        }

        private void tiAgregar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = false;
            tiModificar.IsEnabled = true;
            tiEliminar.IsEnabled = true;
            dgRetail.Visibility = Visibility.Hidden;
            txtListar.Visibility = Visibility.Hidden;
            btnListar.Visibility = Visibility.Hidden;
            btnEjecutar.Content = "Agregar";
            
        }

        private void tiEliminar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = true;
            tiModificar.IsEnabled = true;
            tiEliminar.IsEnabled = false;
            dgRetail.Visibility = Visibility.Visible;
            txtListar.Visibility = Visibility.Visible;
            btnListar.Visibility = Visibility.Visible;
            btnEjecutar.Content = "Eliminar";
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllRetail();
            Core.Negocio.RetailCollections collRet = new Core.Negocio.RetailCollections(json);
            collRet.ToList();
            dgRetail.ItemsSource = collRet;
        }

        private void dgRetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgRetail.SelectedItem != null)
            {

                cbComuna.ItemsSource = null;
                cbRegion.ItemsSource = null;
                Retail r = (Retail)dgRetail.SelectedItem;
                txtRut.Text = r.RutRetail;
                txtNombre.Text = r.NombreRetail;
                txtRazonSocial.Text = r.RazonSocial;
                txtTelefono.Text = r.Telefono.ToString();
                txtEmail.Text = r.Email;
                txtDireccion.Text = r.Direccion;

                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
                string jsonS = proxy.ReadAllRegiones();
                RegionCollections reCol = new RegionCollections(jsonS);
                cbRegion.DisplayMemberPath = "Nombre";
                cbRegion.SelectedValuePath = "IdRegion";
                cbRegion.ItemsSource = reCol.ToList();

                for (int i = 0; i < cbRegion.Items.Count; i++)
                {
                    Region re = (Region)cbRegion.Items[i];
                    if (re.IdRegion == r.IdRegion)
                    {
                        cbRegion.SelectedIndex = i;
                    }
                }

                
                string json = proxy.ReadAllComuna();
                ComunaCollections comCol = new ComunaCollections(json);
                cbComuna.DisplayMemberPath = "Nombre";
                cbComuna.SelectedValuePath = "IdComuna";
                cbComuna.ItemsSource = comCol.ToList();

                for (int i = 0; i < cbComuna.Items.Count; i++)
                {
                    Comuna co = (Comuna)cbComuna.Items[i];
                    if (co.IdComuna == r.IdComuna)
                    {
                        cbComuna.SelectedIndex = i;
                    }
                }


            }
        }

        private async void btnEjecutar_Click(object sender, RoutedEventArgs e)
        {
            Retail ret = new Retail();
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json;
            switch (btnEjecutar.Content.ToString())
            {
                case "Agregar":
                    
                    ret.RutRetail = txtRut.Text;
                    ret.NombreRetail = txtNombre.Text;
                    ret.RazonSocial = txtRazonSocial.Text;
                    int tele;
                    int.TryParse(txtTelefono.Text, out tele);
                    ret.Telefono = tele;
                    ret.Email = txtEmail.Text;
                    ret.Direccion = txtDireccion.Text;
                    ret.IdRegion = (int)cbRegion.SelectedValue;
                    ret.IdComuna = (int)cbComuna.SelectedValue;

                    json = ret.Serializar();
                    if (proxy.CrearRetail(json))
                    {
                        await this.ShowMessageAsync("Exito", "Retail creado");
                        LimpiarControles();

                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "No se a podido crear");
                        LimpiarControles();
                    }

                    break;

                case "Modificar":

                    ret.RutRetail = txtRut.Text;
                    ret.NombreRetail = txtNombre.Text;
                    ret.RazonSocial = txtRazonSocial.Text;
                    int tel;
                    int.TryParse(txtTelefono.Text, out tel);
                    ret.Telefono = tel;
                    ret.Email = txtEmail.Text;
                    ret.Direccion = txtDireccion.Text;
                    ret.IdRegion = (int)cbRegion.SelectedValue;
                    ret.IdComuna = (int)cbComuna.SelectedValue;
                    Retail id = (Retail)dgRetail.SelectedItem;
                    ret.IdRetail = id.IdRetail;
                    json = ret.Serializar();
                    if (proxy.ActualizarRetail(json))
                    {
                        await this.ShowMessageAsync("Exito", "Retail actualizado");
                        LimpiarControles();

                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "No se a podido actualizar");
                        LimpiarControles();
                    }
                    break;

                case "Eliminar":

                    Retail r = (Retail)dgRetail.SelectedValue;
                    json = r.Serializar();
                    if (proxy.EliminarRetail(json))
                    {
                        await this.ShowMessageAsync("Exito", "Retail actualizado");
                        LimpiarControles();
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "No se a podido actualizar");
                        LimpiarControles();
                    }

                    break;

                default:
                    break;
            }
        }

        private void cbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbRegion.SelectedItem != null)
            {


                Region reg = (Region)cbRegion.SelectedItem;

                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
                string json = proxy.ReadAllComuna();
                ComunaCollections c = new ComunaCollections(json);

                ComunaCollections mostrar = new ComunaCollections();

                cbComuna.IsEnabled = true;
                cbComuna.DisplayMemberPath = "Nombre";
                cbComuna.SelectedValuePath = "IdComuna";
                foreach (var item in c)
                {
                    if (item.IdRegion == reg.IdRegion)
                    {
                        mostrar.Add(item);
                    }
                }

                cbComuna.ItemsSource = mostrar.ToList();
            }

           
        }
    }
}

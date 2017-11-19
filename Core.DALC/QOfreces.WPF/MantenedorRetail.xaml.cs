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
using System.Text.RegularExpressions;

namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para MantenedorRetail.xaml
    /// </summary>
    public partial class MantenedorRetail : MetroWindow
    {
        Validaciones validador = new Validaciones();
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
            lblComuna.Visibility = Visibility.Hidden;
            lblDireccion.Visibility = Visibility.Hidden;
            lblEmail.Visibility = Visibility.Hidden;
            lblNombre.Visibility = Visibility.Hidden;
            lblRazonSocial.Visibility = Visibility.Hidden;
            lblRegion.Visibility = Visibility.Hidden;
            lblRut.Visibility = Visibility.Hidden;
            lblTelefono.Visibility = Visibility.Hidden;
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
            lblComuna.Visibility = Visibility.Hidden;
            lblDireccion.Visibility = Visibility.Hidden;
            lblEmail.Visibility = Visibility.Hidden;
            lblNombre.Visibility = Visibility.Hidden;
            lblRazonSocial.Visibility = Visibility.Hidden;
            lblRegion.Visibility = Visibility.Hidden;
            lblRut.Visibility = Visibility.Hidden;
            lblTelefono.Visibility = Visibility.Hidden;

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
            lblNombre.Content = validador.validarNombre(txtNombre.Text);
            lblEmail.Content = validador.validarCorreo(txtEmail.Text);
            lblRazonSocial.Content = validador.validarRazonSocial(txtRazonSocial.Text);
            lblRut.Content = validador.validarRut(txtRut.Text);

            Retail ret = new Retail();
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            if (cbComuna.SelectedIndex.Equals(-1))
            {
                lblComuna.Content = "Seleccione una opcion";
                lblComuna.Visibility = Visibility.Visible;
            }

            if (lblRut.Content.Equals("OK"))
            {
                lblRut.Visibility = Visibility.Hidden;
                if (lblNombre.Content.Equals("OK"))
                {
                    lblNombre.Visibility = Visibility.Hidden;
                    if (lblRazonSocial.Content.Equals("OK"))
                    {
                        lblRazonSocial.Visibility = Visibility.Hidden;
                        if (lblEmail.Content.Equals("OK"))
                        {
                            lblEmail.Visibility = Visibility.Hidden;
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
                                        await this.ShowMessageAsync("Exito", "Retail eliminado");
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
                            lblEmail.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        lblRazonSocial.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    lblNombre.Visibility = Visibility.Visible;
                }

            }
            else
            {
                lblRut.Visibility = Visibility.Visible;
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

        private void txtNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (string.IsNullOrEmpty(e.Text))
            {
                lblTelefono.Content = "Telefono no debe estar vacio";
                lblTelefono.Visibility = Visibility.Visible;
            }
            if (e.Text.Length == 0)
            {
                lblTelefono.Content = "Telefono no debe estar vacio forma e";
                lblTelefono.Visibility = Visibility.Visible;
            }
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

        private void txtTelefono_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (string.IsNullOrEmpty(e.Text))
            {
                lblTelefono.Content = "Telefono no debe estar vacio";
                lblTelefono.Visibility = Visibility.Visible;
            }
            if (ascci >= 48 && ascci <= 57)
            {
                lblTelefono.Visibility = Visibility.Hidden;
            }
            else
            {
                lblTelefono.Content = "Ingrese solo Numeros";
                lblTelefono.Visibility = Visibility.Visible;
            }

        }

        private void txtEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (String.IsNullOrEmpty(e.Text))
            {
                lblEmail.Content = "El correo no puede estar en blanco";
            }
            if (e.Text != null && !Regex.IsMatch(e.Text, "^[\\w-]+(\\.[\\w-]+)*@([a-z0-9-]+(\\.[a-z0-9-]+)*?\\.[a-z]{2,6}|(\\d{1,3}\\.){3}\\d{1,3})(:\\d{4})?$", RegexOptions.IgnoreCase))
            {
                lblEmail.Content = "Digite un correo válido";
            }
            else
            {
                lblEmail.Content = "OK";
            }
        }
    }
}

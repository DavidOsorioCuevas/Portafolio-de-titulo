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
    /// Lógica de interacción para MatenedorUsuarios.xaml
    /// </summary>
    public partial class MantenedorUsuarios : MetroWindow
    {
        Validaciones validador = new Validaciones();

        public MantenedorUsuarios()
        {
            InitializeComponent();
            CargarCombobox();
            tiAgregar.IsEnabled = false;
            lblApellido.Visibility = Visibility.Hidden;
            lblContraseña.Visibility = Visibility.Hidden;
            lblContraseña2.Visibility = Visibility.Hidden;
            lblEmail.Visibility = Visibility.Hidden;
            lblFechaNacimiento.Visibility = Visibility.Hidden;
            lblNombre.Visibility = Visibility.Hidden;
            lblNombreUsuario.Visibility = Visibility.Hidden;
            lblPuntos.Visibility = Visibility.Hidden;
            lblRut.Visibility = Visibility.Hidden;
            lblSucursal.Visibility = Visibility.Hidden;
            lblTelefono.Visibility = Visibility.Hidden;
            lblTipo.Visibility = Visibility.Hidden;

        }

        private void CargarCombobox()
        {
            //Perfiles
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string jsonP = proxy.ReadAllPerfil();
            PerfilCollections perCol = new PerfilCollections(jsonP);
            cbPerfil.DisplayMemberPath = "Tipo";
            cbPerfil.SelectedValuePath = "IdPerfil";
            cbPerfil.ItemsSource = perCol.ToList();
            cbPerfil.SelectedIndex = 0;

            //Sucursales
            string jsonS = proxy.ReadAllSucursal(mainwindow.RetailActual.IdRetail);
            SucursalCollections suCol = new SucursalCollections(jsonS);
            Sucursal s = new Sucursal();
            cbSucursal.DisplayMemberPath = "Nombre";
            cbSucursal.SelectedValuePath = "IdSucursal";
            cbSucursal.ItemsSource = suCol.ToList();
            cbSucursal.SelectedIndex = 0;

        }

        private void tiAgregar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = false;
            tiModificar.IsEnabled = true;
            tiEliminar.IsEnabled = true;
            dgUsuario.Visibility = Visibility.Hidden;
            txtListar.Visibility = Visibility.Hidden;
            btnListar.Visibility = Visibility.Hidden;
            btnEjecutar.Content = "Agregar";


            HabilitarControles();
        }

        private void tiModificar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = true;
            tiModificar.IsEnabled = false;
            tiEliminar.IsEnabled = true;
            dgUsuario.Visibility = Visibility.Visible;
            txtListar.Visibility = Visibility.Visible;
            btnListar.Visibility = Visibility.Visible;
            btnEjecutar.Content = "Modificar";

            HabilitarControles();
        }


        private void tiEliminar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = true;
            tiModificar.IsEnabled = true;
            tiEliminar.IsEnabled = false;
            dgUsuario.Visibility = Visibility.Visible;
            txtListar.Visibility = Visibility.Visible;
            btnListar.Visibility = Visibility.Visible;
            pbContraseña.Visibility = Visibility.Hidden;
            pbContraseña2.Visibility = Visibility.Hidden;
            btnEjecutar.Content = "Eliminar";

            DesabilitarControles();
        }

        private void DesabilitarControles()
        {
            txtApellido.IsEnabled = false;
            txtCelular.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtListar.IsEnabled = false;
            txtNombre.IsEnabled = false;
            txtPuntos.IsEnabled = false;
            txtRut.IsEnabled = false;
            txtUsuario.IsEnabled = false;
            dpFecha.IsEnabled = false;
            cbPerfil.IsEnabled = false;
            cbSucursal.IsEnabled = false;
            chActivar.IsEnabled = false;
            rbFem.IsEnabled = false;
            rbMas.IsEnabled = false;
        }

        private void HabilitarControles()
        {
            txtApellido.IsEnabled = true;
            txtCelular.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtListar.IsEnabled = true;
            txtNombre.IsEnabled = true;
            txtPuntos.IsEnabled = true;
            txtRut.IsEnabled = true;
            txtUsuario.IsEnabled = true;
            dpFecha.IsEnabled = true;
            cbPerfil.IsEnabled = true;
            cbSucursal.IsEnabled = true;
            chActivar.IsEnabled = true;
            rbFem.IsEnabled = true;
            rbMas.IsEnabled = true;
        }

        private async void btnEjecutar_Click(object sender, RoutedEventArgs e)
        {
            lblApellido.Content = validador.validarNombre(txtApellido.Text);
            lblEmail.Content = validador.validarCorreo(txtEmail.Text);
            lblNombre.Content = validador.validarNombre(txtNombre.Text);
            lblNombreUsuario.Content = validador.validarNombreUsuario(txtUsuario.Text);
            lblRut.Content = validador.validarRut(txtRut.Text);

            Usuario user = new Usuario();
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();

            if (lblNombre.Content.Equals("OK") || lblApellido.Content.Equals("OK") || lblEmail.Content.Equals("OK") || lblNombreUsuario.Content.Equals("OK") || lblRut.Content.Equals("OK"))
            {
                string json;
                switch (btnEjecutar.Content.ToString())
                {
                    case "Agregar":

                        if (pbContraseña.Password == pbContraseña2.Password)
                        {

                            user.IdSucursal = (int)cbSucursal.SelectedValue;
                            user.IdPerfil = (int)cbPerfil.SelectedValue;
                            user.NombreUsuario = txtUsuario.Text;
                            user.Password = pbContraseña.Password;
                            user.Nombre = txtNombre.Text;
                            user.Apellido = txtApellido.Text;
                            user.Rut = txtRut.Text;
                            user.FechaNacimiento = dpFecha.SelectedDate.Value;
                            if (rbFem.IsChecked == true)
                            {
                                user.Sexo = 'F';
                            }
                            else
                            {
                                user.Sexo = 'M';
                            }
                            user.Email = txtEmail.Text;
                            user.NumeroCelular = int.Parse(txtCelular.Text);
                            if (chActivar.IsChecked == true)
                            {
                                user.Activo = '1';
                            }
                            else
                            {
                                user.Activo = '0';
                            }

                            if (user.IdPerfil != 1)
                            {
                                user.Puntos = 0;
                            }
                            else
                            {
                                user.Puntos = int.Parse(txtPuntos.Text);
                            }

                            json = user.Serializar();

                            if (proxy.CrearUsuario(json))
                            {
                                await this.ShowMessageAsync("Exito", "Usuario creado");
                                LimpiarControles();
                            }
                            else
                            {
                                await this.ShowMessageAsync("Error", "No se a creado al usuario");
                            }
                        }
                        else
                        {
                            await this.ShowMessageAsync("Error", "Las contraseñas no coinciden");
                            LimpiarControles();
                        }

                        break;

                    case "Modificar":

                        if (pbContraseña.Password == pbContraseña2.Password)
                        {


                            user.NombreUsuario = txtUsuario.Text;
                            user.Password = pbContraseña.Password;
                            user.Nombre = txtNombre.Text;
                            user.Apellido = txtApellido.Text;
                            user.Rut = txtRut.Text;
                            user.FechaNacimiento = dpFecha.SelectedDate;
                            if (rbFem.IsChecked == true)
                            {
                                user.Sexo = 'f';
                            }
                            else
                            {
                                user.Sexo = 'm';
                            }

                            user.Email = txtEmail.Text;
                            user.NumeroCelular = int.Parse(txtCelular.Text);

                            if (chActivar.IsChecked == true)
                            {
                                user.Activo = '1';
                            }
                            else
                            {
                                user.Activo = '0';
                            }
                            user.IdSucursal = (int)cbSucursal.SelectedValue;
                            user.IdPerfil = (int)cbPerfil.SelectedValue;
                            int punt;
                            int.TryParse(txtPuntos.Text, out punt);
                            user.Puntos = punt;

                            json = user.Serializar();
                            if (json != null)
                            {
                                proxy.ActualizarUsuario(json);
                                await this.ShowMessageAsync("Exito", "Usuario actualizado");
                                dgUsuario.ItemsSource = null;
                                LimpiarControles();
                            }
                            else
                            {
                                await this.ShowMessageAsync("Error", "No se pudo actualizar al usuario");
                            }
                        }
                        else
                        {
                            await this.ShowMessageAsync("Error", "Las contraseñas no coinciden");
                        }

                        break;

                    case "Eliminar":

                        user = (Usuario)dgUsuario.SelectedItem;
                        json = user.Serializar();
                        if (proxy.EliminarUsuario(json))
                        {
                            await this.ShowMessageAsync("Exito", "Usuario borrado");
                            dgUsuario.ItemsSource = null;
                            LimpiarControles();

                        }
                        else
                        {
                            await this.ShowMessageAsync("Error", "No se a podido borrar al usuario");
                            dgUsuario.ItemsSource = null;
                            LimpiarControles();
                        }

                        break;

                    default:
                        break;
                }
            } 
            else
            {
                lblNombre.Visibility = Visibility.Visible;
                lblApellido.Visibility = Visibility.Visible;
                lblEmail.Visibility = Visibility.Visible;
                lblNombreUsuario.Visibility = Visibility.Visible;
                lblRut.Visibility = Visibility.Visible;

                if (lblNombre.Content.Equals("OK"))
                {
                    lblNombre.Visibility = Visibility.Hidden;
                }
                if (lblApellido.Content.Equals("OK"))
                {
                    lblApellido.Visibility = Visibility.Hidden;
                }
                if (lblEmail.Content.Equals("OK"))
                {
                    lblEmail.Visibility = Visibility.Hidden;
                }
                if (lblNombreUsuario.Content.Equals("OK"))
                {
                    lblNombreUsuario.Visibility = Visibility.Hidden;
                }
                if (lblRut.Content.Equals("OK"))
                {
                    lblRut.Visibility = Visibility.Hidden;
                }

            }

        
    }

    private void LimpiarControles()
    {
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        txtRut.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtCelular.Text = string.Empty;
        txtPuntos.Text = string.Empty;
        txtUsuario.Text = string.Empty;
        dpFecha.SelectedDate = null;
        cbSucursal.SelectedIndex = 0;
        cbPerfil.SelectedIndex = 0;
        chActivar.IsChecked = false;
        rbFem.IsChecked = false;
        rbMas.IsChecked = false;
        pbContraseña.Password = "";
        pbContraseña2.Password = "";
    }

    private void btnListar_Click(object sender, RoutedEventArgs e)
    {
        ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
        string json = proxy.ReadAll();
        Core.Negocio.UsuarioColection collUser = new Core.Negocio.UsuarioColection(json);
        collUser.ToList();
        dgUsuario.ItemsSource = collUser;
    }

    private void dgUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (dgUsuario.SelectedItem != null)
        {

            cbPerfil.ItemsSource = null;
            cbSucursal.ItemsSource = null;
            Usuario u = (Usuario)dgUsuario.SelectedItem;
            Perfil p = new Perfil();
            txtNombre.Text = u.Nombre;
            txtApellido.Text = u.Apellido;
            txtRut.Text = u.Rut;
            txtEmail.Text = u.Email;
            txtCelular.Text = u.NumeroCelular.ToString();
            txtPuntos.Text = u.Puntos.ToString();
            txtUsuario.Text = u.NombreUsuario;
            dpFecha.SelectedDate = u.FechaNacimiento;
            pbContraseña.Password = u.Password;
            pbContraseña2.Password = u.Password;


                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
                string jsonS = proxy.ReadAllSucursal();
                SucursalCollections suCol = new SucursalCollections(jsonS);
                cbSucursal.DisplayMemberPath = "Nombre";
                cbSucursal.SelectedValuePath = "IdSucursal";
                cbSucursal.ItemsSource = suCol.ToList();

            for (int i = 0; i < cbSucursal.Items.Count; i++)
            {
                Sucursal s = (Sucursal)cbSucursal.Items[i];
                if (s.IdSucursal == u.IdSucursal)
                {
                    cbSucursal.SelectedIndex = i;
                }
            }

            string jsonP = proxy.ReadAllPerfil();
            PerfilCollections perCol = new PerfilCollections(jsonP);
            cbPerfil.DisplayMemberPath = "Tipo";
            cbPerfil.SelectedValuePath = "IdPerfil";
            cbPerfil.ItemsSource = perCol.ToList();

            for (int i = 0; i < cbPerfil.Items.Count; i++)
            {
                Perfil pe = (Perfil)cbPerfil.Items[i];

                if (pe.IdPerfil == u.IdPerfil)
                {
                    cbPerfil.SelectedIndex = i;
                }
            }



            if (u.Activo == '1')
            {
                chActivar.IsChecked = true;
            }
            else
            {
                chActivar.IsChecked = false;
            }

            if (u.Sexo == 'm' || u.Sexo == 'M')
            {
                rbMas.IsChecked = true;
            }
            else
            {
                rbFem.IsChecked = true;
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

    private void txtApellido_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

        if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
        {
            lblNombre.Visibility = Visibility.Hidden;
        }
        else
        {

            lblApellido.Content = "Apellido no puede contener numeros";
            lblApellido.Visibility = Visibility.Visible;

        }
    }

    private void txtCelular_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
}
}


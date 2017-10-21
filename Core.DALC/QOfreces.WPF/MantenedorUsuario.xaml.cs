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
    /// Lógica de interacción para MantenedorUsuario.xaml
    /// </summary>
    public partial class MantenedorUsuario : MetroWindow
    {
        public MantenedorUsuario()
        {
            InitializeComponent();
            CargarCombobox();
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            txtNombreE.Text = string.Empty;
            txtApellidoE.Text = string.Empty;
            txtRutE.Text = string.Empty;
            txtEmailE.Text = string.Empty;
            txtCelularE.Text = string.Empty;
            txtPuntosE.Text = string.Empty;
            txtUsuarioE.Text = string.Empty;
            dpFechaE.SelectedDate = null ;
            cbSucursalE.SelectedIndex = 0;
            cbPerfilE.SelectedIndex = 0;
            chActivarE.IsChecked = false;
            rbFemE.IsChecked = false;
            rbMasE.IsChecked = false;


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

            txtNombreM.Text = string.Empty;
            txtApellidoM.Text = string.Empty;
            txtRutM.Text = string.Empty;
            txtEmailM.Text = string.Empty;
            txtCelularM.Text = string.Empty;
            txtPuntosM.Text = string.Empty;
            txtUsuarioM.Text = string.Empty;
            dpFechaM.SelectedDate = null;
            cbSucursalM.SelectedIndex = 0;
            cbPerfilM.SelectedIndex = 0;
            chActivarM.IsChecked = false;
            rbFemM.IsChecked = false;
            rbMasM.IsChecked = false;
            pbContraseñaM.Password = "";
            pbContraseña2M.Password = "";


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
            string jsonS = proxy.ReadAllSucursal();
            SucursalCollections suCol = new SucursalCollections(jsonS);
            Sucursal s = new Sucursal();
            cbSucursal.DisplayMemberPath = "Nombre";
            cbSucursal.SelectedValuePath = "IdSucursal";
            cbSucursal.ItemsSource = suCol.ToList();
            cbSucursal.SelectedIndex = 0;

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

            if (pbContraseña.Password == pbContraseña2.Password)
            {
                Usuario user = new Usuario();
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


                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
                string json = user.Serializar();

                if (proxy.CrearUsuario(json))
                {
                    await this.ShowMessageAsync("Exito", "Usuario creado");
                }
                else
                {
                    await this.ShowMessageAsync("Error", "No se a creado al usuario");
                }
            }
            else
            {
                await this.ShowMessageAsync("Error", "Las contraseñas no coinciden");
            }

            
        }

        private void btnListarE_Click(object sender, RoutedEventArgs e)
        {
            
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAll();
            Core.Negocio.UsuarioColection collUser= new Core.Negocio.UsuarioColection(json);
            collUser.ToList();
            dgUsuarioE.ItemsSource = collUser;
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            
            Usuario user = (Usuario)dgUsuarioE.SelectedItem;

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = user.Serializar();
            if (proxy.EliminarUsuario(json))
            {
                await this.ShowMessageAsync("Exito", "Usuario borrado");
                dgUsuarioE.ItemsSource = null;
                LimpiarControles();
                
            }
            else
            {
                await this.ShowMessageAsync("Error", "No se a podido borrar al usuario");
                dgUsuarioE.ItemsSource = null;
                LimpiarControles();
            }
        }

        private void dgUsuarioE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dgUsuarioE.SelectedItem != null)
            {

                cbPerfilE.Items.Clear();
                cbSucursalE.Items.Clear();
                Usuario u = (Usuario)dgUsuarioE.SelectedItem;
                Perfil p = new Perfil();
                txtNombreE.Text = u.Nombre;
                txtApellidoE.Text = u.Apellido;
                txtRutE.Text = u.Rut;
                txtEmailE.Text = u.Email;
                txtCelularE.Text = u.NumeroCelular.ToString();
                txtPuntosE.Text = u.Puntos.ToString();
                txtUsuarioE.Text = u.NombreUsuario;
                dpFechaE.SelectedDate = u.FechaNacimiento;

                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
                string jsonS = proxy.ReadAllSucursal();
                SucursalCollections suCol = new SucursalCollections(jsonS);
                foreach (var item in suCol)
                {
                    if (item.IdSucursal == u.IdSucursal)
                    {
                        cbSucursalE.Items.Add(item.Nombre);
                        cbSucursalE.SelectedIndex = 0;
                    }
                }

                string jsonP = proxy.ReadAllPerfil();
                PerfilCollections perCol = new PerfilCollections(jsonP);
                foreach (var item in perCol)
                {
                    if (item.IdPerfil == u.IdPerfil)
                    {
                        cbPerfilE.Items.Add(item.Tipo);
                        cbPerfilE.SelectedIndex = 0;
                    }
                }

                if (u.Activo == '1' )
                {
                    chActivarE.IsChecked = true;
                }

                if (u.Sexo == 'm' || u.Sexo == 'M')
                {
                    rbMasE.IsChecked = true;
                }
                else
                {
                    rbFemE.IsChecked = true;
                }
            }

        }

        private void btnSalirE_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgUsuarioM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgUsuarioM.SelectedItem != null)
            {

                cbPerfilM.ItemsSource = null;
                cbSucursalM.ItemsSource = null;
                Usuario u = (Usuario)dgUsuarioM.SelectedItem;
                Perfil p = new Perfil();
                txtNombreM.Text = u.Nombre;
                txtApellidoM.Text = u.Apellido;
                txtRutM.Text = u.Rut;
                txtEmailM.Text = u.Email;
                txtCelularM.Text = u.NumeroCelular.ToString();
                txtPuntosM.Text = u.Puntos.ToString();
                txtUsuarioM.Text = u.NombreUsuario;
                dpFechaM.SelectedDate = u.FechaNacimiento;

                
                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
                string jsonS = proxy.ReadAllSucursal();
                SucursalCollections suCol = new SucursalCollections(jsonS);
                cbSucursalM.DisplayMemberPath = "Nombre";
                cbSucursalM.SelectedValuePath = "IdSucursal";
                cbSucursalM.ItemsSource = suCol.ToList();

                for (int i = 0; i < cbSucursalM.Items.Count; i++)
                {
                    Sucursal s = (Sucursal)cbSucursalM.Items[i];
                    if (s.IdSucursal == u.IdSucursal)
                    {
                        cbSucursalM.SelectedIndex = i;
                    }
                }
               
                string jsonP = proxy.ReadAllPerfil();
                PerfilCollections perCol = new PerfilCollections(jsonP);
                cbPerfilM.DisplayMemberPath = "Tipo";
                cbPerfilM.SelectedValuePath = "IdPerfil";
                cbPerfilM.ItemsSource = perCol.ToList();

                for (int i = 0; i < cbPerfilM.Items.Count; i++)
                {
                    Perfil pe = (Perfil)cbPerfilM.Items[i];

                    if (pe.IdPerfil == u.IdPerfil)
                    {
                        cbPerfilM.SelectedIndex = i;
                    }
                }



                if (u.Activo == '1')
                {
                    chActivarM.IsChecked = true;
                }
                else
                {
                    chActivarM.IsChecked = false;
                }

                if (u.Sexo == 'm' || u.Sexo == 'M')
                {
                    rbMasM.IsChecked = true;
                }
                else
                {
                    rbFemM.IsChecked = true;
                }
            }
        }

        private void btnListarM_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAll();
            Core.Negocio.UsuarioColection collUser = new Core.Negocio.UsuarioColection(json);
            collUser.ToList();
            dgUsuarioM.ItemsSource = collUser;
        }

        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (pbContraseñaM.Password == pbContraseña2M.Password)
            {
                Usuario user = new Usuario();

                user.NombreUsuario = txtUsuarioM.Text;
                user.Password = pbContraseñaM.Password;
                user.Nombre = txtNombreM.Text;
                user.Apellido = txtApellidoM.Text;
                user.Rut = txtRutM.Text;
                user.FechaNacimiento = dpFechaM.SelectedDate;
                if (rbFemM.IsChecked == true)
                {
                    user.Sexo = 'f';
                }
                else
                {
                    user.Sexo = 'm';
                }

                user.Email = txtEmailM.Text;
                user.NumeroCelular = int.Parse(txtCelularM.Text);

                if (chActivarM.IsChecked == true)
                {
                    user.Activo = '1';
                }
                else
                {
                    user.Activo = '0';
                }
                user.IdSucursal = (int)cbSucursalM.SelectedValue;
                user.IdPerfil = (int)cbPerfilM.SelectedValue;
                int punt;
                int.TryParse(txtPuntosM.Text, out punt);
                user.Puntos = punt;


                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();

                string json = user.Serializar();
                if (json != null)
                {
                    proxy.ActualizarUsuario(json);
                    await this.ShowMessageAsync("Exito", "Usuario actualizado");
                    dgUsuarioM.ItemsSource = null;
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
        }

        private void btnSalirM_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

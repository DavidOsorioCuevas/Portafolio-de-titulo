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
                user.Activo = 's';
            }else
            {
                user.Activo = 'n';
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
                
            }
            else
            {
                await this.ShowMessageAsync("Error", "No se a podido borrar al usuario");
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

                if (u.Activo == 's' )
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

                //cbPerfilM.Items.Clear();
                //cbSucursalM.Items.Clear();
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

                // oh wn no puedo lograr dejar seleccionado en el combobox el valor que tiene la clase
                //por la ptm!!!!!
                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
                string jsonS = proxy.ReadAllSucursal();
                SucursalCollections suCol = new SucursalCollections(jsonS);
                cbSucursalM.DisplayMemberPath = "Nombre";
                cbSucursalM.SelectedValuePath = "IdSucursal";
                cbSucursalM.ItemsSource = suCol.ToList();
                foreach (var item in suCol)
                {
                    if (item.IdSucursal == u.IdSucursal)
                    {
                        cbSucursalM.SelectedItem = item.Nombre;
                    }
                }
                //ese del perfil funciona perfecto pero claro con 4 perfiles cagones cualquiera lo hace
                //como hacerlo con 1 chilion de perfiles? no se wn no puedo T_T
                string jsonP = proxy.ReadAllPerfil();
                PerfilCollections perCol = new PerfilCollections(jsonP);
                cbPerfilM.DisplayMemberPath = "Tipo";
                cbPerfilM.SelectedValuePath = "IdPerfil";
                cbPerfilM.ItemsSource = perCol.ToList();

                switch (u.IdPerfil)
                {
                    case 1:
                        cbPerfilM.SelectedIndex = 0;
                        break;
                    case 2:
                        cbPerfilM.SelectedIndex = 1;
                        break;
                    case 3:
                        cbPerfilM.SelectedIndex = 2;
                        break;
                    case 4:
                        cbPerfilM.SelectedIndex = 3;
                        break;
                    default:
                        break;
                }

                

                if (u.Activo == 's')
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
    }
}

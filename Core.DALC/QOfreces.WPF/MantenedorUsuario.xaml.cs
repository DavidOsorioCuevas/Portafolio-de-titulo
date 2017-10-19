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

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = new Usuario();
            int id;
            int.TryParse(txtEliminar.Text, out id);
            user.IdUsuario = id;

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = user.Serializar();
            if (proxy.EliminarUsuario(json))
            {
                await this.ShowMessageAsync("Exito", "Usuario eliminado");
            }
            else
            {
                await this.ShowMessageAsync("Error", "No se a podido eliminar");
            }
        }
    }
}

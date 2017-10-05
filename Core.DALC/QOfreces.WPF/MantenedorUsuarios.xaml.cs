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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core.Negocio;

namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para MantenedorUsuarios.xaml
    /// </summary>
    public partial class MantenedorUsuarios : Window
    {
        public MantenedorUsuarios()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = new Usuario();

            user.IdUsuario = int.Parse(txtIdUser.Text);
            user.IdPerfil = int.Parse(txtPerfil.Text);
            user.NombreUsuario = txtNombreUsuario.Text;
            user.Password = txtPass.Text;
            user.Nombre = txtNombre.Text;
            user.Apellido = txtApellido.Text;
            user.Rut = txtRut.Text;
            user.FechaNacimiento = DateTime.Parse(txtFechaN.Text);
            user.Sexo = Char.Parse(txtSexo.Text);
            user.Email = txtEmail.Text;
            user.NumeroCelular = int.Parse(txtCelular.Text);
            user.Activo = char.Parse(txtActivo.Text);
            if (user.IdPerfil != 1)
            {
                user.Puntos = 0;
            }
            else
            {
                user.Puntos = int.Parse(txtPunt.Text);
            }
            

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = user.Serializar();

            if (proxy.CrearUsuario(json))
            {
                MessageBox.Show("USUARIO CREADO");
            }
            else
            {

            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = new Usuario();
            user.NombreUsuario = txtIdEliminar.Text;

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = user.Serializar();
            if (proxy.EliminarUsuario(json))
            {
                MessageBox.Show("USUARIO ELIMINADO");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = new Usuario();

            user.IdUsuario = int.Parse(txtIdUser.Text);
            user.IdPerfil = int.Parse(txtPerfil.Text);
            user.NombreUsuario = txtNombreUsuario.Text;
            user.Password = txtPass.Text;
            user.Nombre = txtNombre.Text;
            user.Apellido = txtApellido.Text;
            user.Rut = txtRut.Text;
            user.FechaNacimiento = DateTime.Parse(txtFechaN.Text);
            user.Sexo = Char.Parse(txtSexo.Text);
            user.Email = txtEmail.Text;
            user.NumeroCelular = int.Parse(txtCelular.Text);
            user.Activo = char.Parse(txtActivo.Text);

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();

            string json = user.Serializar();
            if (json != null)
            {
                proxy.ActualizarUsuario(json);
                MessageBox.Show("USUARIO ACTUALIZADO");
            }
            else
            {
                MessageBox.Show("ERROR AL ACTUALIZAR");
            }
            

            txtPerfil.Text = user.IdPerfil.ToString();







        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}

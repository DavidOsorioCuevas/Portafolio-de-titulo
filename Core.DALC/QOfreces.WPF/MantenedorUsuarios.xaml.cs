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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para MantenedorUsuarios.xaml
    /// </summary>
    public partial class MantenedorUsuarios : MetroWindow
    {
        public MantenedorUsuarios()
        {
            InitializeComponent();
            CargarCombobox();
        }

        private void CargarCombobox()
        {
           
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllPerfil();
            PerfilCollections perCol = new PerfilCollections(json);
            Perfil p = new Perfil();
            p.IdPerfil = 5;
            p.Tipo = "Seleccione un valor";
            perCol.Add(p);
            comboBox.DisplayMemberPath = "Tipo";
            comboBox.SelectedValuePath = "IdPerfil";
            comboBox.ItemsSource = perCol.ToList();
            comboBox.SelectedIndex = 4;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = new Usuario();

            // user.IdPerfil = int.Parse(txtPerfil.Text);
            user.IdPerfil = (int)comboBox.SelectedValue;
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
                MessageBox.Show("ERROR");
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = new Usuario();
            int id;
            int.TryParse(txtIdEliminar.Text, out id);
            user.IdUsuario = id;

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


            //user.IdPerfil = int.Parse(txtPerfil.Text);
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


            //txtPerfil.Text = user.IdPerfil.ToString();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ListarUsuarios lst = new ListarUsuarios();
            lst.Owner = this;
            lst.Show();

        }
        
    }
}

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

namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para mainwindow.xaml
    /// </summary>
    public partial class mainwindow : MetroWindow
    {
        public mainwindow()
        {
            InitializeComponent();
            txtUser.Focus();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();

            if (proxy.ValidarUsuarioWPF(txtUser.Text, pbPassword.Password.ToString()))
            {

                Core.Negocio.Usuario user = new Core.Negocio.Usuario();
                user.NombreUsuario = txtUser.Text;

                string json = user.Serializar();
                json = proxy.LeerUsuario(json);


                if (json != null)
                {
                    user = new Core.Negocio.Usuario(json);

                    if (user.IdPerfil == 1)
                    {
                        Administrador ad = new Administrador();
                        this.Close();
                        ad.Show();
                        
                    }
                    else if (user.IdPerfil == 2)
                    {

                        EncargadoTienda encar = new EncargadoTienda();
                        this.Close();
                        encar.Show();

                    }
                    else if (user.IdPerfil == 4)
                    {
                        Gerente ger = new Gerente();
                        this.Close();
                        ger.Show();
                    }
                    else if(user.IdPerfil == 3)
                    {
                        await this.ShowMessageAsync("Error", "No se aceptan consumidores en este sistema");
                        txtUser.Clear();
                        pbPassword.Clear();
                    }                  
                }
            }
            else
            {
                await this.ShowMessageAsync("Error", "Verifique sus credenciales");
                txtUser.Clear();
                pbPassword.Clear();
            }



            /* if (proxy.ValidarUsuarioWPF(txtUser.Text, txtPassword.Text))
             {
                 Consumidor con = new Consumidor();
                 con.Show();
             }
             else
             {
                 label.Content = "Error de autenticación";
             }*/
        }
    }
}

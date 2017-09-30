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


namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para mainwindow.xaml
    /// </summary>
    public partial class mainwindow : Window
    {
        public mainwindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();

            if (proxy.ValidarUsuarioWPF(txtUser.Text, txtPassword.Text))
            {

                Core.Negocio.Usuario user = new Core.Negocio.Usuario();
                user.NombreUsuario = txtUser.Text;

                string json = user.Serializar();
                json = proxy.LeerUsuario(json);


                if (json != null)
                {
                    user = new Core.Negocio.Usuario(json);

                    if (user.IdPerfil == 2)
                    {
                        Administrador ad = new Administrador();
                        ad.Show();
                    }
                    else if (user.IdPerfil == 3)
                    {

                        EncargadoTienda encar = new EncargadoTienda();
                        encar.Show();

                    }
                    else if (user.IdPerfil == 4)
                    {
                        Gerente ger = new Gerente();
                        ger.Show();
                    }
                }
            }
            else
            {
                label.Content = "Error de Autenticación";
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

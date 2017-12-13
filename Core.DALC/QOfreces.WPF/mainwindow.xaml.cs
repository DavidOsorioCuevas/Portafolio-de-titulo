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
        Validaciones validador = new Validaciones();

        public static Core.Negocio.Usuario UsuarioACtual;
        public static Core.Negocio.Retail RetailActual;
        public static Core.Negocio.Sucursal SucursalActual;

        ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
        public mainwindow()
        {
            InitializeComponent();
            txtUser.Focus();
            lblContraseña.Visibility = Visibility.Hidden;
            lblNombre.Visibility = Visibility.Hidden;          
    }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            lblNombre.Content = validador.validarNombre(txtUser.Text);
            lblContraseña.Content = validador.validarContraseña(pbPassword.Password);
                
            if (lblContraseña.Content.Equals("OK") && lblNombre.Content.Equals("OK"))
            {
                lblNombre.Visibility = Visibility.Hidden;
                lblContraseña.Visibility = Visibility.Hidden;

                if (proxy.ValidarUsuarioWPF(txtUser.Text, pbPassword.Password.ToString()))
                {

                    Core.Negocio.Usuario user = new Core.Negocio.Usuario();

                    user.NombreUsuario = txtUser.Text;

                    string json = user.Serializar();
                    json = proxy.LeerUsuario(json);



                    if (json != null)
                    {

                        user = new Core.Negocio.Usuario(json);
                        UsuarioACtual = user;

                        string jsonSuc = proxy.LeerSucursalId(UsuarioACtual.IdSucursal);
                        SucursalActual = new Core.Negocio.Sucursal(jsonSuc);

                        string jsonRet = proxy.LeerRetailId(SucursalActual.IdRetail);
                        RetailActual = new Core.Negocio.Retail(jsonRet);




                        if (user.IdPerfil == 1)
                        {
                            MenuAdministrador ad = new MenuAdministrador();
                            this.Close();
                            ad.Show();

                        }
                        else if (user.IdPerfil == 2)
                        {

                            MenuEncargado encar = new MenuEncargado();
                            this.Close();
                            encar.Show();

                        }
                        else if (user.IdPerfil == 4)
                        {
                            ReporteMovimientos ger = new ReporteMovimientos();
                            this.Close();
                            ger.Show();
                        }
                        else if (user.IdPerfil == 3)
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
            }
            else
            {
                if (lblContraseña.Content.Equals("OK"))
                {
                    lblContraseña.Visibility = Visibility.Hidden;
                }
                else
                {

                    lblContraseña.Visibility = Visibility.Visible;
                }

                if (lblNombre.Content.Equals("OK"))
                {
                    lblNombre.Visibility = Visibility.Hidden;
                }
                else
                {

                    lblNombre.Visibility = Visibility.Visible;
                }
            }

        }
    }
}

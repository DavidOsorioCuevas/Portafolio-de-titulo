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
    /// Lógica de interacción para ListarUsuarios.xaml
    /// </summary>
    public partial class ListarUsuarios : Window
    {
        public ListarUsuarios()
        {
            InitializeComponent();
        }

        
        

        private void dataGridProductos_Loaded(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAll();
            Core.Negocio.UsuarioColection collUser = new Core.Negocio.UsuarioColection(json);
            dataGridProductos.ItemsSource = collUser;
        }
    }
}

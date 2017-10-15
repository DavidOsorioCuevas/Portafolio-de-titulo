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
using Core.Negocio;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para MantenedorRubro.xaml
    /// </summary>
    public partial class MantenedorRubro : MetroWindow
    {
        public MantenedorRubro()
        {
            InitializeComponent();
        }

        private void btnAgreg_Click(object sender, RoutedEventArgs e)
        {
            Rubro ru = new Rubro();
            ru.TipoRubro = txtTRubro.Text;
            ru.Descripcion = txtTRubro.Text;
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = ru.Serializar();                      

            if (proxy.CrearRubro(json))
            {
                MessageBox.Show("RUBRO CREADO");
            }
            else
            {
                MessageBox.Show("ERROR");
            }

           
            
        }

        private void btnElim_Click(object sender, RoutedEventArgs e)
        {
            Rubro ru = new Rubro();
            ru.TipoRubro = txtElim.Text;
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = ru.Serializar();
            if (proxy.EliminarRubro(json))
            {
                MessageBox.Show("RUBRO ELIMINADO");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void btnActu_Click(object sender, RoutedEventArgs e)
        {
            Rubro ru = new Rubro();
            ru.TipoRubro = txtTRubro.Text;
            ru.Descripcion = txtDesc.Text;
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = ru.Serializar();
            if (proxy.ActualizarRubro(json))
            {
                MessageBox.Show("RUBRO ACTUALIZADO");

            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}

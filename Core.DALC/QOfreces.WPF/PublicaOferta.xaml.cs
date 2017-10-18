using Core.Negocio;
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
    /// Lógica de interacción para PublicaOferta.xaml
    /// </summary>
    public partial class PublicaOferta : Window
    {
        public PublicaOferta()
        {
            InitializeComponent();
            CargarData();
        }

        private void CargarData()
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllOfertas();
            OfertaCollections collOf = new OfertaCollections(json);
            dgOfertas.ItemsSource = collOf.ToList();
        }

        private void btnListPublicOf_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllOfertasActivo();
            OfertaCollections collOf = new OfertaCollections(json);
            dgOfertas.ItemsSource = collOf.ToList();
        }

        private void btnListNoPublic_Click(object sender, RoutedEventArgs e)
        {

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllOfertasDesactivo();
            OfertaCollections collOf = new OfertaCollections(json);
            dgOfertas.ItemsSource = collOf.ToList();
        }

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {

            var list = dgOfertas.Items.OfType<Oferta>();
            int countpu = 0;
            int contdes = 0;
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            Oferta of = new Oferta();
            foreach (var item in list)
            {
               
                of.IdOferta = item.IdOferta;
                string json = of.Serializar();
                json = proxy.LeerOfertaId(json);
                Oferta ofer = new Oferta(json);
                if (item.Selec == false && ofer.EstadoOferta == '1')
                {
                    // desactivar publicacion;
                    proxy.DesPublicarOferta(json);
                    contdes++;

                }
                else if (item.Selec == true && ofer.EstadoOferta == '0')
                {
                    //activar publicacion;
                    proxy.PublicarOferta(json);
                    countpu++;
                }            
            }
            MessageBox.Show("SE ACTIVARON " + countpu.ToString() + " PUBLICACIONES");
            MessageBox.Show("SE DESACTIVARON " + contdes.ToString() + " PUBLICACIONES");
            CargarData();
        }
    }
}

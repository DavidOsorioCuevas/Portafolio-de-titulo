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
    /// Lógica de interacción para EncargadoTienda.xaml
    /// </summary>
    public partial class EncargadoTienda : MetroWindow
    {
        public EncargadoTienda()
        {
            InitializeComponent();
                     
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            mainwindow mai = new mainwindow();
            this.Close();
            mai.Show();
        }

        private void tiConsultarOferta_Click(object sender, RoutedEventArgs e)
        {
            flyBusqueda.IsOpen = true;
            dataGridOferta.ItemsSource = null; 
        }

        private void tiGenerarOferta_Click(object sender, RoutedEventArgs e)
        {
            GenOferta genOf = new GenOferta();
            genOf.Owner = this;
            genOf.Show();
        }

        private  void tiPublicarOferta_Click(object sender, RoutedEventArgs e)
        {
            FlyPublicar.IsOpen = true;
        }

        private void tiProducto_Click(object sender, RoutedEventArgs e)
        {
            MantenedorProducto mProd = new MantenedorProducto();
            mProd.Owner = this;
            mProd.Show();
        }

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllOfertas();
            Core.Negocio.OfertaCollections collOf = new Core.Negocio.OfertaCollections(json);

            Core.Negocio.OfertaCollections collOfer = new Core.Negocio.OfertaCollections();

            if (txtBuscar.Text == "")
            {
                dataGridOferta.ItemsSource = collOf;
            }
            else
            {



                try
                {
                    foreach (var item in collOf)
                    {
                        if (txtBuscar.Text.Equals(item.Nombre))
                        {
                            collOfer.Add(item);
                        }
                    }

                    if (collOfer.Count == 0)
                    {
                        await this.ShowMessageAsync("Fallo", "No se encontro la oferta");
                    }
                    else
                    {
                        dataGridOferta.ItemsSource = collOfer;
                    }

                }
                catch (Exception)
                {

                    await this.ShowMessageAsync("Fallo", "No se encontro la oferta");
                }
            }

            
        }

        private async void btnBusqueda_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllOfertas();
            Core.Negocio.OfertaCollections collOf = new Core.Negocio.OfertaCollections(json);

            Core.Negocio.OfertaCollections collOfer = new Core.Negocio.OfertaCollections();

            try
            {
                foreach (var item in collOf)
                {
                    if (txtBusqueda.Text.Equals(item.Nombre))
                    {
                        collOfer.Add(item);
                    }
                }

                if (collOfer.Count == 0)
                {
                    await this.ShowMessageAsync("Fallo", "No se encontro la oferta");
                }
                else
                {
                    dataGridOfertas.ItemsSource = collOfer;
                }

            }
            catch (Exception)
            {

                await this.ShowMessageAsync("Fallo", "No se encontro la oferta");
            }
        }
    }
}

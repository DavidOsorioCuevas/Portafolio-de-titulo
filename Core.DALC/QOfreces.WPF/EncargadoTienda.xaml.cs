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
            dgOfertas.ItemsSource = null;
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

        private async void btnBusquedaPu_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllOfertas();
            Core.Negocio.OfertaCollections collOf = new Core.Negocio.OfertaCollections(json);

            Core.Negocio.OfertaCollections collOfer = new Core.Negocio.OfertaCollections();

            if (txtBusquedaPu.Text == "")
            {
                if (cbPublicadas.IsChecked == true)
                {
                    try
                    {
                        foreach (var item in collOf)
                        {
                            if (item.EstadoOferta == '1')
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
                            dgOfertas.ItemsSource = collOfer;
                        }

                    }
                    catch (Exception)
                    {

                        await this.ShowMessageAsync("Fallo", "No se encontro la oferta");
                    }
                }
                else
                {
                    try
                    {
                        foreach (var item in collOf)
                        {
                            if (item.EstadoOferta == '0')
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
                            dgOfertas.ItemsSource = collOfer;
                        }

                    }
                    catch (Exception)
                    {

                        await this.ShowMessageAsync("Fallo", "No se encontro la oferta");
                    }
                }
            }
            else
            {
                if (cbPublicadas.IsChecked == true)
                {
                    try
                    {
                        foreach (var item in collOf)
                        {
                            if (txtBusquedaPu.Text.Equals(item.Nombre) && item.EstadoOferta=='1')
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
                            dgOfertas.ItemsSource = collOfer;
                        }

                    }
                    catch (Exception)
                    {

                        await this.ShowMessageAsync("Fallo", "No se encontro la oferta");
                    }
                }
                else
                {
                    try
                    {
                        foreach (var item in collOf)
                        {
                            if (txtBusquedaPu.Text.Equals(item.Nombre) && item.EstadoOferta == '0')
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
                            dgOfertas.ItemsSource = collOfer;
                        }

                    }
                    catch (Exception)
                    {

                        await this.ShowMessageAsync("Fallo", "No se encontro la oferta");
                    }
                }
            }

                try
                {
                    foreach (var item in collOf)
                    {
                        if (txtBusquedaPu.Text.Equals(item.Nombre))
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
                        dgOfertas.ItemsSource = collOfer;
                    }

                }
                catch (Exception)
                {

                    await this.ShowMessageAsync("Fallo", "No se encontro la oferta");
                }
            
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
            
        }
    }
}

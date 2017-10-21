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
    /// Lógica de interacción para MantenedorRetail.xaml
    /// </summary>
    public partial class MantenedorRetail : MetroWindow
    {
        public MantenedorRetail()
        {
            InitializeComponent();
            Deshabilitar();
        }

        private void Deshabilitar()
        {
            tiAgregar.IsEnabled = false;
        }

        private void tiModificar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = true;
            tiModificar.IsEnabled = false;
            tiEliminar.IsEnabled = true;
            dgRetail.Visibility = Visibility.Visible;
            txtListar.Visibility = Visibility.Visible;
            btnListar.Visibility = Visibility.Visible;
            btnEjecutar.Content = "Modificar";
        }

        private void tiAgregar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = false;
            tiModificar.IsEnabled = true;
            tiEliminar.IsEnabled = true;
            dgRetail.Visibility = Visibility.Hidden;
            txtListar.Visibility = Visibility.Hidden;
            btnListar.Visibility = Visibility.Hidden;
            btnEjecutar.Content = "Agregar";
            
        }

        private void tiEliminar_Click(object sender, RoutedEventArgs e)
        {
            tiAgregar.IsEnabled = true;
            tiModificar.IsEnabled = true;
            tiEliminar.IsEnabled = false;
            dgRetail.Visibility = Visibility.Visible;
            txtListar.Visibility = Visibility.Visible;
            btnListar.Visibility = Visibility.Visible;
            btnEjecutar.Content = "Eliminar";
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllRetail();
            Core.Negocio.RetailCollections collRet = new Core.Negocio.RetailCollections(json);
            collRet.ToList();
            dgRetail.ItemsSource = collRet;
        }

        private void dgRetail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgRetail.SelectedItem != null)
            {

                cbComuna.ItemsSource = null;
                cbRegion.ItemsSource = null;
                Retail r = (Retail)dgRetail.SelectedItem;
                txtRut.Text = r.RutRetail;
                txtNombre.Text = r.NombreRetail;
                txtRazonSocial.Text = r.RazonSocial;
                txtTelefono.Text = r.Telefono.ToString();
                txtEmail.Text = r.Email;
                txtDireccion.Text = r.Direccion;

                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
                string jsonS = proxy.ReadAllRegiones();
                RegionCollections reCol = new RegionCollections(jsonS);
                cbRegion.DisplayMemberPath = "Nombre";
                cbRegion.SelectedValuePath = "IdRegion";
                cbRegion.ItemsSource = reCol.ToList();

                for (int i = 0; i < cbRegion.Items.Count; i++)
                {
                    Region re = (Region)cbRegion.Items[i];
                    if (re.IdRegion == r.IdRegion)
                    {
                        cbRegion.SelectedIndex = i;
                    }
                }

                
                string json = proxy.ReadAllComuna();
                ComunaCollections comCol = new ComunaCollections(json);
                cbComuna.DisplayMemberPath = "Nombre";
                cbComuna.SelectedValuePath = "IdComuna";
                cbComuna.ItemsSource = comCol.ToList();

                for (int i = 0; i < cbComuna.Items.Count; i++)
                {
                    Comuna co = (Comuna)cbComuna.Items[i];
                    if (co.IdComuna == r.IdComuna)
                    {
                        cbComuna.SelectedIndex = i;
                    }
                }


            }
        }
    }
}

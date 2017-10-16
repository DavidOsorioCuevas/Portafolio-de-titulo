﻿using System;
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
using System.Collections.ObjectModel;
using System.Collections;
using System.Data;
using System.ComponentModel;
using Microsoft.Win32;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para GenOferta.xaml
    /// </summary>
    public partial class GenOferta : MetroWindow
    {
        public GenOferta()
        {
  
            InitializeComponent();
            CargarCombobox();
        }

        private void CargarCombobox()
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllSucursal();
            SucursalCollections sucCol = new SucursalCollections(json);
            cbSucursal.DisplayMemberPath = "Nombre";
            cbSucursal.SelectedValuePath = "IdSucursal";
            cbSucursal.ItemsSource = sucCol.ToList();

        }

        private void btnGenOferta_Click(object sender, RoutedEventArgs e)
        {

            List<Producto> lstprod = new List<Producto>();
            var list = dgProd.Items.OfType<Producto>();

            foreach (var item in list)
            {
                if (item.Selec == true)
                {
                    Producto prod = new Producto();
                    prod.IdProducto = item.IdProducto;
                    prod.Sku = item.Sku;
                    prod.Nombre = item.Nombre;
                    prod.Precio = item.Precio;
                    lstprod.Add(prod);
                }
            }

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            Oferta of = new Oferta();
            of.ImagenOferta = imgFoto.Source.ToString();
            of.MinProductos = int.Parse(txtMinProd.Text);
            of.MaxProductos = int.Parse(txtMaxProd.Text);
            of.PrecioAntes = int.Parse(txtPrecioAntes.Text);
            of.PrecioOferta = int.Parse(txtPrecio.Text);
            if (chPubOf.IsChecked == true)
            {
                of.EstadoOferta = char.Parse(1.ToString());
            }
            else
            {
                of.EstadoOferta = char.Parse(0.ToString());
            }            
            of.FechaOferta = dpFecha.SelectedDate;
            of.IdSucursal = 1;
            of.CategoriaIdOferta = 1;
            of.IdRegion = 1;
            of.IdComuna = 1;
            of.Nombre = txtNombre.Text;
            of.Descripcion = txtDescOf.Text;
            of.OfertaDia = char.Parse("s");
                        
            string json = of.Serializar();
            
            if (proxy.CrearOferta(json))
            {
                MessageBox.Show("OFERTA CREADA");
            }
            else
            {
                MessageBox.Show("OUSH!");
            }







        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            string json = proxy.ReadAllProductos();
            Core.Negocio.ProductoCollections collprod = new Core.Negocio.ProductoCollections(json);
            collprod.ToList();
            dgProd.ItemsSource = collprod;
        }

        private void btnAdjuntar_Click(object sender, RoutedEventArgs e)
        {
            if (imgFoto.Source == null)
            {
                OpenFileDialog openFile = new OpenFileDialog();
                BitmapImage b = new BitmapImage();
                openFile.Title = "Seleccione la Imagen a Mostrar";
                openFile.Filter = "Todos(*.*) | *.*| Imagenes | *.jpg; *.gif; *.png; *.bmp";
                if (openFile.ShowDialog() == true)
                {
                    b.BeginInit();
                    b.UriSource = new Uri(openFile.FileName);
                    b.EndInit();
                    imgFoto.Stretch = Stretch.Fill;
                    imgFoto.Source = b;

                    btnAdjuntar.Content = "Quitar Foto";
                }
            }
            else
            {
                imgFoto.Source = null;
                btnAdjuntar.Content = "Cambiar Foto";
            }
        }
    }

}


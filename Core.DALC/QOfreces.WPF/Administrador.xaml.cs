using System.Windows;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;


namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class Administrador : MetroWindow
    {
        public Administrador()
        {
            InitializeComponent();
        }


        private void tiUsuario_Click(object sender, RoutedEventArgs e)
        {
            MantenedorUsuario mant = new MantenedorUsuario();
            mant.Owner = this;
            mant.Show();
        }

        private void tiEmpresa_Click(object sender, RoutedEventArgs e)
        {
            MantenedorRetail ret = new MantenedorRetail();
            ret.Owner = this;
            ret.Show();
        }

        private void tiRubro_Click(object sender, RoutedEventArgs e)
        {
            MantenedorRubro mant = new MantenedorRubro();
            mant.Owner = this;
            mant.Show();
        }

        private void tiProducto_Click(object sender, RoutedEventArgs e)
        {
            MantenedorProducto mProd = new MantenedorProducto();
            mProd.Owner = this;
            mProd.Show();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            mainwindow mai = new mainwindow();
            this.Close();
            mai.Show();
        }

       
    }
}

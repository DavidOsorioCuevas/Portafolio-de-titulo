using System.Windows;
using System.Windows.Navigation;


namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class Administrador : Window
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void btnMantUser_Click(object sender, RoutedEventArgs e)
        {
            MantenedorUsuarios mant = new MantenedorUsuarios();
            mant.Owner = this;
            mant.Show();          
 
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMantRub_Click(object sender, RoutedEventArgs e)
        {
            MantenedorRubro mant = new MantenedorRubro ();
            mant.Owner = this;
            mant.Show();
        }
    }
}

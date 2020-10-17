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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Registro_Pago.UI.Consulta;
using Registro_Pago.UI.Registro;
using Registro_Pago.Entidades;

namespace Registro_Pago
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rPersonasButton_Click(object sender, RoutedEventArgs e)
        {
            rPersonas rPersonas1 = new rPersonas();
            rPersonas1.Show();

        }
        private void rPrestamoButton_Click(object sender, RoutedEventArgs e)
        {
            rPrestamos rPrestamos = new rPrestamos();
            rPrestamos.Show();
        }

        private void rMorasButton_Click(object sender, RoutedEventArgs e)
        {
            rMoras rmoras = new rMoras();
            rmoras.Show();
        }

        private void cPersonasButton_Click(object sender, RoutedEventArgs e)
        {
            cPersonas cPersonas = new cPersonas();
            cPersonas.Show();
        }

        private void cPrestamoButton_Click(object sender, RoutedEventArgs e)
        {
            cPrestamo cPrestamos = new cPrestamo();
            cPrestamos.Show();
        }
    }
}

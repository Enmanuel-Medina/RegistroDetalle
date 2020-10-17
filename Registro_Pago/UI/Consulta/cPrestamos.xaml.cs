using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Registro_Pago.BLL;
using Registro_Pago.Entidades;

namespace Registro_Pago.UI.Consulta
{
    /// <summary>
    /// Interaction logic for cPrestamos.xaml
    /// </summary>
    public partial class cPrestamos : Window
    {
        private Prestamos prestamos = new Prestamos();
        private object DatosDataGrid;

        public cPrestamos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Prestamos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = PrestamosBLL.GetList(p => p.PrestamosId == Utilities.ToInt(CriterioTextBox.Text));
                        break;

                    case 1:
                        listado = PrestamosBLL.GetList(p => p.PersonaId == Utilities.ToInt(CriterioTextBox.Text));
                        break;

                    case 2:
                        bool fechaValidada = ValidarFecha(CriterioTextBox.Text);

                        if (!fechaValidada)
                        {
                            MessageBox.Show("Introduzca un fecha válida", "Datos incorrectos",
                                             MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        listado = PrestamosBLL.GetList(p => p.Fecha.Equals(DateTime.Parse(CriterioTextBox.Text)));
                        break;

                        
                }
            }
            else
            {
                listado = PrestamosBLL.GetList(c => true);
            }

            
        }

        private bool ValidarFecha(string date)
        {
            try
            {
                DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

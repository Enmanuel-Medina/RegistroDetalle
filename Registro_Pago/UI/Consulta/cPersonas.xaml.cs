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
using Registro_Pago.Entidades;
using Registro_Pago.BLL;

namespace Registro_Pago.UI.Consulta
{
    /// <summary>
    /// Interaction logic for cPersonas.xaml
    /// </summary>
    public partial class cPersonas : Window
    {
        public cPersonas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Personas>();

            string criterio = CriterioTextBox.Text.Trim();
            if (criterio.Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = PersonasBLL.GetList(p => p.PersonaId == Utilities.ToInt(CriterioTextBox.Text));
                        break;

                        // Al buscar en cualquier tabla con string, da error
                        // case 1:                       
                        //     listado = PersonaBLL.GetList(p => p.Nombres.Contains(criterio, StringComparison.OrdinalIgnoreCase));
                        //     break;
                }
            }
            else
            {
                listado = PersonasBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

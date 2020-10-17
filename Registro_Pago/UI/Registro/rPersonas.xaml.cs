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

namespace Registro_Pago.UI.Registro
{
    /// <summary>
    /// Interaction logic for rPersonas.xaml
    /// </summary>
    public partial class rPersonas : Window
    {
        Personas persona;

        public rPersonas()
        {
            InitializeComponent();
            persona = new Personas();
            this.DataContext = persona;
        }

        public void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
            var persona = PersonasBLL.Buscar(Utilities.ToInt(PersonaIDTextBox.Text));

            if (persona != null)
                this.persona = persona;
            else
            {
                this.persona = new Personas();
                MessageBox.Show("No se encontró ningún registro", "Sin coincidencias",
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.DataContext = this.persona;
        }

        private void Limpiar()
        {
            this.persona = new Personas();
            this.DataContext = this.persona;
        }

        private bool Validar()
        {

            if (NombresTextBox.Text.Length == 0)
            {
                MessageBox.Show("Introduzca un nombre válido", "Datos incorrectos",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else
                return true;
        }
        public void NuevoBoton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        public void GuardarBoton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var found = PersonasBLL.Guardar(persona);

            if (found)
            {
                MessageBox.Show("Registro guardado", "Guardado exitoso",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();

            }
            else
                MessageBox.Show("Error", "Hubo un error al guardar",
                                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void EliminarBoton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonasBLL.Eliminar(Utilities.ToInt(PersonaIDTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro borrado", "Borrado exitoso",
                                MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("Error", "Hubo un error al borrar",
                                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
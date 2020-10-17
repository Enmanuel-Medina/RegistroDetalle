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
    /// Interaction logic for rPrestamos.xaml
    /// </summary>
    public partial class rPrestamos : Window
    {
        Prestamos prestamo;

        public rPrestamos()
        {
            InitializeComponent();
            prestamo = new Prestamos();
            this.DataContext = prestamo;
        }

        public void BuscarBoton_Click(object sender, RoutedEventArgs e)
        {
            var prestamo = PrestamoBLL.Buscar(Utilities.ToInt(PrestamoIDTextBox.Text));

            if (prestamo != null)
                this.prestamo = prestamo;
            else
            {
                this.prestamo = new Prestamos();
                MessageBox.Show("No se encontró ningún registro", "Sin coincidencias",
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.DataContext = this.prestamo;
        }

        private void Limpiar()
        {
            this.prestamo = new Prestamos();
            this.DataContext = this.prestamo;
        }

        private bool Validar()
        {

            if (FechaDatePicker.Text.Length == 0)
            {
                MessageBox.Show("Introduzca una fecha válida", "Datos incorrectos",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else if (PersonaTextBox.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el ID de una persona válida", "Datos incorrectos",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else if (ConceptoTextBox.Text.Length == 0)
            {
                MessageBox.Show("Introduzca un concepto", "Datos incorrectos",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else if (MontoTextBox.Text.Length == 0)
            {
                MessageBox.Show("Introduzca un monto", "Datos incorrectos",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else if (!Persona_BLL.Existe(Utilities.ToInt(PersonaTextBox.Text)))
            {
                MessageBox.Show("El ID de la persona introducida no existe", "Datos incorrectos",
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

            var found = PrestamoBLL.Guardar(prestamo);

            if (found)
            {
                Limpiar();
                MessageBox.Show("Registro guardado", "Guardado exitoso",
                                MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("Error", "Hubo un error al guardar",
                                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void EliminarBoton_Click(object sender, RoutedEventArgs e)
        {
            if (PrestamoBLL.Eliminar(Utilities.ToInt(PrestamoIDTextBox.Text)))
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



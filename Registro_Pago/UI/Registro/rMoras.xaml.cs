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
using Registro_Pago.DAL;
using Registro_Pago.Entidades;
namespace Registro_Pago.UI.Registro
{
    /// <summary>
    /// Interaction logic for Moras.xaml
    /// </summary>
    public partial class Moras : Window
    {
        private Moras moras = new Moras();
        public Moras()
        {
            InitializeComponent();
            this.DataContext = moras;

            PrestamoIdDetalleComboBox.ItemsSource = PrestamosBLL.GetPrestamo();
            PrestamoIdDetalleComboBox.SelectedValuePath = "PrestamoId";
            PrestamoIdDetalleComboBox.DisplayMemberPath = "Concepto";
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = moras;
        }
        //=====================================================[ LIMPIAR ]=====================================================
        private void Limpiar()
        {
            this.moras = new Moras();
            this.DataContext = moras;
        }
        //=====================================================[ Validar ]=====================================================
        private bool Validar()
        {
            bool Validado = true;
            if (MoraIdTextbox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return Validado;

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
           
            Moras encontrado = Moras_BLL.Buscar(moras.MoraId);

            if (encontrado != null)
            {
                moras = encontrado;
                Cargar();
                MessageBox.Show("Articulo Encontrado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Esta Id de Articulo no fue encontrada.\n\nAsegurese que existe o cree una nueva.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
            }
        }
        
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            moras.Detalles.Add(new MorasDetalle(moras.MoraId, Convert.ToInt32(PrestamoIdDetalleTextBox.Text), FechaMoraDatePicker.DisplayDate, Convert.ToSingle(ValorTextBox.Text)));

            Cargar();

            ValorTextBox.Clear();
        }
       
        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                moras.Detalles.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }
        
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = Moras_BLL.Guardar(moras);
                if ((bool)paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
      
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (Moras_BLL.Eliminar(Utilities.ToInt(MoraIdTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
    

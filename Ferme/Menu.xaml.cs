using Ferme;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
using WpfFragmentos;

namespace Ferme
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : MetroWindow
    {
        public Menu()
        {
            InitializeComponent();
        }

      

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow miMainWindows = new MainWindow();

            miMainWindows.Show();
            this.Close();
        }

        private void TitleAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            FlyUsuarioNuevo.IsOpen = true;
            FlyProveedor.IsOpen = false;
            FlyBoletas.IsOpen = false;
        }

        private async void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("Exito", "Usuario Agregado");
            txtNuevoUsuario.Text = string.Empty;
            txtNuevaContraseña.Password = string.Empty;
            txtRepetirContraseña.Password = string.Empty;
            txtNuevoUsuario.Focus();

            
        }

        private void TileProveedor_Click(object sender, RoutedEventArgs e)
        {
            FlyProveedor.IsOpen = true;
            FlyUsuarioNuevo.IsOpen = false;
            FlyBoletas.IsOpen = false;
        }

        private void TitleRegistroFactura_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TitleRegistroBoleta_Click(object sender, RoutedEventArgs e)
        {
            FlyBoletas.IsOpen = true;
            FlyUsuarioNuevo.IsOpen = false;
            FlyProveedor.IsOpen = false;
        }

        private void TitleRegistroProducto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            Ferme.usuariosDataSet usuariosDataSet = ((Ferme.usuariosDataSet)(this.FindResource("usuariosDataSet")));
            // Cargar datos en la tabla LoginEmpleados. Puede modificar este código según sea necesario.
            Ferme.usuariosDataSetTableAdapters.LoginEmpleadosTableAdapter usuariosDataSetLoginEmpleadosTableAdapter = new Ferme.usuariosDataSetTableAdapters.LoginEmpleadosTableAdapter();
            usuariosDataSetLoginEmpleadosTableAdapter.Fill(usuariosDataSet.LoginEmpleados);
            System.Windows.Data.CollectionViewSource loginEmpleadosViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("loginEmpleadosViewSource")));
            loginEmpleadosViewSource.View.MoveCurrentToFirst();
            // Cargar datos en la tabla Boletas. Puede modificar este código según sea necesario.
            Ferme.usuariosDataSetTableAdapters.BoletasTableAdapter usuariosDataSetBoletasTableAdapter = new Ferme.usuariosDataSetTableAdapters.BoletasTableAdapter();
            usuariosDataSetBoletasTableAdapter.Fill(usuariosDataSet.Boletas);
            System.Windows.Data.CollectionViewSource boletasViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("boletasViewSource")));
            boletasViewSource.View.MoveCurrentToFirst();
            // Cargar datos en la tabla Vendedores. Puede modificar este código según sea necesario.
            Ferme.usuariosDataSetTableAdapters.VendedoresTableAdapter usuariosDataSetVendedoresTableAdapter = new Ferme.usuariosDataSetTableAdapters.VendedoresTableAdapter();
            usuariosDataSetVendedoresTableAdapter.Fill(usuariosDataSet.Vendedores);
            System.Windows.Data.CollectionViewSource vendedoresViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("vendedoresViewSource")));
            vendedoresViewSource.View.MoveCurrentToFirst();
        }


    }
}

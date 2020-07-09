using Ferme;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.ComponentModel.Design;

namespace Ferme
{
    /// <summary>
    /// Lógica de interacción para ListaProveedor.xaml
    /// </summary>
    public partial class ListaProveedor : MetroWindow
    {

        OracleConnection FR = new OracleConnection("DATA SOURCE = localhost:1521 / xe; PERSIST SECURITY INFO=True; PASSWORD = ferme;  USER ID = FERME ;");
        Entities DB;
        int selectedProveedorId = 0;
        public ListaProveedor()
        {
            InitializeComponent();
            DB = new Entities();
            BtnEliminarPro.IsEnabled = false;
            BtnModificarPro.IsEnabled = false;
        }

        private void BtnMostrarListPro_Click(object sender, RoutedEventArgs e)
        {
            FR.Open();
            string Query = "select NOMBRE,RUT,DIRECCION,EMAIL,RAZON_SOCIAL,GIRO from Proveedores";
            OracleCommand createCommand = new OracleCommand(Query,FR);
            createCommand.ExecuteNonQuery();
            OracleDataAdapter dataAdapter = new OracleDataAdapter(createCommand);
            DataTable dt = new DataTable("PROVEEDORES");
            dataAdapter.Fill(dt);
            DataGridListProve.ItemsSource = dt.DefaultView;
            dataAdapter.Update(dt);

            FR.Close();
        }

        private async void BtnEliminarPro_Click(object sender, RoutedEventArgs e)
        {
            

            PROVEEDORES deletedProveedor = DB.PROVEEDORES.Find(selectedProveedorId);


            var resultado = await this.ShowMessageAsync("AVISO", "¿Desea eliminar a este proveedor? ",
                       MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative);  

        }

        private void BtnModificarPro_Click(object sender, RoutedEventArgs e)
        {
            FlyModificarProveedor.IsOpen = true;
        }

        private void BtnInicio_Click_1(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Close();
        }

        private void DataGridListUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var row = DataGridListProve.SelectedItem as DataRowView;


            if (row == null)
            {
                BtnEliminarPro.IsEnabled = false;
                BtnModificarPro.IsEnabled = false;


            }

            else
            {
                
                BtnEliminarPro.IsEnabled = true;
                BtnModificarPro.IsEnabled = true;



                DataRowView datos = DataGridListProve.SelectedItem as DataRowView;
                if (datos != null)
                {

                    txtActualizarNomProvee.Text = datos["NOMBRE"].ToString();
                    txtActualizarDireccionProvee.Text = datos["DIRECCION"].ToString();
                    txtActualizarEmailProvee.Text = datos["EMAIL"].ToString();
                    txtActualizarRutProvee.Text = datos["RUT"].ToString();
                    txtActualizarGiroProvee.Text = datos["GIRO"].ToString();
                    txtActualizarRazonSocialProvee.Text = datos["RAZON_SOCIAL"].ToString();


                }


            }
        }



        
    }


}

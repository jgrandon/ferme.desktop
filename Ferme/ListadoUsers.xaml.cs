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
    /// Lógica de interacción para ListadoUsers.xaml
    /// </summary>
    public partial class ListadoUsers : MetroWindow
    {
        OracleConnection FR = new OracleConnection("DATA SOURCE = localhost:1521 / xe; PERSIST SECURITY INFO=True; PASSWORD = ferme;  USER ID = FERME ;");
        Entities DB;
        int selectedUserId = 0;
        public ListadoUsers()
        {

            InitializeComponent();
            DB = new Entities();
            BtnEliminar.IsEnabled = false;
            BtnModificar.IsEnabled = false;

        }


        private void BtnMostrarList_Click(object sender, RoutedEventArgs e)
        {
            FR.Open();
            OracleCommand ComandoList = new OracleCommand("Lista_Usuarios", FR);
            ComandoList.CommandType = System.Data.CommandType.StoredProcedure;
            ComandoList.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = ComandoList;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            DataGridListUser.ItemsSource = tabla.DefaultView;
            FR.Close();

        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            USERS deletedUser = DB.USERS.Find(selectedUserId);
            var nombre = deletedUser.NAME;
            
            var resultado = await this.ShowMessageAsync("Exito", "Desea eliminar a: " + nombre,
                       MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative);
            if (resultado == MessageDialogResult.Affirmative)
            {
                DB.USERS.Remove(deletedUser);
                DB.SaveChanges();
                await this.ShowMessageAsync("Resultado", "Se elimino  " + nombre + "  de la lista");

                FR.Open();
                OracleCommand ComandoList = new OracleCommand("Lista_Usuarios", FR);
                ComandoList.CommandType = System.Data.CommandType.StoredProcedure;
                ComandoList.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = ComandoList;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                DataGridListUser.ItemsSource = tabla.DefaultView;
                FR.Close();


            }
            else
            {
               await this.ShowMessageAsync("resultado", "NO eliminaste a: " + nombre);
            }


        }

       

        
        private void DataGridListUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            var row = DataGridListUser.SelectedItem as DataRowView;
            

            if (row == null)
            {
                BtnEliminar.IsEnabled = false;
                 BtnModificar.IsEnabled = false;

               
            }
            
          
            else
            { 
                selectedUserId = Int32.Parse(row.Row.ItemArray[0].ToString());
                BtnEliminar.IsEnabled = true;
                BtnModificar.IsEnabled = true;

                
                //PASAR DATOS A LOS TEXTBOX 
                DataRowView datos = DataGridListUser.SelectedItem as DataRowView;
                if (datos != null)
                {

                    txtActualizarUsuario.Text = datos["NAME"].ToString();
                    ComboBoxActuaTipo.Text = datos["TIPO_USUARIO"].ToString();
                    txtActualizarNick.Text = datos["USERNAME"].ToString();
                    
                    
                }


            }



        }


        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Close();
        }

        private  void BtnModificar_Click(object sender, RoutedEventArgs e)
        {

            FlyModificar.IsOpen = true;

        }


        private async void BtnActualizarUsuario_Click(object sender, RoutedEventArgs e)
        {


            USERS UpdateUser = DB.USERS.Find(selectedUserId);
            var nombre = UpdateUser.NAME;

            var resultado = await this.ShowMessageAsync("Exito", "Desea Actualizar a: " + nombre,
                       MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative);


            if (resultado == MessageDialogResult.Affirmative)
            {

                UpdateUser.NAME = txtActualizarUsuario.Text;
                UpdateUser.USERNAME = txtActualizarNick.Text;
                UpdateUser.TIPO_USUARIO = ComboBoxActuaTipo.Text;



                DB.SaveChanges();
                await this.ShowMessageAsync("Resultado", "Se Actualizo correctamente  " + nombre + "  de la lista");

                System.Threading.Thread.Sleep(200);
                DataGridListUser.Items.Refresh();

                FR.Open();
                OracleCommand ComandoList = new OracleCommand("Lista_Usuarios", FR);
                ComandoList.CommandType = System.Data.CommandType.StoredProcedure;
                ComandoList.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = ComandoList;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                DataGridListUser.ItemsSource = tabla.DefaultView;
                FR.Close();

                

            }


        }

      
    }
}

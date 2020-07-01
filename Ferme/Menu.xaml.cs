using Ferme;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Oracle.ManagedDataAccess.Client;
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
using System.Windows.Media.TextFormatting;
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
        OracleConnection FR = new OracleConnection("DATA SOURCE = localhost:1521 / xe; PERSIST SECURITY INFO=True; PASSWORD = ferme;  USER ID = FERME ;");
        Entities DB;


        public Menu()
        {
            InitializeComponent();
            DB = new Entities();
        }


      

        private void Btn(object sender, RoutedEventArgs e)
        {
            MainWindow miMainWindows = new MainWindow();
            miMainWindows.Show();
            this.Close();
        }

        private void TitleAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
           
        }


        private async void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            CLIENTES newUser = new CLIENTES();

            if (!IsUserValid())
            {
                await this.ShowMessageAsync("Error", "Debe llenar todos los datos del Usuario");
            }
            else if (!IsPasswordValid())
            {
                await this.ShowMessageAsync("Error", "La contraseña no coincide con su confirmacion");
            }
            else
            {
              

                var user = new USERS()
                {
                   

                ID = getNewUserId(),
                    TIPO_USUARIO = ComboBoxTipo.Text,
                    NAME = txtNombreUsuario.Text,
                    USERNAME = txtNuevoUsuario.Text,
                    PASSWORD = txtNuevaContraseña.Password
                };
                DB.USERS.Add(user);

                await this.ShowMessageAsync("Exito", "Empleado Registrado Correctamente" );

                DB.SaveChanges();

                
                ClearUserForm();
            }

        }


        

        private int getNewUserId()
        {
            var max = 0;
            foreach( USERS user in DB.USERS)
            {
                if (user.ID > max) max = Decimal.ToInt32(user.ID);
            }
            return max + 1;
        }

        private void ClearUserForm()
        {
            ComboBoxTipo.Text = string.Empty;
            txtNombreUsuario.Text = string.Empty;
            txtNuevoUsuario.Text = string.Empty;
            txtNuevaContraseña.Password = string.Empty;
            txtRepetirContraseña.Password = string.Empty;
            txtNuevoUsuario.Focus();
        }

        private Boolean IsUserValid()
        {
            return !string.IsNullOrEmpty(txtNuevoUsuario.Text)
                    && !string.IsNullOrEmpty(txtNuevaContraseña.Password)
                    && !string.IsNullOrEmpty(txtRepetirContraseña.Password);
        }

        private Boolean IsPasswordValid()
        {
            return txtNuevaContraseña.Password.Equals(txtRepetirContraseña.Password);
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            FR.Open();
            OracleCommand ComandoLista = new OracleCommand("ListPersonas", FR);
            ComandoLista.CommandType = System.Data.CommandType.StoredProcedure;
            ComandoLista.Parameters.Add("registros",OracleDbType.RefCursor).Direction=ParameterDirection.Output;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = ComandoLista;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            
            FR.Close();
        }

        private void dt_ListaP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TitleUsuarios_Click(object sender, RoutedEventArgs e)
        {
            
            
            BtnRegistrarUser.Visibility = Visibility;
            BtnListaUser.Visibility = Visibility;
            labelRegistrarEmpleados.Visibility = Visibility;
            labelListaEmpleados.Visibility = Visibility;

            BtnAgregarProveedor.Visibility = Visibility.Collapsed;
            BtnListaProveedor.Visibility = Visibility.Collapsed;
            labelListaProveedores.Visibility = Visibility.Collapsed;
            labelRegistrarProveedores.Visibility = Visibility.Collapsed;

            FlyProveedor.IsOpen = false;

        }


        private void btn_agregar_usuario(object sender, RoutedEventArgs e)
        {
            FlyEmpleadoNuevo.IsOpen = true;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow miMainWindows = new MainWindow();

            miMainWindows.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FlyEmpleadoNuevo.IsOpen = true;
        }

     

      

        private void TitleRegistrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            FlyEmpleadoNuevo.IsOpen = true;
        }

       

        private void TitleProveedor_Click(object sender, RoutedEventArgs e)
        {
            BtnAgregarProveedor.Visibility = Visibility;
            BtnListaProveedor.Visibility = Visibility;
            labelRegistrarProveedores.Visibility = Visibility;
            labelListaProveedores.Visibility = Visibility;
          
            BtnRegistrarUser.Visibility = Visibility.Collapsed;
            BtnListaUser.Visibility = Visibility.Collapsed;
            labelRegistrarEmpleados.Visibility = Visibility.Collapsed;
            labelListaEmpleados.Visibility = Visibility.Collapsed;

            FlyEmpleadoNuevo.IsOpen = false;
        }

        private void TitleListaUsuario_Click(object sender, RoutedEventArgs e)
        {
            ListadoUsers Lista = new ListadoUsers();
            this.Close();
            Lista.ShowDialog();


        }

        private void BtnRegistrarUser_Click(object sender, RoutedEventArgs e)
        {
            FlyEmpleadoNuevo.IsOpen = true;
        }

        private void BtnListaUser_Click(object sender, RoutedEventArgs e)
        {
            ListadoUsers Lista = new ListadoUsers();
            this.Close();
            Lista.ShowDialog();
        }

        private void BtnAgregarProveedor_Click(object sender, RoutedEventArgs e)
        {
            FlyProveedor.IsOpen = true;
        }

        private void BtnListaProveedor_Click(object sender, RoutedEventArgs e)
        {
            ListaProveedor List = new ListaProveedor();
            this.Close();
            List.ShowDialog();
        }
    }
}

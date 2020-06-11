using Ferme.CarpetaProducto;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using WpfFragmentos;

using Ferme.CarpetaProductos;

namespace Ferme
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : MetroWindow

        
    {
        OracleConnection FR = new OracleConnection("DATA SOURCE = localhost:1521 / xe; PERSIST SECURITY INFO=True; PASSWORD = ferme;  USER ID = FERME ;");
        FermeEntities DB;


        public Menu()
        {
            InitializeComponent();
            DB = new FermeEntities();
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
            Clientes newUser = new Clientes();

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

                await this.ShowMessageAsync("Exito", user.ID.ToString() );

                DB.SaveChanges();

                //await this.ShowMessageAsync("Exito", "Usuario A gregado");
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
            FlyDespeUsuarios.IsOpen = true;
           
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
            FlyDespeProveedor_Copy.IsOpen = true;
            FlyDespeUsuarios.IsOpen = false;

        }

        private void TitleListaUsuario_Click(object sender, RoutedEventArgs e)
        {
            ListadoUsers Lista = new ListadoUsers();
            this.Close();
            Lista.ShowDialog();


        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            var FromPro = new FormProductos();
            FromPro.Show();
        }

        private void TitleRegistrarProveedor_Click(object sender, RoutedEventArgs e)
        {
            FlyRegisProveedor.IsOpen = true;
            FR.Open();
            OracleCommand ComandoList = new OracleCommand("Lista_Proveedor", FR);
            ComandoList.CommandType = System.Data.CommandType.StoredProcedure;
            ComandoList.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = ComandoList;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            DataGridListProveedor.ItemsSource = tabla.DefaultView;
            FR.Close();
        }

        private void btnModificarPro_Click(object sender, RoutedEventArgs e)
        {
            FR.Open();
            OracleCommand comando = new OracleCommand("UPDATE PROVEEDOR SET NOMBRE ='"+txtNombreProveedor+ "' WHERE IDPROVEEDOR ='" + txtIDproveedor.Text + "'", FR);
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.UpdateCommand = comando;
            adaptador.UpdateCommand.ExecuteNonQuery();
            FR.Close();
            
            MessageBox.Show("Proveedor actualizado");
        }

        private void txtIngresarPro_Click(object sender, RoutedEventArgs e)
        {
            FR.Open();
            OracleCommand comando = new OracleCommand("INSERTARPROVEEDOR", FR);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("IDPRO", OracleDbType.Varchar2).Value =txtIDproveedor.Text ;
            comando.Parameters.Add("NOMBREPRO", OracleDbType.Varchar2).Value = txtNombreProveedor.Text;
            comando.ExecuteNonQuery();
            FR.Close();
            MessageBox.Show("Objeto agregado");
        }
    }
}

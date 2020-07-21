using Ferme;
using Ferme.CarpetaProducto;
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
    /// 
    using BCrypt = BCrypt.Net.BCrypt;

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

            //TO DO : agregar validacion de rut, al menos validar que el largo sea >= a 9 y max = 10

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
                var newId = getNewUserId();
                var rut = "11111111-1";
               // var fecha = "14/12/2020";

                var user = new USERS()
                {
                    ID = newId,
                    TIPO_USUARIO = ComboBoxTipo.Text,
                    EMAIL = txtEmailUsers.Text,
                    NAME = txtNombreUsuario.Text,
                    USERNAME = txtNuevoUsuario.Text,
                    PASSWORD = BCrypt.HashPassword(txtNuevaContraseña.Password)
                };
                DB.USERS.Add(user);

                var worker = new TRABAJADORES()
                {
                    //FECHA_CONTRATACION = 1523656326,
                    ID = getNewSupplierId(),
                    ID_USUARIO = newId,
                    RUT = rut
                };
                DB.TRABAJADORES.Add(worker);




                await this.ShowMessageAsync("Exito", "Empleado Registrado Correctamente"  );

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

        private int getNewSupplierId()
        {
            var max = 0;
            foreach (PROVEEDORES supplier in DB.PROVEEDORES)
            {
                if (supplier.ID > max) max = Decimal.ToInt32(supplier.ID);
            }
            return max + 1;
        }

        private int getNewWorkerId()
        {
            var max = 0;
            foreach (TRABAJADORES worker in DB.TRABAJADORES)
            {
                if (worker.ID > max) max = Decimal.ToInt32(worker.ID);
            }
            return max + 1;
        }



        private void ClearUserForm()
        {
            ComboBoxTipo.Text = string.Empty;
            txtEmailUsers.Text = string.Empty;
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

        //Boton Lista de proveedores
        private void BtnListaProveedor_Click(object sender, RoutedEventArgs e)
        {
            ListaProveedor List = new ListaProveedor();
            this.Close();
            List.ShowDialog();
        }

        private async void BtnRegistrarProveedor_Click(object sender, RoutedEventArgs e)
        {
            PROVEEDORES newPro = new PROVEEDORES();

            if (!IsUserValid())
                if (string.IsNullOrEmpty(txtNombreProveedor.Text) || String.IsNullOrEmpty(txtDireccionProvee.Text) 
                    || string.IsNullOrEmpty(txtEmailProveedor.Text) || string.IsNullOrEmpty(txtRutProvee.Text) 
                    || string.IsNullOrEmpty(txtRazonSocial.Text) || string.IsNullOrEmpty(ComboBoxGiro.Text))
                {


                    var resultado = await this.ShowMessageAsync("AVISO", "Debe llenar los campos ");
                      

                    return;

                }
                else 
               {

                    var user = new USERS()
                    {
                        ID = getNewUserId(),
                        TIPO_USUARIO = "Proveedor",
                        EMAIL = txtEmailProveedor.Text,
                        NAME = txtNombreProveedor.Text,
                        USERNAME = txtNombreProveedor.Text,
                        PASSWORD = BCrypt.HashPassword(txtNuevaContraseña.Password)
                    };
                    DB.USERS.Add(user);
                    await this.ShowMessageAsync("Exito", "Empleado Registrado Correctamente " );
                    var proveedores = new PROVEEDORES()
                {
                        ID = getNewSupplierId(),
                        ID_USUARIO = user.ID,
                        NOMBRE = txtNombreProveedor.Text, 
                        RUT = txtRutProvee.Text,
                        DIRECCION = txtDireccionProvee.Text,
                        EMAIL = txtEmailProveedor.Text,
                        RAZON_SOCIAL = txtRazonSocial.Text,
                        GIRO = ComboBoxGiro.Text
                };
                 DB.PROVEEDORES.Add(proveedores);

                 DB.SaveChanges();

                    await this.ShowMessageAsync("Exito", "Empleado Registrado Correctamente");

                 ClearUserForm();
                }
        }

        //Title Productos
        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            Producto Producto = new Producto();
            this.Close();
            Producto.ShowDialog();
            //FormProductos frm = new FormProductos();
            ///frm.Show();
             

        }

        //Title Boletas
        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            Boletas Boleta = new Boletas();
            this.Close();
            Boleta.ShowDialog();
        }
    }
}

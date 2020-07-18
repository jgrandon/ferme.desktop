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
using System.Windows.Shapes;


namespace Ferme.CarpetaProducto
{
    /// <summary>
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class Producto : MetroWindow
    {

        OracleConnection FR = new OracleConnection("DATA SOURCE = localhost:1521 / xe; PERSIST SECURITY INFO=True; PASSWORD = ferme;  USER ID = FERME ;");
        Entities DB;
        int selectedUserId = 0;
        public Producto()
        {
            InitializeComponent();
            DB = new Entities();
            
        }

        private void DataGridProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //PASAR DATOS A LOS TEXTBOX 
            DataRowView datos = DataGridProducto.SelectedItem as DataRowView;
            if (datos != null)
            {
                txtIDpro.Text = datos["ID"].ToString();
                txtActualizarNomProdu.Text = datos["NOMBRE"].ToString();
                txtActualizarDescripcion.Text = datos["DESCRIPCION"].ToString();
                txtActualizarPrecio.Text = datos["PRECIO"].ToString();
                ComboBoxFamiliaPro.Text = datos["FAMILIA PRODUCTO"].ToString();
                txtActualizarTipoProduc.Text = datos["TIPO PRODUCTO"].ToString();
                txtActualizarProveedor.Text = datos["Provedoor"].ToString();
                DateActualizarFechaVen.Text = datos["Fecha vencimiento"].ToString();
            }

            DataGridProducto.Items.Refresh();
        }

        private void BtnMostrarListProducto_Click(object sender, RoutedEventArgs e)
        {
            FlyModificarProducto.IsOpen = true;
        }

        private async void BtnModificarProducto_Click(object sender, RoutedEventArgs e)
        {
            PRODUCTOS UpdateUser = DB.PRODUCTOS.Find(selectedUserId);

            var resultado = await this.ShowMessageAsync("Exito", "Desea Actualizar a: ",
                       MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative);

            if (resultado == MessageDialogResult.Affirmative)
            {

                //UpdateUser.NOMBRE = txtActualizarNomProdu.Text;
                //UpdateUser.DESCRIPCION = txtActualizarDescripcion.Text;
                //UpdateUser.PRECIO = Int32.Parse(txtActualizarPrecio.Text);
                //UpdateUser.ID_FAMILIAPRODUCTO = Int32.Parse(ComboBoxFamiliaPro.Text);
                //UpdateUser.ID_TIPOPRODUCTO = Int32.Parse(txtActualizarTipoProduc.Text);
                //UpdateUser.ID_PROVEEDOR = Int32.Parse(txtActualizarProveedor.Text);
                //DB.SaveChanges();
                await this.ShowMessageAsync("Resultado", "Se Actualizo correctamente  ");
                System.Threading.Thread.Sleep(200);
                DataGridProducto.Items.Refresh();
            }
        }

        private void BtnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            {
                OracleCommand ComandoList = new OracleCommand("ELIMINARPRO", FR);
                ComandoList.CommandType = System.Data.CommandType.StoredProcedure;
                ComandoList.Parameters.Add("id_p", OracleDbType.NVarchar2).Value = txtIDpro.Text;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = ComandoList;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                DataGridProducto.ItemsSource = tabla.DefaultView;


                MessageBox.Show("Producto Eliminado");
            }

        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Close();
        }

        private void BtnMostrarListaPrtoduc_Click(object sender, RoutedEventArgs e)
        {
            
            OracleCommand ComandoList = new OracleCommand("LISTPRODUCTOS", FR);
            ComandoList.CommandType = System.Data.CommandType.StoredProcedure;
            ComandoList.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = ComandoList;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            DataGridProducto.ItemsSource = tabla.DefaultView;
            
        }

        private async void BtnGuardarProducto_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateObject = DateTime.Parse(DateActualizarFechaVen.Text); //esta funcion transforma una fecha en formato string a objeto DateTime

            // Intenta usar estos mensajes para ver el valor que esta tomando una variable determinada
            // await this.ShowMessageAsync("Exito", "Este es el proveedor: " + ComboBoxFamiliaPro.SelectedValue.ToString());

            int defaultNumber = 1; //para probar insercion

            /*
                * Se deben obtener los id de proveedor, familia_producto y tipo_producto a partir 
                * de la informacion entregada en los formularios, ya sea estableciendo esos campos 
                * como comboboxes y obteniendo sus id o recibiendolo como string y haciendo las 
                * consultas necesarias para verificar que existen y obtener sus ids.
            */

            FR.Open();
            OracleCommand cmd = new OracleCommand("INSERTARPRO", FR);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            /* 
             * No es necesario agregar el codigo como parametro ya que el procedure no lo recibe
             * como parametro y es el procedure el que se encarga de calcular el codigo
            */
            //cmd.Parameters.Add("P_CODIGO", OracleDbType.Varchar2).Value = txtActualizarNomProdu.Text.Trim();
            cmd.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = txtActualizarNomProdu.Text.Trim();
            cmd.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = txtActualizarDescripcion.Text.Trim();
            cmd.Parameters.Add("p_precio", OracleDbType.Int32).Value = 1;              // int.TryParse(txtActualizarPrecio.Text.Trim(), out defaultNumber);
            cmd.Parameters.Add("p_id_tipoproducto", OracleDbType.Int32).Value = 1;     // int.TryParse(txtActualizarTipoProduc.Text, out defaultNumber);
            cmd.Parameters.Add("p_id_familiaproducto", OracleDbType.Int32).Value = 1;  // int.TryParse(ComboBoxFamiliaPro.SelectedValue.ToString(), out defaultNumber);
            cmd.Parameters.Add("p_id_proveedor", OracleDbType.Int32).Value = 1;        // int.TryParse(txtActualizarProveedor.Text.Trim(), out defaultNumber);
            cmd.Parameters.Add("P_FECHAVENCIMIENTO", OracleDbType.Date).Value = dateObject;
            cmd.ExecuteNonQuery();
         
            FR.Close();
            await this.ShowMessageAsync("Exito", "Empleado Registrado Correctamente");
            
            
        }
    }
}

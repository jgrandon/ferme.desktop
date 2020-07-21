using Ferme.CarpetaProductos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Oracle.DataAccess;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ferme.CarpetaProducto
{
    public partial class FormProductos : Form
    {
        ClsProductos objProd = new ClsProductos();
        OracleConnection FR = new OracleConnection("DATA SOURCE = localhost:1521 / xe; PERSIST SECURITY INFO=True; PASSWORD = ferme;  USER ID = FERME ;");
        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            ListarProveedores();
            ListarTipo_Producto();
            ListarFamilia();
            ListarProductos();
        }

        private void bntAgregarP_Click(object sender, EventArgs e)
        {

            DateTime dateObject = DateTime.Parse(dateFechaVencimiento.Text);

            //MessageBox.Show("Esto hay en campo de fecha" + dateFechaVencimiento.Text);
            FR.Open();
            OracleCommand comando = new OracleCommand("INSERTARPRO", FR);
            comando.Parameters.Add("p_stock", OracleDbType.Int32).Value = txtStockPro.Text;
            comando.Parameters.Add("p_nombre", OracleDbType.Varchar2).Value = txtNombreP.Text.Trim();
            comando.Parameters.Add("p_descripcion", OracleDbType.Varchar2).Value = txtDescripcionP.Text.Trim();
            comando.Parameters.Add("p_precio", OracleDbType.Int32).Value = txtPrecio.Text;
            comando.Parameters.Add("p_id_tipoproducto", OracleDbType.Int32).Value = cmbTiposProducto.SelectedValue;
            comando.Parameters.Add("p_id_familiaproducto", OracleDbType.Int32).Value = cmbFamiliaProducto.SelectedValue;
            comando.Parameters.Add("p_id_proveedor", OracleDbType.Int32).Value = cmbProveedor.SelectedValue; 
            comando.Parameters.Add("P_FECHAVENCIMIENTO", OracleDbType.Date).Value = dateObject;
             comando.ExecuteNonQuery();
            FR.Close();
            MessageBox.Show("Producto agregado");
            ListarProductos();
        }
        //comando.CommandType = System.Data.CommandType.StoredProcedure;
        //comando.Parameters.Add("NOMBRE_PRO", OracleDbType.Varchar2).Value = txtNombreP.Text;
        //comando.Parameters.Add("DESCRIPCION_PRO", OracleDbType.Varchar2).Value = txtDescripcionP.Text;
        //comando.Parameters.Add("PRECIO_PRO", OracleDbType.Int32).Value = txtPrecio.Text;
        //comando.Parameters.Add("IDTIPOS_PRODUCTO", OracleDbType.Int32).Value = cmbFamiliaProducto.SelectedValue;
        //comando.Parameters.Add("IDFAMILIAS_PRODUCTO", OracleDbType.Int32).Value = cmbTiposProducto.SelectedValue;
        // comando.Parameters.Add("ID_IMAGEN_PRODUCTO", OracleDbType.Varchar2).Value = cmbTiposP.SelectedValue;
        // comando.Parameters.Add("IDPROVEDORE", OracleDbType.Int32).Value = cmbProveedor.SelectedValue;
        //comando.Parameters.Add("FECHA_VENCIMIENTOPRO", OracleDbType.Date).Value = dateFechaVencimiento.Text;
        //comando.Parameters.Add("STOCK_PRO", OracleDbType.Int32).Value = txtStockPro.Text;
        private void txtEliminarP_Click(object sender, EventArgs e)
        {
            FR.Open();
            OracleCommand comando = new OracleCommand("ELIMINARPRO", FR);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("id_p", OracleDbType.Varchar2).Value = txtIDproducto.Text;
            comando.ExecuteNonQuery();
            FR.Close();
            ListarProductos();

            MessageBox.Show("Objeto Eliminado");
        }

        private void btnActualizarP_Click(object sender, EventArgs e)
        {
            FR.Open();
            OracleCommand comando = new OracleCommand("UPDATE PRODUCTO SET NOMBRE = '" + txtNombreP.Text + "',DESCRIPCION ='" + txtDescripcionP.Text + "',PRECIO ='" + txtPrecio.Text + "',IDTIPO_PRODUCTO ='" + cmbTiposProducto.SelectedValue + "',IDFAMILIA_PRODUCTO ='" + cmbFamiliaProducto.SelectedValue + "',IDPROVEEDOR ='" + cmbProveedor.SelectedValue + "',ID_IMAGEN ='" + cmbFamiliaProducto.SelectedValue + "' WHERE ID ='" + cmbProveedor.Text + "'", FR);
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.UpdateCommand = comando;
            adaptador.UpdateCommand.ExecuteNonQuery();
            FR.Close();
            ListarProductos();
            MessageBox.Show("Producto actualizado");
        }
        private void ListarTipo_Producto()
        {
            {
                ClsProductos objProd = new ClsProductos();
                cmbTiposProducto.DataSource = objProd.ListarTipo_Producto();
                cmbTiposProducto.DisplayMember = "NOMBRE";
                cmbTiposProducto.ValueMember = "ID";

            }


        }
        private void ListarFamilia()
        {
            {
                ClsProductos objProd = new ClsProductos();
                cmbFamiliaProducto.DataSource = objProd.ListarFamilia();
                cmbFamiliaProducto.DisplayMember = "NOMBRE";
                cmbFamiliaProducto.ValueMember = "ID";

            }
        }
        private void ListarProveedores()
        {
            {
                ClsProductos objProd = new ClsProductos();
                cmbProveedor.DataSource = objProd.ListarProveedor();
                cmbProveedor.DisplayMember = "NOMBRE";
                cmbProveedor.ValueMember = "ID";

            }
        }
        private void Listar_Imagen()
        {
            {
                ClsProductos objProd = new ClsProductos();
                cmbProveedor.DataSource = objProd.Listar_Imagen();
                cmbProveedor.DisplayMember = "IMAGEN";
                cmbProveedor.ValueMember = "IDIMAGEN";

            }

        }
        private void ListarProductos()
        {
            FR.Open();
            OracleCommand ComandoListP = new OracleCommand("LISTPRODUCTOS", FR);
            ComandoListP.CommandType = System.Data.CommandType.StoredProcedure;
            ComandoListP.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = ComandoListP;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla.DefaultView;
            FR.Close();




        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtStockPro_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

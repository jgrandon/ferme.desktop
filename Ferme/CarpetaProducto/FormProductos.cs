using Ferme.CarpetaProductos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
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
            ListarProveedor();
            ListarTipo_Producto();
            ListarFamilia();
            ListarProductos();
        }

        private void bntAgregarP_Click(object sender, EventArgs e)
        {
            FR.Open();
            OracleCommand comando = new OracleCommand("INSERTARPRO", FR);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("ID_PRO", OracleType.VarChar).Value = cmbProveedor.SelectedValue.ToString() + cmbTiposP.SelectedValue.ToString() + cmbTipoProducto.SelectedValue.ToString();
            comando.Parameters.Add("NOMBRE_PRO", OracleType.VarChar).Value = txtNombreP.Text;
            comando.Parameters.Add("DESCRIPCION_PRO", OracleType.VarChar).Value = txtDescripcionP.Text;
            comando.Parameters.Add("PRECIO_PRO", OracleType.Int32).Value = txtPrecio.Text;
            comando.Parameters.Add("IDTIPOS_PRODUCTO", OracleType.VarChar).Value = cmbTipoProducto.SelectedValue;
            comando.Parameters.Add("IDFAMILIAS_PRODUCTO", OracleType.VarChar).Value = cmbTiposP.SelectedValue;
            comando.Parameters.Add("ID_IMAGEN_PRODUCTO", OracleType.VarChar).Value = cmbTiposP.SelectedValue;
            comando.Parameters.Add("IDPROVEDORE", OracleType.VarChar).Value = cmbProveedor.SelectedValue;


            comando.ExecuteNonQuery();
            FR.Close();
            MessageBox.Show("Objeto agregado");
            ListarProductos();
        }

        private void txtEliminarP_Click(object sender, EventArgs e)
        {
            FR.Open();
            OracleCommand comando = new OracleCommand("eliminarPRO", FR);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("idp", OracleType.VarChar).Value = txtID.Text;
            comando.ExecuteNonQuery();
            FR.Close();
            ListarProductos();
            MessageBox.Show("Objeto Eliminado");
        }

        private void btnActualizarP_Click(object sender, EventArgs e)
        {
            FR.Open();
            OracleCommand comando = new OracleCommand("UPDATE PRODUCTO SET NOMBRE = '" + txtNombreP.Text + "',DESCRIPCION ='" + txtDescripcionP.Text + "',PRECIO ='" + txtPrecio.Text + "',IDTIPO_PRODUCTO ='" + cmbTiposP.SelectedValue + "',IDFAMILIA_PRODUCTO ='" + cmbTipoProducto.SelectedValue + "',IDPROVEEDOR ='" + cmbProveedor.SelectedValue + "',ID_IMAGEN ='" + cmbTipoProducto.SelectedValue + "' WHERE ID ='" + txtID.Text + "'", FR);
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
                cmbTiposP.DataSource = objProd.ListarTipo_Producto();
                cmbTiposP.DisplayMember = "NOMBRE";
                cmbTiposP.ValueMember = "IDTIPO_PRODUCTO";

            }


        }
        private void ListarFamilia()
        {
            {
                ClsProductos objProd = new ClsProductos();
                cmbTipoProducto.DataSource = objProd.ListarFamilia();
                cmbTipoProducto.DisplayMember = "NOMBRE";
                cmbTipoProducto.ValueMember = "IDFAMILIA_PRODUCTO";

            }
        }
        private void ListarProveedor()
        {
            {
                ClsProductos objProd = new ClsProductos();
                cmbProveedor.DataSource = objProd.ListarProveedor();
                cmbProveedor.DisplayMember = "NOMBRE";
                cmbProveedor.ValueMember = "IDPROVEEDOR";

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
            OracleCommand ComandoListP = new OracleCommand("ListProductos", FR);
            ComandoListP.CommandType = System.Data.CommandType.StoredProcedure;
            ComandoListP.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = ComandoListP;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla.DefaultView;
            FR.Close();




        }


    }
}

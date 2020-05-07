using System;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Ferme.CapaDatos
{
    class ClsProductos
    {
        private ConexionBD conexion = new ConexionBD();
        private OracleCommand comando = new OracleCommand();
        private OracleDataReader LeerFilas;
        public DataTable ListarFamilia()
        {

            DataTable Tabla = new DataTable();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM FAMILIA_PRODUCTO";
            LeerFilas = comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.CerrarConexion();
            return Tabla;


        }

        public DataTable ListarProveedor()
        {
            DataTable Tabla = new DataTable();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM PROVEEDOR";
            LeerFilas = comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.CerrarConexion();
            return Tabla;

        }
        public DataTable ListarTipo_Producto()
        {
            DataTable Tabla = new DataTable();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * FROM TIPO_PRODUCTO";
            LeerFilas = comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.CerrarConexion();
            return Tabla;

        }
       
    }
}
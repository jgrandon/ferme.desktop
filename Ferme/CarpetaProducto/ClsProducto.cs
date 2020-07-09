using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Ferme.ConexionFerme;
using Oracle.ManagedDataAccess.Client;

namespace Ferme.CarpetaProductos
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
            comando.CommandText = "SELECT * FROM FAMILIAS_PRODUCTO";
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
            comando.CommandText = "SELECT * FROM PROVEEDORES";
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
            comando.CommandText = "SELECT * FROM TIPOS_PRODUCTO";
            LeerFilas = comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.CerrarConexion();
            return Tabla;

        }
       
        public DataTable Listar_Imagen()
        {
            DataTable Tabla = new DataTable();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT * PRODUCTOS_IMAGENES";
            LeerFilas = comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.CerrarConexion();
            return Tabla;

        }
        

    }
}


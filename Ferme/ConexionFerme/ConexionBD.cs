using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferme.ConexionFerme
{
    class ConexionBD
    {
        static private string CadenaConexion = "DATA SOURCE = localhost:1521 / xe; PERSIST SECURITY INFO=True; PASSWORD = ferme;  USER ID = FERME ;";
        private OracleConnection Conexion = new OracleConnection(CadenaConexion);


        public OracleConnection AbrirConexion()
        {


            if (Conexion.State == ConnectionState.Closed)

                Conexion.Open();
            return Conexion;
        }


        public OracleConnection CerrarConexion()
        {


            if (Conexion.State == ConnectionState.Closed)

                Conexion.Open();
            return Conexion;
        }
    }
}


using MahApps.Metro.Controls;
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

namespace Ferme
{
    /// <summary>
    /// Lógica de interacción para Boletas.xaml
    /// </summary>
    public partial class Boletas : MetroWindow
    {
        //Conexion Base de datos Oracle
        OracleConnection FR = new OracleConnection("DATA SOURCE = localhost:1521 / xe; PERSIST SECURITY INFO=True; PASSWORD = ferme;  USER ID = FERME ;");
        
     


        public Boletas()
        {
            InitializeComponent();
        }

       


        //Boton Mostrar Lista de boletas
        private void BtnMostrarBoletas_Click(object sender, RoutedEventArgs e)
        {
            {
                FR.Open();
                string Query = "SELECT c.nombre || c.apellido as NOMBRE_CLIENTE, c.rut, c.email, b.fecha_creacion, b.fecha_entrega, b.iva, b.total, b.id_vendedor FROM BOLETAS B JOIN CLIENTES C ON B.ID_CLIENTE = C.ID";
                OracleCommand createCommand = new OracleCommand(Query, FR);
                createCommand.ExecuteNonQuery();
                OracleDataAdapter dataAdapter = new OracleDataAdapter(createCommand);
                DataTable dt = new DataTable("BOLETAS");
                dataAdapter.Fill(dt);
                DataGridBoletas.ItemsSource = dt.DefaultView;
                dataAdapter.Update(dt);

                FR.Close();
            }
        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Close();
        }

        private void BtnBuscarBoletas_Click(object sender, RoutedEventArgs e)
        {
       
        }
    }
}

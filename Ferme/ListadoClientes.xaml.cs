using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para ListadoClientes.xaml
    /// </summary>
    public partial class ListadoClientes : Window
    {
        public ListadoClientes()
        {
            InitializeComponent();
        }
        List<CLIENTES> misClientes = new List<CLIENTES>();

        private void MostrarClientes()
        {
            dgListadoClientes.ItemsSource = misClientes;
            dgListadoClientes.Items.Refresh();
        }

    }
}

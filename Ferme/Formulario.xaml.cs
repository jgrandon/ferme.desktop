using Ferme;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
//using MahApps.Metro.Behaviours;
using WpfFragmentos;

namespace Ferme
{
    /// <summary>
    /// Lógica de interacción para Formulario.xaml
    /// </summary>
    public partial class Formulario : MetroWindow
    {
        public Formulario()
        {
            InitializeComponent();
        }

        public List<CLIENTES> misClientes;

        public void SetClientes(List<CLIENTES> clientes)
        {
            misClientes = clientes;
        }

       
        private async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            CLIENTES clientito = new CLIENTES();

            clientito.RUT = txtRut.Text;
            clientito.APELLIDO = txtApellidos.Text;
            clientito.NOMBRE = txtNombre.Text;
            clientito.EMAIL = txtEmail.Text;
            clientito.DIRECCION = txtDireccion.Text;
            clientito.TELEFONO = txtTelefono.Text;
     



            if (string.IsNullOrEmpty(txtNombre.Text))
                await this.ShowMessageAsync("Falta Campo", " NOMBRE ");
            else if (string.IsNullOrEmpty(txtRut.Text))
                await this.ShowMessageAsync("Falta Campo", " RUT");
            else if (string.IsNullOrEmpty(txtTelefono.Text))
                await this.ShowMessageAsync("Falta Campo", " TELEFONO");
            else if (string.IsNullOrEmpty(txtEmail.Text))
                await this.ShowMessageAsync("Falta Campo", " EMAIL");
            else if (string.IsNullOrEmpty(txtApellidos.Text))
                await this.ShowMessageAsync("Falta Campo", " APELLIDOS");
            else if (string.IsNullOrEmpty(txtDireccion.Text))
                await this.ShowMessageAsync("Falta Campo", " DIRECCION");
          


            else
            {
                await this.ShowMessageAsync("Aviso", string.Format("Cliente Agregado Con Exito"));
                misClientes.Add(clientito);

                foreach (CLIENTES c in misClientes)
                {
                    await this.ShowMessageAsync("Aviso", string.Format(c.NOMBRE));
                }
                //Console.Write(misClientes.ToString());
               
            }



        }


        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow miMainWindows = new MainWindow();

            miMainWindows.Show();
            this.Close();
            

        }
    }
}

using Ferme;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
using WpfFragmentos;


namespace Ferme
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : MetroWindow
    {
        FermeEntities DB;


        public Menu()
        {
            InitializeComponent();
            DB = new FermeEntities();
        }


        private void Tile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow miMainWindows = new MainWindow();
            miMainWindows.Show();
            this.Close();
        }

        private void TitleAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            FlyUsuarioNuevo.IsOpen = true;
            FlyRegisProducto.IsOpen = false;
        }


        private async void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            Clientes newUser = new Clientes();

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

                var user = new users()
                {
                    id = getNewUserId(),
                    name = txtNombreUsuario.Text,
                    username = txtNuevoUsuario.Text,
                    password = txtNuevaContraseña.Password
                };
                DB.users.Add(user);

                await this.ShowMessageAsync("Exito", user.id.ToString() );

                DB.SaveChanges();

                //await this.ShowMessageAsync("Exito", "Usuario A gregado");
                ClearUserForm();
            }

        }

        private int getNewUserId()
        {
            var max = 0;
            foreach( users user in DB.users)
            {
                if (user.id > max) max = user.id;
            }
            return max + 1;
        }

        private void ClearUserForm()
        {
            txtNombreUsuario.Text = string.Empty;
            txtNuevoUsuario.Text = string.Empty;
            txtNuevaContraseña.Password = string.Empty;
            txtRepetirContraseña.Password = string.Empty;
            txtNuevoUsuario.Focus();
        }

        private Boolean IsUserValid()
        {
            return !string.IsNullOrEmpty(txtNuevoUsuario.Text)
                     && !string.IsNullOrEmpty(txtNombreUsuario.Text)
                    && !string.IsNullOrEmpty(txtNuevaContraseña.Password)
                    && !string.IsNullOrEmpty(txtRepetirContraseña.Password);
        }

        private Boolean IsPasswordValid()
        {
            return txtNuevaContraseña.Password.Equals(txtRepetirContraseña.Password);
        }

        private void txtRegisProducto_Click(object sender, RoutedEventArgs e)
        {
            FlyUsuarioNuevo.IsOpen = false;
            FlyRegisProducto.IsOpen = true;
        }

       

      
    }
}

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
using Menu = Ferme.Menu;

namespace WpfFragmentos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            misCli = new List<Clientes>();
            Clientes defaultUser = new Clientes();
            defaultUser.Usuario = "admin";
            defaultUser.Contraseña = "1234";
            misCli.Add(defaultUser);
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Formulario miformulario = new Formulario();
            miformulario.SetClientes(misCli);
            miformulario.Show();
            this.Close();                
        }

        public void setUsers(List<Clientes> users)
        {
            misCli = users;
        }

        List<Clientes> misCli;

        private async void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {


            Clientes cli = new Clientes();

            if( !isCredentialsValid() )
            {
                await this.ShowMessageAsync("Alerta", "Debe ingresar Usuario y Contraseña");
            }
            else
            {
                Clientes client = GetUserByCredentials();
                if (client!= null)
                {
                    await this.ShowMessageAsync("Hola", string.Format("BIENVENIDO"));
                    Menu menu = new Menu();
                    menu.setUsers(misCli);
                    this.Close();
                    menu.ShowDialog();

                }
                else
                {
                    await this.ShowMessageAsync("Aviso", string.Format("Tus Datos son incorrectos"));
                }

/* DEBUGG
                foreach(Clientes cc in misCli)
                {
                    await this.ShowMessageAsync("DEBUG", string.Format("Usuario " + cc.Usuario ));
                }
*/
            }
                //misCli.Add(cli);


        }

        private Clientes GetUserByCredentials()
        {
            Clientes user = null;
            foreach(Clientes u in misCli)
            {
                if( u.Usuario.Equals(txtUsuario.Text) && u.Contraseña.Equals(txtContraseña.Password) )
                {
                    user = u;
                }
            }
            return user;
        }

        private Boolean isCredentialsValid()
        {
            return !string.IsNullOrEmpty(txtContraseña.Password) && !string.IsNullOrEmpty(txtUsuario.Text);
        }
    }
}
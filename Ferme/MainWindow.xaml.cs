﻿using Ferme;
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
        FermeEntities DB;
        public MainWindow()
        {
            InitializeComponent();
            DB = new FermeEntities();
        }
        private async void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {

            users user = new users();
            if (!isCredentialsValid())
            {
                await this.ShowMessageAsync("Alerta", "Debe ingresar Usuario y Contraseña");
            }
            else
            {
                users client = GetUserByCredentials();
                if (client != null)
                {
                    await this.ShowMessageAsync("Hola", string.Format("BIENVENIDO"));
                    Menu menu = new Menu();
                    this.Close();
                    menu.ShowDialog();
                }
                else
                {
                    await this.ShowMessageAsync("Aviso", string.Format("Tus Datos son incorrectos"));
                }
            }
        }


        private users GetUserByCredentials()
        {
            users user = null;
            foreach (users u in DB.users)
            {
                if (u.username.Equals(txtUsuario.Text) && u.password.Equals(txtContraseña.Password))
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
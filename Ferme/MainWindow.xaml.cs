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
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Formulario miformulario = new Formulario();

            miformulario.Show();
            this.Close();
           
                
        }

        List<Clientes> misCli = new List<Clientes>();

        private async void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            Clientes cli = new Clientes();

            if (string.IsNullOrEmpty(txtUsuario.Text))
                await this.ShowMessageAsync("Falta Campo", " Usuario ");
            if (string.IsNullOrEmpty(txtContraseña.Password))
                await this.ShowMessageAsync("Falta Campo", " Contraseña ");

            else
            {
                await this.ShowMessageAsync("Aviso", string.Format("BIENVENIDO"));
                misCli.Add(cli);

            }
        }
    }
}
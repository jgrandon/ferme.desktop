using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Ferme
{
    class Clientes 
    {   
        private string rut;
        private string apellidos;
        private string nombre;
        private string email;
        private string direccion;
        private string telefono;
        private string contraseña;
        private string confcontraseña;
        private string usuario;

        public Clientes()
        {
        }

        public Clientes(string rut, string apellidos, string nombre, string email, string direccion, string telefono, string contraseña, string confcontraseña, string usuario
            )
        {
            this.rut = rut;
            this.apellidos = apellidos;
            this.nombre = nombre;
            this.email = email;
            this.direccion = direccion;
            this.telefono = telefono;
            this.contraseña = contraseña;
            this.confcontraseña = confcontraseña;
            this.usuario = usuario;

        }

     
      



        public string Rut { get => rut; set => rut = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Confcontraseña { get => confcontraseña; set => confcontraseña = value; }
        public string Usuario { get => usuario; set => usuario = value; }

    }

   

}

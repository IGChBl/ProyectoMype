using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto.Forms
{
    public partial class frmInicio : Form
    {
        private List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Nombre = "Ivan", Apellido = "Chavarría", Matricula = "15021113", Carrera = "Ingeniería en Sistemas", Telefono = "", Email = "ichavarria@uamv.edu.ni", Direccion = "", FechaNacimiento = "31/07/1997", Sexo = "M", Contraseña = "ABC123!" },
            new Usuario { Nombre = "Violeta", Apellido = "Vanegas", Matricula = "", Carrera = "Ingeniería en Sistemas", Telefono = "", Email = "", Direccion = "", FechaNacimiento = "", Sexo = "F", Contraseña = "PantonyRival" },
        };
        public frmInicio()
        {
            InitializeComponent();
            this.Icon = new Icon(@"Resources\CornIslandTV.ico");
        }

        private bool ValidarUsuario(string nombre, string contraseña)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.Nombre == nombre && usuario.Contraseña == contraseña)
                {
                    return true;
                }
            }
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Comprueba si desea salir realmente de la aplicacion
            if (MessageBox.Show("¿Realmente desea cerrar la aplicación?", "Inicio de sesion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
                
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Trim es para limpiar espacios al principio y final de la cadena ingresada en la text box
            string usuario = tbUser.Text.Trim();
            string contrasena = tbPassword.Text.Trim();

            if (ValidarUsuario(usuario, contrasena))
            {
                frmMenuPrincipal frmmenuPrincipal = new frmMenuPrincipal();
                frmmenuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = '*';
        }
    }
}

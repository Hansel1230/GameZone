using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsAppGameZone
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        #region Eventos 
        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            string username, pass;
            username = textBoxUsuario.Text;
            pass = textBoxContrasena.Text;
            MySqlConnection con = new MySqlConnection("server = 127.0.0.1; Database=gamezone; User Id = root; password=hansel1230");
            try
            {
                con.Open();
            }
            catch (MySqlException ex) { MessageBox.Show("Error " + ex.ToString()); 
            }

            String sql = "select eNombre,eContrasena from empleado where eNombre ='" + username + "' AND eContrasena ='" + pass + "' ";
            MySqlCommand comando = new MySqlCommand(sql, con);
            MySqlDataReader read = comando.ExecuteReader();
            if (read.Read())
            {
                this.Hide();
                MessageBox.Show("Bienvenido " + username);

            }
            else if(textBoxUsuario.Text =="Ingrese su usuario" || textBoxContrasena.Text== "Ingrese su contraseña")
            {
                MessageBox.Show("Ingrese sus credenciales");
            }
            else
            {
                MessageBox.Show("No existe el usuario " + username);
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void textBoxUsuario_Leave(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text == "")
            {
                textBoxUsuario.Text = "Ingrese su usuario";
                textBoxUsuario.ForeColor = Color.Black;
            }
        }

        private void textBoxUsuario_Enter(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text == "Ingrese su usuario")
            {
                textBoxUsuario.Text = "";
                textBoxUsuario.ForeColor = Color.Black;
            }
        }
      
        private void textBoxContrasena_Leave(object sender, EventArgs e)
        {
            if (textBoxContrasena.Text == "")
            {
                textBoxContrasena.Text = "Ingrese su contraseña";
                textBoxContrasena.ForeColor = Color.Black;
                textBoxContrasena.UseSystemPasswordChar = true;

            }
        }

        private void textBoxContrasena_Enter(object sender, EventArgs e)
        {
            if (textBoxContrasena.Text == "Ingrese su contraseña")
            {
                textBoxContrasena.Text = "";
                textBoxContrasena.ForeColor = Color.Black;
                textBoxContrasena.UseSystemPasswordChar = false;
            }
        }
        #endregion

        private void checkBoxMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMostrar.Checked == true)
            {
                textBoxContrasena.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxContrasena.UseSystemPasswordChar = true;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
             
        }
    }

}

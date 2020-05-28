using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parical02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            poblarControles();
        }

        private void poblarControles()
        {
            // Actualizar ComboBox
            cmbUsuario.DataSource = null;
            cmbUsuario.ValueMember = "contrasena";
            cmbUsuario.DisplayMember = "Username";
            cmbUsuario.DataSource = UsuarioDAO.getLista();
        }
        private void btnIniSes_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedValue.Equals(txtContrasena.Text))
            {
                Usuario u = (Usuario) cmbUsuario.SelectedItem;

                MessageBox.Show("¡Bienvenido!", 
                    "Hugo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                FrmPrincipal ventana = new FrmPrincipal(u);
                ventana.Show();
                this.Hide();
                    
            }
            else
                MessageBox.Show("¡Contraseña incorrecta!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
    }
}
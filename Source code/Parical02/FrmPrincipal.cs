using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Parical02
{
    public partial class FrmPrincipal : Form
    {
        private Usuario usuario;
        private Dirección direccion1;
        private bool Administrator=true;
        public FrmPrincipal(Usuario pUsuario)
        {
            usuario = pUsuario;
            InitializeComponent();
            if (usuario.userType)
            {
            }
            else
            {
                // Los usuarios NO administradores no tienen permiso de acceder a estas pestanas
                tabControl1.TabPages[4].Parent = null;
                tabControl1.TabPages[4].Parent = null;
                tabControl1.TabPages[4].Parent = null;
            }
            actualizar();
        }

        private void actualizar()
        {    //actualizar combo box empresa 
            cmbEmpresa.DataSource = null;
            cmbEmpresa.ValueMember = "idBuisness";
            cmbEmpresa.DisplayMember = "NameE";
            cmbEmpresa.DataSource = EmpresaDAO.getEmpresa();
            
            //actualizar combo box Producto
            cmbProducto.DataSource = null;
            cmbProducto.ValueMember = "idProduct";
            cmbProducto.DisplayMember = "nameP";
            cmbProducto.DataSource = ProductoDAO.getProducto();
            
            //Obtener id de la dirección
            bool existe = false;
            string sql = "SELECT * FROM \"Address\"";
            DataTable dt = Conexion.realizarConsulta(sql);
            foreach (DataRow fila in dt.Rows)
            {
                if (usuario.idUser == Convert.ToInt32(fila[1].ToString()))
                {
                    Dirección u = new Dirección();
                    u.idAddress = Convert.ToInt32(fila[0].ToString());
                    direccion1 = u;
                }
            }
            
            //actualizar dataGrid
            dgvOrdenes.DataSource = null;
            dgvOrdenes.DataSource = OrdenesDAO.getOrdenes();
            
            //actualizar usuarios
            cmbUsuario.DataSource = null;
            cmbUsuario.ValueMember = "idUser";
            cmbUsuario.DisplayMember = "Username";
            cmbUsuario.DataSource = UsuarioDAO.getLista();
            
            //actualizar dirección
            cmbDirección.DataSource = null;
            cmbDirección.ValueMember = "idAddress";
            cmbDirección.DisplayMember = "address";
            cmbDirección.DataSource = DirecciónDAO.getDirección();
            
            //actualizar pedidos
            cmbPedido.DataSource = null;
            cmbPedido.ValueMember = "idOrder";
            cmbPedido.DisplayMember = "idOrder";
            cmbPedido.DataSource = OrdenesDAO.getOrdenes();
            
            //actualizar combobox de empresa para eliminar
            cmbEmpresa1.DataSource = null;
            cmbEmpresa1.ValueMember = "idBuisness";
            cmbEmpresa1.DisplayMember = "NameE";
            cmbEmpresa1.DataSource = EmpresaDAO.getEmpresa();
            
            //actualizar combobox de producto para eliminar
            cmbProducto1.DataSource = null;
            cmbProducto1.ValueMember = "idProduct";
            cmbProducto1.DisplayMember = "nameP";
            cmbProducto1.DataSource = ProductoDAO.getProducto();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            label2.Text = 
                "Bienvenido " + usuario.Username + " [" + (usuario.userType ? "Administrador" : "Usuario") + "]";
        }

        private void btnActDir_Click(object sender, EventArgs e)
        {
            bool existe = false;
            string sql = "SELECT \"idUser\" FROM \"Address\"";
            DataTable dt = Conexion.realizarConsulta(sql);
            foreach (DataRow fila in dt.Rows)
            {
                Dirección u = new Dirección();
                u.idUser1 = Convert.ToInt32(fila[0].ToString());
                if (u.idUser1 == usuario.idUser)
                {
                    existe = true;
                }
            }

            
            if (txtDireccion.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }
            else if(!existe)
            {
                try
                {
                    Conexion.realizarAccion($"insert into \"Address\"" +
                                            $"(address, \"idUser\") " +
                                            $"values ('{txtDireccion.Text}',{usuario.idUser})");
                    MessageBox.Show("Se ha registrado la dirección");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
                }
            else
            {
                try
                {
                    Conexion.realizarAccion($"update \"Address\"" +
                                            $"set address = '{txtDireccion.Text}'" +
                                            $"where \"idUser\"= {usuario.idUser}");
                    MessageBox.Show("Se ha registrado la dirección");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                } 
            }

            actualizar();
        }

        private void btnAgregarEmp_Click(object sender, EventArgs e)
        {
            if (txtEmp.Text.Equals("") || txtDesc.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }
            else
            {
                try
                {
                    Conexion.realizarAccion($"insert into \"Buisness\"" +
                                            $"(\"Name\", \"Description\") " +
                                            $"values ('{txtEmp.Text}','{txtDesc.Text}')");
                    MessageBox.Show("Se ha registrado la empresa");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
            actualizar();
        }

        private void btnAgrPro_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }
            else
            {
                try
                {
                    Conexion.realizarAccion($"insert into \"Product\"" +
                                            $"(\"idBuisness\", name) " +
                                            $"values ({cmbEmpresa.SelectedValue},'{txtProducto.Text}')");
                    MessageBox.Show("Se ha registrado el producto");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
            actualizar();
        }

        private void btnPedir_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    Conexion.realizarAccion($"insert into \"AppOrder\"" +
                                            $"(\"createDate\",\"idProduct\", \"idAddress\") " +
                                            $"values ('{DateTime.Now}',{cmbProducto.SelectedValue},{direccion1.idAddress})");
                    MessageBox.Show("Se ha registrado la orden");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
            actualizar();
        }

        private void btnActuaCont_Click(object sender, EventArgs e)
        {
            if (txtContAct.Text.Equals("") || txtNewCont.Text.Equals("") || txtReNewCont.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }
            else if(txtContAct.Text.Equals(usuario.contrasena) && txtNewCont.Text.Equals(txtReNewCont.Text))
            {
                try
                {
                    Conexion.realizarAccion($"UPDATE \"AppUser\" SET \"Password\" = '{txtNewCont.Text}' " +
                                            $"WHERE \"idUser\" = {usuario.idUser}");
                    MessageBox.Show("Se ha actualizado la contraseña");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas deben ser iguales");
            }
            actualizar();
        }

        private void Administ_CheckedChanged(object sender, EventArgs e)
        {
            Administrator = true;
            actualizar();
        }

        private void UserR_CheckedChanged(object sender, EventArgs e)
        {
            Administrator = false;
            actualizar();
        }

        private void btnEliUsu_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion.realizarAccion($"DELETE FROM \"AppUser\" WHERE \"idUser\" = {cmbUsuario.SelectedValue}");
                MessageBox.Show("Se ha eliminado el usuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            actualizar();
        }

        private void btnAgreUsu_Click(object sender, EventArgs e)
        {
            if (txtNombreN.Text.Equals("") || txtContraN.Text.Equals("")|| txtUsuarioN.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar campos vacios");
            }
            else
            {
                try
                {
                    Conexion.realizarAccion($"insert into \"AppUser\"" +
                                            $"(\"Fullname\",\"Username\", \"Password\",\"userType\")" +
                                            $"values ('{txtNombreN.Text}', '{txtUsuarioN.Text}', '{txtContraN.Text}',{Administrator})");
                    MessageBox.Show("Se ha registrado el usuario");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
            actualizar();
        }

        private void btnHacerA_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion.realizarAccion($"UPDATE \"AppUser\" SET \"userType\" = true " +
                                        $"WHERE \"idUser\" = {cmbUsuario.SelectedValue}");
                MessageBox.Show("Se ha hecho Administrador!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            actualizar();
        }
        
        private void btnHacerU_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion.realizarAccion($"UPDATE \"AppUser\" SET \"userType\" = false " +
                                        $"WHERE \"idUser\" = {cmbUsuario.SelectedValue}");
                MessageBox.Show("Se ha hecho usuario!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            actualizar();
        }
        
        private void btnEliDirec_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion.realizarAccion($"DELETE FROM \"Address\" WHERE \"idAddress\" = {cmbDirección.SelectedValue}");
                MessageBox.Show("Se ha eliminado la dirección");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            actualizar();
        }

        private void btnEliPed_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion.realizarAccion($"DELETE FROM \"AppOrder\" WHERE \"idOrder\" = {cmbPedido.SelectedValue}");
                MessageBox.Show("Se ha eliminado la orden");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            actualizar();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion.realizarAccion($"DELETE FROM \"Buisness\" WHERE \"idBuisness\" = {cmbEmpresa1.SelectedValue}");
                MessageBox.Show("Se ha eliminado la empresa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            actualizar();
        }
        
        private void btnEliProd_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion.realizarAccion($"DELETE FROM \"Product\" WHERE \"idProduct\" = {cmbProducto1.SelectedValue}");
                MessageBox.Show("Se ha eliminado el producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            actualizar();
        }
        
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir, " + usuario.Username + "?", 
                "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    e.Cancel = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ha sucedido un error, favor intente dentro de un minuto.", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
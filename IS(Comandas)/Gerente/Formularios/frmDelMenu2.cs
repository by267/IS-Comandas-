using Guna.UI2.WinForms.Suite;
using IS_Comandas_.Gerente.Clases;
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

namespace IS_Comandas_.Gerente.Formularios
{
    public partial class frmDelMenu2 : Form
    {
        public static string Nombre;
        public frmDelMenu2()
        {
            InitializeComponent();
        }
        private void hab()
        {
            btnEliminar.Enabled = true;

            txtNombre.Enabled = false;
            dgvDatos.Enabled = false;
            btnBuscar.Enabled = false;
        }
        private void Uhab()
        {
            txtNombre.Enabled = true;
            btnBuscar.Enabled = true;

            dgvDatos.DataSource = null;
            txtNombre.Text = null;
        }
        private void datos()
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=comandas; Uid=root; pwd=123456;");
            MySqlCommand actualizargrid = new MySqlCommand("select * from menu where Nombre like('" + txtNombre.Text + "%')", conectar);
            MySqlDataAdapter adaptador = new MySqlDataAdapter(actualizargrid);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvDatos.DataSource = tabla;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                txtNombre.Text = Nombre;
                hab();
            }
            else
            {
                MessageBox.Show("Rellene los campos correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Nombre = dgvDatos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                datos();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dbMenu database = new dbMenu();
            ClassMenu obj = new ClassMenu();

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Seleccione una opción válida.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                obj.Nombre = txtNombre.Text;
                Uhab();
                DataTable datos = new DataTable();
                database.EliminarE(obj);

                MessageBox.Show("El producto se eliminó con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.Show();
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IS_Comandas_.Gerente.Clases;
using IS_Comandas_.Gerente.Formularios;
using IS_Comandas_.Mesero.Clases;
using MySql.Data.MySqlClient;

namespace IS_Comandas_.Mesero
{
    public partial class frmDelComanda : Form
    {
        public static string Mesa;
        public frmDelComanda()
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
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            dbcomandas database = new dbcomandas();
            ClassMenu obj = new ClassMenu();

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Seleccione una opcion valida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                obj.Nombre = txtNombre.Text;
                Uhab();
                DataTable datos = new DataTable();
                database.EliminarE(obj);

                MessageBox.Show("La comanda se elimino con exito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void datos()
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=comandas; Uid=root; pwd=123456;");
            MySqlCommand actualizargrid = new MySqlCommand("select * from comandas where producto like('" + txtNombre.Text + "%')", conectar);
            MySqlDataAdapter adaptador = new MySqlDataAdapter(actualizargrid);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvDatos.DataSource = tabla;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmMainMesero frm = new frmMainMesero();
            frm.Show();
            this.Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                datos();
            }*/
            datos();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Mesa = dgvDatos.Rows[e.RowIndex].Cells["mesa"].Value.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "") //perro
            {
                txtNombre.Text = Mesa;
                hab();
            }
            else
            {
                MessageBox.Show("Rellene correctamente los campos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

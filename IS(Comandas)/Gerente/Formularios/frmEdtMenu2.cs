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
using MySql.Data.MySqlClient;

namespace IS_Comandas_.Gerente.Formularios
{
    public partial class frmEdtMenu2 : Form
    {
        public static string ID;
        public static string Nombre;
        public static string Descripcion;
        public static string Precio;
        public static string Categoria;
        public frmEdtMenu2()
        {
            InitializeComponent();
        }
        private void hab()
        {
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;
            cmbCategoria.Enabled = true;
            btnAceptar.Enabled = true;
            dgvDatos.Enabled = false;
            txtSearch.Enabled = false;
            btnBuscar.Enabled = false;
        }
        private void Uhab()
        {

            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            cmbCategoria.Enabled = false;
            txtSearch.Enabled = true;
            btnBuscar.Enabled = true;


            dgvDatos.DataSource = null;
            txtNombre.Text = null;
            txtDescripcion.Text = null;
            txtPrecio.Text = null;
            cmbCategoria.Text = null;
            cmbCategoria.DataSource = null;
            txtSearch.Text = null;
        }
        private void cargarComboP()
        {
            dbCategoria db = new dbCategoria();

            cmbCategoria.DataSource = db.ConsultarU("nombre");
            cmbCategoria.DisplayMember = "nombre";
            cmbCategoria.ValueMember = "nombre";
        }
        private void datos()
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=comandas; Uid=root; pwd=123456;");
            MySqlCommand actualizargrid = new MySqlCommand("select * from menu where Nombre like('" + txtSearch.Text + "%')", conectar);
            MySqlDataAdapter adaptador = new MySqlDataAdapter(actualizargrid);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dgvDatos.DataSource = tabla;
        }
        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                dgvDatos.Enabled = true;
                datos();
            }
        }
        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgvDatos.Rows[e.RowIndex].Cells["idMenu"].Value.ToString();
            Nombre = dgvDatos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            Descripcion = dgvDatos.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
            Precio = dgvDatos.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
            Categoria = dgvDatos.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                txtSearch.Text = ID;
                txtNombre.Text = Nombre;
                txtDescripcion.Text = Descripcion;
                txtPrecio.Text = Precio;
                cmbCategoria.Items.Add(Categoria);
                cmbCategoria.StartIndex = 0;
                hab();
            }
            else
            {
                MessageBox.Show("Rellene los campos correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }       
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbMenu database = new dbMenu();
            ClassMenu obj = new ClassMenu();
            obj.Id = int.Parse(txtSearch.Text);
            obj.Nombre = txtNombre.Text;
            obj.Descripcion = txtDescripcion.Text;
            obj.Precio = float.Parse(txtPrecio.Text);
            obj.Categoria = cmbCategoria.Text;
            Uhab();
            database.Actualizar(obj);
            MessageBox.Show("La información se actualizó con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void cmbCategoria_Click(object sender, EventArgs e)
        {
            cargarComboP();
        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar si la tecla presionada es un número o un punto decimal.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                // Cancelar la pulsación de la tecla.
                e.Handled = true;
            }

            // Permitir solo un punto decimal.
            if (e.KeyChar == '.' && txtPrecio.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar si la tecla presionada es una letra o un espacio.
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                // Cancelar la pulsación de la tecla.
                e.Handled = true;
            }
            // Convertir la primera letra a mayúscula.
            if (txtNombre.SelectionStart == 0 && char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.Show();
            this.Close();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar si la tecla presionada es una letra o un espacio.
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' ') && !char.IsDigit(e.KeyChar))
            {
                // Cancelar la pulsación de la tecla.
                e.Handled = true;
            }
            // Convertir la primera letra a mayúscula.
            if (txtDescripcion.SelectionStart == 0 && char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
    }
}

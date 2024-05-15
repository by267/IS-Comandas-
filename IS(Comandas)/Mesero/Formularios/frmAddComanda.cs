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
using IS_Comandas_.Mesero.Clases;

namespace IS_Comandas_.Mesero
{
    public partial class frmAddComanda : Form
    {
        public static string ID;
        public static string Nombre;
        public static string Descripcion;
        public static string Precio;
        public static string Categoria;

        public static string dbProducto;
        public static float dbPrecio;
        public static string dbCantidad;
        public static string dbNoComanda;
        public static string dbComentarios;
        public static int dbMesa;

        private void cargarCombo()
        {
            cmbMesa.Text = "Selecciona una opcion";
            dbMesa db = new dbMesa();

            cmbMesa.DataSource = db.ConsultarO("idmesas");
            cmbMesa.DisplayMember = "idmesas";
            cmbMesa.ValueMember = "idmesas";
        }
        private void act()
        {
            txtSearch.Enabled = true;
            txtCantidad.Enabled = true;
            txtComentarios.Enabled = true;
            txtNoComanda.Enabled = true;
            dgvDatos.Enabled = true;
            btnAgregar.Enabled = true;
        }
        private void Uhab()
        {

            txtSearch.Enabled = false;
            txtCantidad.Enabled = false;
            txtComentarios.Enabled = false;
            txtNoComanda.Enabled = false;
            dgvDatos.Enabled = false;
            btnAgregar.Enabled = false;
            cmbMesa.Enabled = true;


            dgvDatos.DataSource = null;
            dgvComanda.Rows.Clear();
            txtSearch.Text = null;
            txtCantidad.Text = null;
            txtComentarios.Text = null;
            txtNoComanda.Text = null;
            cmbMesa.DataSource = null;
            cmbMesa.Text = null;


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
        public frmAddComanda()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmMainMesero frm = new frmMainMesero();
            frm.Show();
            this.Close();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAddComanda_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cargarCombo();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgvDatos.Rows[e.RowIndex].Cells["idMenu"].Value.ToString();
            Nombre = dgvDatos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            Descripcion = dgvDatos.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
            Precio = dgvDatos.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
            Categoria = dgvDatos.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dbProducto = Nombre;
            dbPrecio = float.Parse(Precio);
            dbCantidad = txtCantidad.Text;
            dbNoComanda = txtNoComanda.Text;
            dbComentarios = txtComentarios.Text;
            dbMesa = int.Parse( cmbMesa.Text);

            //cargarproducto();
            if(txtCantidad.Text == "" || txtNoComanda.Text == "" || txtSearch.Text == "")
            {
                MessageBox.Show("Rellene correctamente los campos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvComand();
                meterDB();
            }
            txtNoComanda.Enabled = false;
            txtSearch.Text = null;
            txtCantidad.Text = null;
            txtComentarios.Text = null;
            dgvDatos.DataSource = null;
        }
        private void dgvComand()
        {
            int n = dgvComanda.Rows.Add();

            dgvComanda.Rows[n].Cells[0].Value = dbProducto;
            dgvComanda.Rows[n].Cells[1].Value = dbPrecio;
            dgvComanda.Rows[n].Cells[2].Value = dbCantidad;

        }

        private void meterDB()
        {
            dbcomandas database = new dbcomandas();
            clasecomanda obj = new clasecomanda();
            DataTable datos = new DataTable();

            //obj. = int.Parse(txtSearch.Text);
            obj.producto = dbProducto;
            obj.precio = dbPrecio;
            obj.cantidad = int.Parse(dbCantidad);
            obj.noComanda = dbNoComanda;
            obj.comentarios = dbComentarios;
            obj.mesa = dbMesa;

            //Uhab();
            database.Agregar(obj);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            act();
            cmbMesa.Enabled = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La comanda se creó con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Uhab();
        }

        private void txtNoComanda_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar si la tecla presionada es un número o un punto decimal.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancelar la pulsación de la tecla.
                e.Handled = true;
            }
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar si la tecla presionada es un número o un punto decimal.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancelar la pulsación de la tecla.
                e.Handled = true;
            }
        }
    }
}

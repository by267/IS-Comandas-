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
using IS_Comandas_.Gerente.Clases;
using MySql.Data.MySqlClient;
using IS_Comandas_.Mesero.Clases;

namespace IS_Comandas_.Mesero
{
    public partial class frmAddComanda : Form
    {
        public static string ID;
        public static string Nombre;
        public static string Descripcion;
        public static string Precioo;
        public static string Categoria;
        private void cargarCombo()
        {
            cmbMesa.Text = "Selecciona una opcion";
            dbMesa db = new dbMesa();

            cmbMesa.DataSource = db.ConsultarO("idmesas");
            cmbMesa.DisplayMember = "idmesas";
            cmbMesa.ValueMember = "idmesas";
        }
        private void datos()
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=comandas; Uid=root; pwd=admin;");
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
            Precioo = dgvDatos.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
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
            cargarproducto();


            /* dbcomandas database = new dbcomandas();
            clasecomanda obj = new clasecomanda();
            obj.producto = txtNombre.Text;
            obj.precio = txtUsuario.Text;
            obj.cantidad = cmbPuesto.Text;
            obj.comentarios = txtPass.Text;
            asd = cmbPuesto.Text;

            DataTable datos = new DataTable();
            datos = database.ConsultarCodigoH(obj);
            if (datos.Rows.Count > 0)
            {
                MessageBox.Show("El empleado ya existe", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtNombre.Text != "" && txtUsuario.Text != "" && txtPass.Text != "" && cmbPuesto.Text != "")
                {
                    database.Agregar(obj);
                    MessageBox.Show("El empleado se agrego con exito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Rellene correctamente los campos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } */
        }
        private void cargarproducto()
        {
            dbMenu dbe = new dbMenu();
            ClassMenu obj = new ClassMenu();
            DataTable datos = new DataTable();

            obj.Nombre = txtSearch.Text;
            datos = dbe.ConsultarP(obj);
                if (datos.Rows.Count > 0)
            {
                label8.Text = datos.Rows[0]["nombre"].ToString();
                label9.Text = datos.Rows[0]["precio"].ToString();
            }

        }
    }
}

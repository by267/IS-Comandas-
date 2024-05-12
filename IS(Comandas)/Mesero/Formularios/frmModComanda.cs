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
using System.Data.SqlClient;


namespace IS_Comandas_.Mesero
{
    public partial class frmModComanda : Form
    {
        private SqlConnection connection;
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
            cmbNoComanda.Text = "Selecciona una opcion";
            dbcomandas db = new dbcomandas();

            cmbNoComanda.DataSource = db.ConsultarO("noComanda");
            cmbNoComanda.DisplayMember = "noComanda";
            cmbNoComanda.ValueMember = "noComanda";
        }
        private void act()
        {
            txtSearch.Enabled = true;
            txtCantidad.Enabled = true;
            txtComentarios.Enabled = true;
            
            dgvDatos.Enabled = true;
            btnAgregar.Enabled = true;
        }
        private void Uhab()
        {

            txtSearch.Enabled = false;
            txtCantidad.Enabled = false;
            txtComentarios.Enabled = false;
            
            dgvDatos.Enabled = false;
            btnAgregar.Enabled = false;
            cmbNoComanda.Enabled = true;


            dgvDatos.DataSource = null;
            dgvComanda.Rows.Clear();
            txtSearch.Text = null;
            txtCantidad.Text = null;
            txtComentarios.Text = null;
            
            cmbNoComanda.DataSource = null;
            cmbNoComanda.Text = null;


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
        /*private void dgvComand()
        {
            int n = dgvComanda.Rows.Add();

            dgvComanda.Rows[n].Cells[0].Value = dbProducto;
            dgvComanda.Rows[n].Cells[1].Value = dbPrecio;
            dgvComanda.Rows[n].Cells[2].Value = dbCantidad;

        }*/

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
        private void cargarMesa()
        {
            dbcomandas dbe = new dbcomandas();
            clasecomanda obj = new clasecomanda();
            DataTable datos = new DataTable();

            obj.noComanda = cmbNoComanda.Text;
            datos = dbe.ConsultarPuesto(obj);
            if (datos.Rows.Count > 0)
            {
                lblMesa.Text = datos.Rows[0]["mesa"].ToString();
            }

        }
        private void cargarDatos()
        {
            dbcomandas database = new dbcomandas();
            DataTable datos = new DataTable();
            clasecomanda obj = new clasecomanda();
            obj.noComanda = cmbNoComanda.SelectedValue.ToString();
            datos = database.ConsultarCodigoH(obj);
            dgvComanda.DataSource = datos;
        }
        private void desMesa()
        {
            dbMesa database = new dbMesa();
            ClassMesa obj = new ClassMesa();
            obj.Id = int.Parse(cmbNoComanda.Text);
            database.desactivarMesa(obj);
            //MessageBox.Show("La mesa se activó con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public frmModComanda()
        {
            InitializeComponent();
            string connectionString = "server=127.0.0.1; database=comandas; Uid=root; pwd=123456;";
            connection = new SqlConnection(connectionString);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmMainMesero frm = new frmMainMesero();
            frm.Show();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dbcomandas database = new dbcomandas();
            DataTable datos = new DataTable();
            clasecomanda obj = new clasecomanda();

            if (dgvComanda.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvComanda.SelectedRows[0];

                // Verifica si hay una fila seleccionada
                if (selectedRow != null)
                {
                    obj.Id = (int)selectedRow.Cells["idComandas"].Value;

                    database.EliminarD(obj);

                    // Actualiza el DataGridView
                    dgvComanda.Rows.Remove(selectedRow);
                }
                else
                {
                    MessageBox.Show("Seleccione una fila valida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hay elementos seleccionados", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Obtiene la fila seleccionada en el DataGridView



        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            cargarDatos();
            act();
            cmbNoComanda.Enabled = false;
            cargarMesa();
        }

        private void frmModComanda_Load(object sender, EventArgs e)
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
            dbNoComanda = cmbNoComanda.Text;
            dbComentarios = txtComentarios.Text;
            dbMesa = int.Parse(lblMesa.Text);

            //cargarproducto();
            if (txtCantidad.Text == "" || txtSearch.Text == "")
            {
                MessageBox.Show("Rellene correctamente los campos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //dgvComand();
                meterDB();
                cargarDatos();

            }
            //txtNoComanda.Enabled = false;
            txtSearch.Text = null;
            txtCantidad.Text = null;
            txtComentarios.Text = null;
            dgvDatos.DataSource = null;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La icomanda se actualizo con exito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            frmMainMesero frm = new frmMainMesero();
            frm.Show();
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}
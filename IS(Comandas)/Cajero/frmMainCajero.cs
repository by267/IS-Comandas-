using IS_Comandas_.Cajero;
using IS_Comandas_.Gerente.Clases;
using IS_Comandas_.Mesero.Clases;
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


namespace IS_Comandas_
{
    public partial class frmMainCajero : Form
    {

        public frmMainCajero()
        {
            InitializeComponent();
        }
        private void cargarCombo()
        {
            cmbMesa.Text = "Selecciona una opcion";
            dbMesa db = new dbMesa();

            cmbMesa.DataSource = db.ConsultarO("idmesas");
            cmbMesa.DisplayMember = "idmesas";
            cmbMesa.ValueMember = "idmesas";
        }
        private void cargarDatos()
        {
            dbcomandas database = new dbcomandas();
            DataTable datos = new DataTable();
            clasecomanda obj = new clasecomanda();
            obj.mesa = int.Parse(cmbMesa.SelectedValue.ToString());
            datos = database.ConsultarCodigoH(obj);
            dgvDatos.DataSource = datos;
        }

        private void btniCerrar_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();

            this.Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //desMesa();
            List<ticket> listaDatos = ObtenerDatosDataGridViewALista(dgvDatos);
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            cargarDatos();

            dbcomandas database = new dbcomandas();
            clasecomanda obj = new clasecomanda();
            DataTable datos = new DataTable();
            obj.mesa = int.Parse(cmbMesa.SelectedValue.ToString());
            datos = database.sumaTotal(obj);
            lblSubtotal.Text = datos.Rows[0]["subtotal"].ToString();

            txtPropina.Enabled = true;
        }

        private void frmMainCajero_Load(object sender, EventArgs e)
        {
            cargarCombo();
            //cargarDatos();

        }

        private void btniCerrar_Click_1(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btnAcptPropina_Click(object sender, EventArgs e)
        {
            float subtotal = float.Parse(lblSubtotal.Text);
            int propina = int.Parse(txtPropina.Text);

            float porPropina = subtotal / 100 * propina;
            float total = subtotal + porPropina;

            lblTotal.Text = total.ToString();
        }

        private void desMesa()
        {
            dbMesa database = new dbMesa();
            ClassMesa obj = new ClassMesa();
            obj.Id = int.Parse(cmbMesa.SelectedValue.ToString());
            database.desactivarMesa(obj);
            //MessageBox.Show("La mesa se activó con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private List<ticket> ObtenerDatosDataGridViewALista(DataGridView dataGridView)
        {
            List<ticket> listaDatos = new List<ticket>();

            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                try
                {
                    // Check if the cell value is not null
                    if (fila.Cells["Producto"].Value != null)
                    {
                        string nombre = fila.Cells["Producto"].Value.ToString();

                        // Create a new ticket object
                        ticket dato = new ticket();
                        dato.Producto = nombre;

                        // Add the object to the list
                        listaDatos.Add(dato);
                        MessageBox.Show("lista metida hasta el fondo");

                    }
                }
                catch (NullReferenceException ex)
                {
                    // Handle the null reference exception gracefully
                    //Console.WriteLine("Error en la fila " + fila.Index + ": " + ex.Message);
                }
            }

            return listaDatos;
        }



    }
}

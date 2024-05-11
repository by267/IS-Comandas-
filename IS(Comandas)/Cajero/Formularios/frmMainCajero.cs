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
using System.Data.SqlClient;
using IS_Comandas_.Cajero.Formularios;
using static IS_Comandas_.Cajero.Formularios.frmCobro;


namespace IS_Comandas_
{
    public partial class frmMainCajero : Form
    {
        List<ticket> listaDatos = new List<ticket>();
        int propina;
        float subtotal;
        float porPropina;
        float total;
        public static class compartir2
        {
            public static int ingreso { get; set; }
            public static float feria { get; set; }
        }
        float feria = compartir2.feria;
        int ingreso = compartir2.ingreso;
        public frmMainCajero()
        {
            InitializeComponent();
        }
        private void cargarCombo()
        {
            cmbNoComanda.Text = "Selecciona una opcion";
            dbcomandas db = new dbcomandas();

            cmbNoComanda.DataSource = db.ConsultarO("noComanda");
            cmbNoComanda.DisplayMember = "noComanda";
            cmbNoComanda.ValueMember = "noComanda";
        }
        private void cargarDatos()
        {
            dbcomandas database = new dbcomandas();
            DataTable datos = new DataTable();
            clasecomanda obj = new clasecomanda();
            obj.noComanda = cmbNoComanda.SelectedValue.ToString();
            datos = database.ConsultarCodigoH(obj);
            dgvDatos.DataSource = datos;
        }

        private void btniCerrar_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();

            this.Hide();

        }
        public void desactivartodo()
        {
            txtPropina.Text = null;
            txtPropina.Enabled = false;

            dgvDatos.DataSource = null;
            btnAceptar.Enabled = false;
            btnAcptPropina.Enabled = false;

            lblSubtotal.Text = null;
            lblTotal.Text = null;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            registrar();  
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            cargarDatos();

            dbcomandas database = new dbcomandas();
            clasecomanda obj = new clasecomanda();
            DataTable datos = new DataTable();
            obj.noComanda = cmbNoComanda.SelectedValue.ToString();
            datos = database.sumaTotal(obj);
            lblSubtotal.Text = datos.Rows[0]["subtotal"].ToString();

            txtPropina.Enabled = true;
            btnAcptPropina.Enabled = true;
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
            if(txtPropina.Text == "")
            {
                MessageBox.Show("Deja propina no seas codo pinche pobre");
                //MessageBox.Show("Ingrese un porcentaje de propina");
            }
            else
            {
                subtotal = float.Parse(lblSubtotal.Text);
                propina = int.Parse(txtPropina.Text);

                porPropina = subtotal / 100 * propina;
                total = subtotal + porPropina;

                lblTotal.Text = total.ToString();

                DatosCompartidos.total = total;
                DatosCompartidos.mesa = cmbNoComanda.Text;

                btnPago.Enabled = true;
            }
        }

        private void desMesa()
        {
            dbMesa database = new dbMesa();
            ClassMesa obj = new ClassMesa();
            obj.Id = int.Parse(cmbNoComanda.SelectedValue.ToString());
            database.desactivarMesa(obj);
            //MessageBox.Show("La mesa se activó con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lista()
        {
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                // Check if the row is not empty
                if (fila.IsNewRow) continue;

                // Try to get the cell values
                try
                {
                    // Get the values from the corresponding cells
                    string nombre = fila.Cells["Producto"].Value.ToString();

                    // Create a new ticket object
                    ticket dato = new ticket();
                    dato.Producto = nombre;

                    // Add the ticket object to the list
                    listaDatos.Add(dato);
                }
                catch (NullReferenceException ex)
                {
                    // Handle the null reference exception gracefully
                    //Console.WriteLine("Error en la fila " + fila.Index + ": " + ex.Message);
                }
            }
        }
        public void registrar()
        {
            //desMesa();
            lista();

            // Convert the list data to text
            string text = "";
            foreach (ticket ticket in listaDatos)
            {
                text += $" {ticket.Producto},";
            }

            dbTicket database = new dbTicket();
            ticket obj = new ticket();
            DataTable datos = new DataTable();

            obj.Producto = text;
            obj.Total = total;
            obj.Feria = feria;
            obj.Ingreso = ingreso;


            database.Agregar(obj);
            MessageBox.Show("Ticket creado");
        }

        private void txtPropina_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar si la tecla presionada es un número o un punto decimal.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancelar la pulsación de la tecla.
                e.Handled = true;
            }
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            frmCobro frm = new frmCobro();
            frm.Show();
            btnAceptar.Enabled = true;

        }
    }
}
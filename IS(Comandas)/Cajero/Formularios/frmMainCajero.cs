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
using System.IO;
using System.Drawing.Printing;
using IS_Comandas_.Ticket;


namespace IS_Comandas_
{
    public partial class frmMainCajero : Form
    {
        List<ticket> listaDatos = new List<ticket>();
        private Font printFont;
        private StreamReader streamToPrint;
        int propina;
        float subtotal;
        float porPropina;
        float total;
        float feria;
        int ingreso;
        int Conteo;
        int Fila = 0;
        int mesa;
        public string empleado;
        public static class DatosCompartidos
        {
            public static string Empleado { get; set; }
        }
        //public static string Empleado;
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
            txtPropina.Text = "";
            txtIngreso.Text = "";
            txtPropina.Enabled = false;
            txtIngreso.Enabled = false;

            dgvDatos.DataSource = null;
            btnAceptar.Enabled = false;
            btnAcptPropina.Enabled = false;

            lblSubtotal.Text = "";
            lblTotal.Text = "";
            lblCambio.Text = "";

            cmbInstalledPrinters.SelectedIndex = 2;
        }
        private void labelFeria()
        {
            float dinero = float.Parse(txtIngreso.Text);
            feria = dinero - total;
            lblCambio.Text = feria.ToString();
        }
        private void InstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cmbInstalledPrinters.Items.Add(pkInstalledPrinters);

            }
            cmbInstalledPrinters.Text = "PDFLite";
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
                mesa = Convert.ToInt32(datos.Rows[0]["mesa"].ToString());
            }

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(cmbInstalledPrinters == null)
            {
                MessageBox.Show("Seleccione una opcion valida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                imprimir();
                registrar();
                desactivartodo();
                desMesa();
                cargarCombo();
            }
            
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            

            dbcomandas database = new dbcomandas();
            clasecomanda obj = new clasecomanda();
            DataTable datos = new DataTable();
            if (cmbNoComanda.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una opcion valida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cargarDatos();
                cargarMesa();
                obj.noComanda = cmbNoComanda.SelectedValue.ToString();
                datos = database.sumaTotal(obj);
                lblSubtotal.Text = datos.Rows[0]["subtotal"].ToString();

                txtPropina.Enabled = true;
                btnAcptPropina.Enabled = true;
            }
        }

        private void frmMainCajero_Load(object sender, EventArgs e)
        {
            cargarCombo();
            InstalledPrintersCombo();
            cmbInstalledPrinters.SelectedIndex = 2;
            //empleado = DatosCompartidos.Empleado;
            empleado = DatosCompartidos.Empleado.ToString();
            label1.Text = empleado.ToString();
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
                //MessageBox.Show("Deja propina no seas codo pinche pobre");
                MessageBox.Show("Ingrese un porcentaje de propina", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                subtotal = float.Parse(lblSubtotal.Text);
                propina = int.Parse(txtPropina.Text);

                porPropina = subtotal / 100 * propina;
                total = subtotal + porPropina;

                lblTotal.Text = total.ToString();
                btnCalcular.Enabled = true;
                txtIngreso.Enabled = true;
            }
        }

        private void desMesa()
        {
            dbMesa database = new dbMesa();
            ClassMesa obj = new ClassMesa();
            obj.Id = mesa;
            database.desactivarMesa(obj);
            //MessageBox.Show("La mesa se activó con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dbcomandas database2 = new dbcomandas();
            clasecomanda obj2 = new clasecomanda();

            obj2.noComanda = cmbNoComanda.Text;

            database2.EliminarM(obj2);
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
            MessageBox.Show("El ticket se creo con exito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnCalcular_Click(object sender, EventArgs e)
        {            
            ingreso = int.Parse(txtIngreso.Text);
            if (ingreso > total)
            {
                labelFeria();
                btnAceptar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Cantidad insuficiente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void imprimir()
        {
            impTicket imp = new impTicket();
            ticket obj = new ticket();

            impTicket.CreaTicket Ticket1 = new impTicket.CreaTicket();

                Ticket1.TextoCentro("Empresa xxxxx "); //imprime una linea de descripcion
                Ticket1.TextoCentro("**********************************");

                Ticket1.TextoIzquierda("Dirc: xxxx");
                Ticket1.TextoIzquierda("Tel:xxxx ");
                Ticket1.TextoIzquierda("Rnc: xxxx");
                Ticket1.TextoIzquierda("");
                Ticket1.TextoCentro("Factura de Venta"); //imprime una linea de descripcion
                Ticket1.TextoIzquierda("No Fac:" + obj.Id);
                Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                Ticket1.TextoIzquierda("Le Atendio:"+empleado.ToString());
                Ticket1.TextoIzquierda("");

                impTicket.CreaTicket.LineasGuion();
                impTicket.CreaTicket.EncabezadoVenta();

                impTicket.CreaTicket.LineasGuion();
                Ticket1.AgregaTotales("Sub-Total", float.Parse(lblSubtotal.Text)); // imprime linea con Subtotal
                Ticket1.AgregaTotales("Descuento", float.Parse("000")); // imprime linea con decuento total
                Ticket1.TextoIzquierda(" ");
                Ticket1.AgregaTotales("Total", float.Parse(lblTotal.Text)); // imprime linea con total
                Ticket1.TextoIzquierda(" ");
                Ticket1.AgregaTotales("Efectivo Entregado:", float.Parse(txtIngreso.Text));
                Ticket1.AgregaTotales("Efectivo Devuelto:", float.Parse(lblCambio.Text));


                // Ticket1.LineasTotales(); // imprime linea 

                Ticket1.TextoIzquierda(" ");
                Ticket1.TextoCentro("**********************************");
                Ticket1.TextoCentro("*     Gracias por preferirnos    *");
                Ticket1.TextoCentro("**********************************");
                Ticket1.TextoIzquierda(" ");

                Ticket1.ImprimirTiket(cmbInstalledPrinters.Text); //Imprimir
            }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cargarCombo();
        }
        
    }
}
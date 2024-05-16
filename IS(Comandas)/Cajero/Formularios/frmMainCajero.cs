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
        float feriaR;
        int ingreso;
        int Conteo;
        int Fila = 0;
        int mesa;
        string producto;
        float precio;
        int cantidad;
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

            cmbNoComanda.DataSource = db.ConsultarO("mesa");
            cmbNoComanda.DisplayMember = "mesa";
            cmbNoComanda.ValueMember = "mesa";
        }
        private void cargarDatos()
        {
            dbcomandas database = new dbcomandas();
            DataTable datos = new DataTable();
            clasecomanda obj = new clasecomanda();
            
            obj.mesa = Convert.ToInt32(cmbNoComanda.SelectedValue.ToString());
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
            string roundedString = feria.ToString("F2"); 
            lblCambio.Text = roundedString.ToString();
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

            obj.mesa = Convert.ToInt32( cmbNoComanda.Text);
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
                MessageBox.Show("Seleccione una opcion válida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Seleccione una opcion válida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cargarDatos();
                cargarMesa();
                obj.mesa = Convert.ToInt32( cmbNoComanda.SelectedValue.ToString());
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
            label1.Text = "Bienvenido: " + empleado.ToString();
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
            obj.Id = Convert.ToInt32(cmbNoComanda.Text);
            database.desactivarMesa(obj);
            //MessageBox.Show("La mesa se activó con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dbcomandas database2 = new dbcomandas();
            clasecomanda obj2 = new clasecomanda();

            obj2.mesa = Convert.ToInt32(cmbNoComanda.Text);

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
            MessageBox.Show("El ticket se creó con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            dbcomandas dbe = new dbcomandas();
            clasecomanda obj2 = new clasecomanda();
            DataTable datos = new DataTable();

            obj2.mesa = Convert.ToInt32(cmbNoComanda.Text);
            datos = dbe.ConsultarInfo(obj2);

            int precision = 2; // Limit to 2 digits after the decimal point

            float subtotal1 = float.Parse(lblSubtotal.Text);
            float total1 = float.Parse(lblTotal.Text);
            float propina1 = subtotal1 / 100 * propina;
            float feria1 = float.Parse(lblCambio.Text);

            double subtotalRedondeado = Math.Round(subtotal1, precision);
            string subtotalRe = subtotalRedondeado.ToString();
            double totalRedondeado = Math.Round(total1, precision);
            string totalRe = totalRedondeado.ToString();
            double propinaRedondeado = Math.Round(propina1, precision);
            string propinaRe = propinaRedondeado.ToString();
            double ferialRedondeado = Math.Round(feria1, precision);
            string feriaRe = ferialRedondeado.ToString();

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

            if (datos.Rows.Count > 0)
            {
                

                foreach (DataRow row in datos.Rows)
                {
                    // Extract product information from the current row
                    string articulo = row["producto"].ToString();
                    float precio = float.Parse(row["precio"].ToString());
                  
                    double roundedNumber = Math.Round(precio, precision);
                    string precioR = roundedNumber.ToString();

                    int cantidad = Convert.ToInt32(row["cantidad"].ToString());
                    double subtotal = precio * cantidad;

                    double redondeado = Math.Round(subtotal, precision);
                    string subtotalR = roundedNumber.ToString();

                    // Add the item to the ticket
                    Ticket1.AgregaArticulo(articulo, precioR, cantidad, subtotalR);
                }
            }

            impTicket.CreaTicket.LineasGuion();
                Ticket1.AgregaTotales("Sub-Total", float.Parse(subtotalRe)); // imprime linea con Subtotal
                Ticket1.AgregaTotales("Propina", float.Parse(propinaRe)); // imprime linea con decuento total
                Ticket1.TextoIzquierda(" ");
                Ticket1.AgregaTotales("Total", float.Parse(totalRe)); // imprime linea con total
                Ticket1.TextoIzquierda(" ");
                Ticket1.AgregaTotales("Efectivo Entregado:", float.Parse(txtIngreso.Text));
                Ticket1.AgregaTotales("Efectivo Devuelto:", float.Parse(feriaRe));


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
        private void txtIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar si la tecla presionada es un número o un punto decimal.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancelar la pulsación de la tecla.
                e.Handled = true;
            }
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
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

        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            cargarDatos();

            /*dbcomandas database = new dbcomandas();
            clasecomanda obj = new clasecomanda();
            
            if (cmbMesa.Text != "")
            {
                obj.mesa = (int)cmbMesa.SelectedValue;

                //tCombo.Start();
                DataTable datos = new DataTable();
                database.ConsultarCodigoH(obj);
                dgvDatos.DataSource = datos;
            }
            else MessageBox.Show("Falto capturar informacion");*/

            

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
    }
}

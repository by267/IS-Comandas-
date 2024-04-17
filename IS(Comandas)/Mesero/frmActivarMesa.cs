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

namespace IS_Comandas_.Mesero
{
    public partial class frmActivarMesa : Form
    {
        private void cargarCombo()
        {
            cmbMesa.Text = "Selecciona una opcion";
            dbMesa db = new dbMesa();

            cmbMesa.DataSource = db.ConsultarE("idmesas");
            cmbMesa.DisplayMember = "idmesas";
            cmbMesa.ValueMember = "idmesas";
        }
        public frmActivarMesa()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void frmActivarMesa_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cargarCombo();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbMesa database = new dbMesa();
            ClassMesa obj = new ClassMesa();
            obj.Id = int.Parse(cmbMesa.SelectedValue.ToString());
            database.activarMesa(obj);
            timer1.Start();
            MessageBox.Show("La mesa se activó con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            timer1.Stop();

        }
    }
}

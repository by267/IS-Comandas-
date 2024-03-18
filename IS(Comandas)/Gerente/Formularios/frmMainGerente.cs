using IS_Comandas_.Gerente;
using IS_Comandas_.Gerente.Formularios;
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
    public partial class frmMainGerente : Form
    {
        public frmMainGerente()
        {
            InitializeComponent();
        }
        private void btniCerrar_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
        private void btnAddEmpleado_Click_1(object sender, EventArgs e)
        {
            frmEmpleado frm = new frmEmpleado();
            frm.Show();
            
        }
        private void btnAddMesa_Click(object sender, EventArgs e)
        {
            frmMesa frm = new frmMesa();
            frm.Show();
        }      
        private void btnDelEmpleado_Click(object sender, EventArgs e)
        {
            frmDelEmpleado frm = new frmDelEmpleado();
            //this.Enabled = false;
            frm.Show();
        }
        private void btnDelMesa_Click(object sender, EventArgs e)
        {
            frmDelMesa frm = new frmDelMesa();
            //this.Enabled = false;
            frm.Show();
        }
        private void btnDelCategoria_Click(object sender, EventArgs e)
        {
            frmDelCategoria frm = new frmDelCategoria();
            //this.Enabled = false;
            frm.Show();     
        }
        private void btnDelMenu_Click(object sender, EventArgs e)
        {
            frmDelMenu frm = new frmDelMenu();
            frm.Show();
        }
        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            frmMenu frmAEmp = new frmMenu();
            //this.Enabled = false;
            frmAEmp.Show();
        }
        private void btnAddCategoria_Click(object sender, EventArgs e)
        {
            frmCategoria frmAEmp = new frmCategoria();
            //this.Enabled = false;
            frmAEmp.Show();
        }
    }
}

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text=="gerente"|| txtUsuario.Text=="Gerente")
            {
                frmMainGerente frmMGer = new frmMainGerente();
                frmMGer.Show();

                this.Hide();
            }
            else if(txtUsuario.Text=="cajero" || txtUsuario.Text== "Cajero")
            {
                frmMainCajero frmMGer = new frmMainCajero();
                frmMGer.Show();

                this.Hide();
            }
        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: 1.2 alpha", "About");
        }
    }
}

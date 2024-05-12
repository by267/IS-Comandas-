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
using static IS_Comandas_.frmMainCajero;

namespace IS_Comandas_
{
    public partial class Form1 : Form
    {
        string usuario;
        public string nombre;
        public delegate void DatosEnviadosEventHandler(string nombre);
        public event DatosEnviadosEventHandler DatosEnviados;
        public Form1()
        {
            InitializeComponent();
        }
        private void cargarPuesto()
        {
            dbEmpleado dbe = new dbEmpleado();
            ClassEmpleado obj = new ClassEmpleado();
            DataTable datos = new DataTable();

            obj.Usuario = txtUsuario.Text;
            datos = dbe.ConsultarPuesto(obj);
            if (datos.Rows.Count > 0 ) 
            {
                lblPuesto.Text = datos.Rows[0]["puesto"].ToString();
            }
            
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPass.Text;
            try
            {
                Control ctrl = new Control();
                string respuesta = ctrl.ctrlLogin(usuario, password);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (lblPuesto.Text == "Gerente")
                    {
                        frmMainGerente frm = new frmMainGerente();
                        frm.Visible = true;
                        this.Visible = false;
                    }
                    else if (lblPuesto.Text == "Mesero")
                    {
                        frmMainMesero frm = new frmMainMesero();
                        frm.Visible = true;
                        this.Visible = false;
                    }
                    else if(lblPuesto.Text == "Cajero")
                    {
                        cargarEmp();
                        //DatosCompartidos.Empleado = txtUsuario.Text;
                        frmMainCajero frm = new frmMainCajero();
                        frm.Visible = true;
                        this.Visible = false;
                        //cargarEmp();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void txtPass_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                cargarPuesto();
            }
        }
        public void cargarEmp()
        {

            dbEmpleado dbe = new dbEmpleado();
            ClassEmpleado obj = new ClassEmpleado();
            DataTable datos = new DataTable();

            obj.Usuario = txtUsuario.Text;
            datos = dbe.ConsultarEmpleadoU(obj);
            if (datos.Rows.Count > 0)
            {
                nombre = datos.Rows[0]["nombreCompleto"].ToString();
                DatosCompartidos.Empleado = nombre;
            }
            
        }
    }
}

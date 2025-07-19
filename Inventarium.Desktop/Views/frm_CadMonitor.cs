using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventarium.Models;
using Inventarium.Data;

namespace Inventarium
{
    public partial class frm_CadMonitor : Form
    {
        public frm_CadMonitor()
        {
            InitializeComponent();
        }

        private void txtbox_Patrimonio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            frm_Step01 step01 = new();
            step01.Show();
            this.Hide();
        }

        private void lbl_Close_Click(object sender, EventArgs e)
        {
            FecharPrograma programa = new();
            programa.Encerrar();
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            ManipularDados Salvar = new();
            Salvar.InserirMonitor(txtUnidade.Text, txtDepto.Text, txtFabricante.Text, txtModelo.Text, txtNS.Text, txtPatrimonio.Text);
        }

        private void txtbox_NS_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox_Modelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox_Fabricante_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtbox_Depto_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtbox_Unidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

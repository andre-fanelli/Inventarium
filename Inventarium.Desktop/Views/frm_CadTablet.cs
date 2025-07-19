using Inventarium.Data;
using Inventarium.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventarium
{
    public partial class frm_CadTablet : Form
    {
        public frm_CadTablet()
        {
            InitializeComponent();
        }

        private void lbl_Close_Click(object sender, EventArgs e)
        {
            FecharPrograma programa = new();
            programa.Encerrar();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            frm_Step01 step01 = new();
            step01.Show();
            this.Hide();
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            ManipularDados Salvar = new();
            Salvar.InserirTablet(txtUnidade.Text, txtDepto.Text, txtFabricante.Text, txtModelo.Text, txtNS.Text, txtPatrimonio.Text);
        }

        private void lbl_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

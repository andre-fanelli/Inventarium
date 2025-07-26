using Inventarium.Data;
using Inventarium.Models;

namespace Inventarium
{
    public partial class frm_CadNote : Form
    {
        public frm_CadNote()
        {
            InitializeComponent();
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

        private void frm_CadNote_Load(object sender, EventArgs e)
        {
            try
            {
                txtHostname.Text = CarregarInfo.ObterHostname();
                txtSO.Text = CarregarInfo.ObterSO();
                txtProcessador.Text = CarregarInfo.ObterProcessador();
                txtRAM.Text = CarregarInfo.ObterRAM();
                txtStorage.Text = CarregarInfo.ObterStorage();
                txtFabricante.Text = CarregarInfo.ObterFabricante();
                txtModelo.Text = CarregarInfo.ObterModelo();
                txtNS.Text = CarregarInfo.ObterNumeroSerie();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Falha ao carregar informações", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Salvar_Click(object sender, EventArgs e)
        {
            ManipularDados Salvar = new();
            Salvar.InserirNotebook(txtUnidade.Text, txtDepto.Text, txtProcessador.Text, Convert.ToInt32(txtRAM.Text), Convert.ToInt32(txtStorage.Text), txtHostname.Text, txtFabricante.Text, txtModelo.Text, txtNS.Text, txtPatrimonio.Text, txtSO.Text);
        }

        private void ckbRAM_CheckedChanged_1(object sender, EventArgs e)
        {
            txtRAM.ReadOnly = !ckbRAM.Checked;
        }

        private void ckbProcessador_CheckedChanged_1(object sender, EventArgs e)
        {
            txtProcessador.ReadOnly = !ckbProcessador.Checked;
        }

        private void ckbStorage_CheckedChanged_1(object sender, EventArgs e)
        {
            txtStorage.ReadOnly = !ckbStorage.Checked;
        }

        private void ckbHostname_CheckedChanged_1(object sender, EventArgs e)
        {
            txtHostname.ReadOnly = !ckbHostname.Checked;
        }

        private void ckbFabricante_CheckedChanged_1(object sender, EventArgs e)
        {
            txtFabricante.ReadOnly = !ckbFabricante.Checked;
        }

        private void ckbModelo_CheckedChanged_1(object sender, EventArgs e)
        {
            txtModelo.ReadOnly = !ckbModelo.Checked;
        }

        private void ckbNS_CheckedChanged_1(object sender, EventArgs e)
        {
            txtNS.ReadOnly = !ckbNS.Checked;
        }

        private void ckbSO_CheckedChanged_1(object sender, EventArgs e)
        {
            txtSO.ReadOnly = !ckbSO.Checked;
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            ckbProcessador.Visible = false;
            ckbRAM.Visible = false;
            ckbStorage.Visible = false;
            ckbHostname.Visible = false;
            ckbFabricante.Visible = false;
            ckbModelo.Visible = false;
            ckbNS.Visible = false;
            ckbSO.Visible = false;

            ckbProcessador.Checked = false;
            ckbRAM.Checked = false;
            ckbStorage.Checked = false;
            ckbHostname.Checked = false;
            ckbFabricante.Checked = false;
            ckbModelo.Checked = false;
            ckbNS.Checked = false;
            ckbSO.Checked = false;

            btnConcluir.Visible = false;
            btnEditar.Visible = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ckbProcessador.Visible = true;
            ckbRAM.Visible = true;
            ckbStorage.Visible = true;
            ckbHostname.Visible = true;
            ckbFabricante.Visible = true;
            ckbModelo.Visible = true;
            ckbNS.Visible = true;
            ckbSO.Visible = true;

            btnEditar.Visible = false;
            btnConcluir.Visible = true;
         
        }

        private void lbl_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


    }
}

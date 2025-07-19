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
    public partial class frm_Step01 : Form
    {
        public frm_Step01()
        {
            InitializeComponent();
        }

        private void btn_Avancar02_Click(object sender, EventArgs e) 
        {
            if (cmb_Equipamento.SelectedIndex.Equals(-1)) 
            {
                MessageBox.Show("Selecione um equipamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmb_Equipamento.Focus();
            }
            else
            {
                switch (cmb_Equipamento.SelectedItem)
                {
                    case "Computador":
                        frm_CadPC cadPC = new();
                        cadPC.Show();
                        this.Hide();
                        break;

                    case "Notebook":
                        frm_CadNote cadNote = new();
                        cadNote.Show();
                        this.Hide();
                        break;

                    case "Monitor":
                        frm_CadMonitor cadMonitor = new();
                        cadMonitor.Show();
                        this.Hide();
                        break;
                    case "Impressora":
                        frm_CadPrinter cadPrinter = new();
                        cadPrinter.Show();
                        this.Hide();
                        break;

                    case "Ativo de Rede":
                        frm_CadRede cadRede = new();
                        cadRede.Show();
                        this.Hide();
                        break;

                    case "Tablet":
                        frm_CadTablet cadTablet = new();
                        cadTablet.Show();
                        this.Hide();
                        break;
                }
            }

        }

        private void lbl_Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar o programa?", "Encerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (DialogResult.No))
            {
                return;
            }

            else
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar o programa?", "Encerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (DialogResult.No))
            {
                return;
            }

            else
            {
                Application.Exit();
            }
        }
    }
}

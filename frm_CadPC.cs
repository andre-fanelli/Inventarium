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
    public partial class frm_CadPC : Form
    {
        public frm_CadPC()
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

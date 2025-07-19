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
    public partial class frm_Inicio : Form
    {
        public frm_Inicio()
        {
            InitializeComponent();
        }

        private void frm_Inicio_Load(object sender, EventArgs e)
        {

        }

        private void btn_Avancar_Click(object sender, EventArgs e)
        {
            frm_Step01 inicio= new frm_Step01();
            inicio.Show();
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

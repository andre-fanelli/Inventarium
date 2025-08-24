using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventarium.Models
{
    public class FecharPrograma
    {
        public void Encerrar()
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

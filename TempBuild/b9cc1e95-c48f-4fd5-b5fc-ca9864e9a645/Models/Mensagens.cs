using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventarium.Models
{
    public class Mensagens
    {
        public void Sucesso()
        {
            MessageBox.Show("Equipamento registrado com sucesso!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_controle_de_Vendas.br.com.projeto.model
{
    public class Helpers
    {
        public void Limpartela(Form tela)
        {
            foreach (Control crtPai in tela.Controls)
            {
                foreach (Control ctr1 in crtPai.Controls)
                {
                    if (ctr1 is TabPage)
                    {
                        foreach (Control ctr2 in ctr1.Controls)
                        {


                            if (ctr2 is TextBox)
                            {
                                //limpar campo de texto
                                (ctr2 as TextBox).Text = string.Empty;

                            }

                            if (ctr2 is MaskedTextBox)
                            {
                                //limpar campo de texto
                                (ctr2 as MaskedTextBox).Text = string.Empty;

                            }

                        }
                            
                        


                    }   

                }
            }
        }
    }
}

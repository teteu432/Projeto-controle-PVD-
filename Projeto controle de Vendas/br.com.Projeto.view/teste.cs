using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_controle_de_Vendas.br.com.Projeto.view
{
    public partial class teste : Form
    {
        public teste()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmclientes AbrirC = new frmclientes();

            AbrirC.ShowDialog();

        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            frmfuncionarios abrirF = new frmfuncionarios();
            abrirF.ShowDialog();
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            FrmFornecedores abrirFornecedor = new FrmFornecedores();
            abrirFornecedor.ShowDialog();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            Frmproduto abriP = new Frmproduto();
            abriP.ShowDialog();
        }
    }
}

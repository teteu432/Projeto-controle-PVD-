using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto_controle_de_Vendas.br.com.projeto.dao;
using Projeto_controle_de_Vendas.br.com.projeto.model;

namespace Projeto_controle_de_Vendas.br.com.Projeto.view
{
    public partial class Frmproduto : Form
    {
        public Frmproduto()
        {
            InitializeComponent();
        }

        private void Frmproduto_Load(object sender, EventArgs e)
        {
            FornecedorDao f_dao = new FornecedorDao();

            txtFornecedor.DataSource = f_dao.listarFornecedor();
            txtFornecedor.DisplayMember = "nome";
            txtFornecedor.ValueMember = "id"; 

            ProdutoDao dao = new ProdutoDao();
            tabelaProduto.DataSource = dao.listarprodutos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor do combobox: " + txtFornecedor.SelectedValue);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produtos obj = new Produtos();

            obj.descricao = txtdescricao.Text;
            obj.preco = decimal.Parse(txtPreco.Text);
            obj.qtdestoque = int.Parse(txtqtdEstoque.Text);
            obj.for_id = int.Parse(txtFornecedor.SelectedValue.ToString());

            //Criar obj Dao

            ProdutoDao dao = new ProdutoDao();
            dao.cadastrarProduto(obj);

            new Helpers().Limpartela(this); 
            tabelaProduto.DataSource= dao.listarprodutos();


        }

        private void tabelaProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = tabelaProduto.CurrentRow.Cells[0].Value.ToString();
            txtdescricao.Text = tabelaProduto.CurrentRow.Cells[1].Value.ToString();
            txtPreco.Text = tabelaProduto.CurrentRow.Cells[2].Value.ToString();
            txtqtdEstoque.Text = tabelaProduto.CurrentRow.Cells[3].Value.ToString();
            txtFornecedor.Text = tabelaProduto.CurrentRow.Cells[4].Value.ToString();

            tabProdutos.SelectedTab = tabPage1;

        }
    }
}

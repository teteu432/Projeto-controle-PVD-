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
    public partial class frmVendas : Form
    {
        Cliente cliente = new Cliente();
        ClienteDAO clienteDAO = new ClienteDAO();

        //objeto de produto
        Produtos p = new Produtos();
        ProdutoDao pDao = new ProdutoDao();

        int qtd;
        decimal preco;
        decimal subtotal, total;

        DataTable carrinho = new DataTable();

        public frmVendas()
        {
            InitializeComponent();

            carrinho.Columns.Add("Código", typeof(int));
            carrinho.Columns.Add("Produto", typeof(string));
            carrinho.Columns.Add("Qtd", typeof(decimal));
            carrinho.Columns.Add("Preço", typeof(decimal));
            carrinho.Columns.Add("Subtotal", typeof(decimal));

            tabelasProdutos.DataSource = carrinho;
        }

        private void frmVendas_Load(object sender, EventArgs e)
        {


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cliente = clienteDAO.retornaClientePorCpf(txtCpf.Text);
                txtNome.Text = cliente.nome;
            }
        }

        private void frmVendas_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnadicionarittem_Click(object sender, EventArgs e)
        {
            qtd = int.Parse(txtqtd.Text);
            preco = decimal.Parse(txtPreco.Text);

            subtotal = qtd * preco;

            total += subtotal;

            carrinho.Rows.Add(int.Parse(txtCodigo.Text), txtdescricao.Text, qtd, preco, subtotal);

            txtTotal.Text = total.ToString();

            txtCodigo.Clear();
            txtdescricao.Clear();
            txtqtd.Clear();
            txtPreco.Clear();

            txtCodigo.Focus();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                p = pDao.retornaProdutoPorCodigo(int.Parse(txtCodigo.Text));

                txtdescricao.Text = p.descricao; 
                txtPreco.Text = p.preco.ToString();
            }
        }
    }
}

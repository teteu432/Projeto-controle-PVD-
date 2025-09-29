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
    public partial class FrmFornecedores : Form
    {
        public FrmFornecedores()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Fornecedor obj = new Fornecedor();
            obj.nome = txtNome.Text;
            obj.cnpj = txtCnpj.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCep.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComplemento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = txtEstado.Text;

            //Criar obj classe ForneceddorDao

            FornecedorDao dao = new FornecedorDao();
            dao.cadastrarFornecedor(obj);
            new Helpers().Limpartela(this);
            //Carregar datagridge view
            tabelaFornecedor.DataSource = dao.listarFornecedor();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text;

            FornecedorDao dao = new FornecedorDao();
            tabelaFornecedor.DataSource = dao.BuscarFornecedorPorNome(nome);

            if (tabelaFornecedor.Rows.Count == 0)
            {
                tabelaFornecedor.DataSource = dao.listarFornecedor();
            }
        }
        

        private void tabelaFornecedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabConsulta_Click(object sender, EventArgs e)
        {

        }

        private void FrmFornecedores_Load(object sender, EventArgs e)
        {
            FornecedorDao dao = new FornecedorDao();
            tabelaFornecedor.DataSource = dao.listarFornecedor();  
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().Limpartela(this);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Fornecedor obj = new Fornecedor();

            obj.codigo = int.Parse(txtCodigo.Text);

            FornecedorDao dao = new FornecedorDao();
            dao.excluirfornecedor(obj);
            tabelaFornecedor.DataSource = dao.listarFornecedor();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //1 - receber dados dentro de um obj model client
            Fornecedor obj = new Fornecedor();
            obj.nome = txtNome.Text;
            obj.cnpj = txtCnpj.Text;
           
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.endereco = txtEndereco.Text;
            // obj.numero = int.Parse(txtNumero.Text);
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.celular = txtCelular.Text;
            obj.estado = txtEstado.Text;
            obj.cep = txtCep.Text;

            obj.codigo = int.Parse(txtCodigo.Text);

            //2 - Criar obj Class Dao e chamar mtd alterar

            FornecedorDao dao = new FornecedorDao();
            dao.alterarFornecedor(obj);

            //atrualizar tabela
            tabelaFornecedor.DataSource= dao.listarFornecedor();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                string cep = txtCep.Text;
                string xml = "https://viacep.com.br/ws/" + cep + "/xml/";

                DataSet dados = new DataSet();

                dados.ReadXml(xml);

                txtEndereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtComplemento.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                txtEstado.Text = dados.Tables[0].Rows[0]["uf"].ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Endereço não encontrado. Digite manualmente");
            }
        }

        private void tabelaFornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = tabelaFornecedor.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaFornecedor.CurrentRow.Cells[1].Value.ToString();
            
            txtCnpj.Text = tabelaFornecedor.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = tabelaFornecedor.CurrentRow.Cells[3].Value.ToString();
            txtTelefone.Text = tabelaFornecedor.CurrentRow.Cells[4].Value.ToString();
            txtCelular.Text = tabelaFornecedor.CurrentRow.Cells[5].Value.ToString();
            txtCep.Text = tabelaFornecedor.CurrentRow.Cells[6].Value.ToString();
            txtEndereco.Text = tabelaFornecedor.CurrentRow.Cells[7].Value.ToString();
            txtNumero.Text = tabelaFornecedor.CurrentRow.Cells[8].Value.ToString();
            txtComplemento.Text = tabelaFornecedor.CurrentRow.Cells[9].Value.ToString();
            txtBairro.Text = tabelaFornecedor.CurrentRow.Cells[10].Value.ToString();
            txtCidade.Text = tabelaFornecedor.CurrentRow.Cells[11].Value.ToString();
            txtEstado.Text = tabelaFornecedor.CurrentRow.Cells[12].Value.ToString();

            tabFornecedor.SelectedTab = tabPessoais;

        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";

            FornecedorDao dao = new FornecedorDao();

            tabelaFornecedor.DataSource = dao.ListarFornecedorPorNome(nome);
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_controle_de_Vendas.br.com.projeto.model
{
    public class Funcionario : Cliente
    {
        //atributois getter e setters
        public string senha {  get; set; }

        public string cargo { get; set; }

        public string nivel_acesso { get; set; }

    }
}

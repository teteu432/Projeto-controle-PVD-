using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_controle_de_Vendas.br.com.projeto.model
{
    public class Vendas
    {
        public int idd { get; set; } 
        public int clientee_i { get; set; }
        public DateTime data_venda { get; set; }    
        public decimal total_venda { get; set; }
        public string obs {  get; set; }
    }
}

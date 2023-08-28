using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AjudaCerta.Models.Enuns;

namespace AjudaCerta.Models
{
    public class Produto : ItemDoacao
    {
        
        public int idProduto { get; set; }
        public DateTime validade { get; set; }
        public TipoProdutoEnum tipoProduto { get; set; }
    }
}
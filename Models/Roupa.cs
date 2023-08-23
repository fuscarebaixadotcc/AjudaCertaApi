using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjudaCerta.Models.Enuns;

namespace AjudaCerta.Models
{
    public class Roupa : ItemDoacao
    {
        public int idRoupa { get; set; }
        public string tamanho { get; set; }
        public string condicao { get; set; }
        public GeneroEnum genero { get; set; }
        public FaixaEtariaEnum faixaEtaria { get; set; }
    }
}